﻿using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using CIM.ServiceNpk;
using Android.Telephony;
using System.Timers;
using Android.Util;
using Android.Gms.Common;
using Newtonsoft.Json;

using System.IO;
using Android.Net;

namespace CIM
{
	[Activity (Label = "CIM", 
		MainLauncher = true, 
		Icon = "@drawable/icon",
		Theme = "@android:style/Theme.DeviceDefault.Light.NoActionBar")]
	public class MainActivity : Activity
	{

		/*Variabili Globali*/
		ServiceNpk.ServiceControlloImpianti s = new ServiceControlloImpianti();

		string Imei;
		TextView lblInfoUser, lblInfoOp;
		ListView lstCommesse;
		ProgressDialog dialog;
		Timer t1;
		Operatore op;

		public Utente ut;

		/*-----------------------*/

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.Main);


			TelephonyManager tl = (TelephonyManager)GetSystemService (TelephonyService);

			/*Controllo se esistono connessioni di rete dati attive.*/
			Android.Net.ConnectivityManager ntw = (Android.Net.ConnectivityManager)GetSystemService (ConnectivityService);
			NetworkInfo connessioneAttiva = ntw.ActiveNetworkInfo;
			bool isOnline = (connessioneAttiva != null) && connessioneAttiva.IsConnected;
			if (!isOnline) {
				MsgBox ("Il programma richiede una connessione dati per funzionare \n controllare la connessione e riprovare.")
					.Show ();
			} else {
				/* Qui ci arrivo solo se esistono connesisoni di rete attive*/



				prepareWaitDialog ("Connessione al server ANM...", false);

				/*Componenti del form*/
				lblInfoUser = FindViewById<TextView> (Resource.Id.lblInfoUser);
				lblInfoOp = FindViewById<TextView> (Resource.Id.lblInfoOperatore);
				lstCommesse = FindViewById<ListView> (Resource.Id.lstCommesse);
				Button btnListaCommesse = FindViewById<Button> (Resource.Id.btnCommesseAperte);
				Button btnCreaCommessa = FindViewById<Button> (Resource.Id.btnCreaCommesse);


				/*********************/

				btnListaCommesse.Click += BtnListaCommesse_Click;
				btnCreaCommessa.Click += (sender, e) => {
					Intent i = new Intent(this, typeof(frmCreaCommessa));
					i.PutExtra("coddip",op.Coddip);
					StartActivity(i);
				};


				Imei = tl.DeviceId;
				dialog.Show ();
				lblInfoUser.Text = "Recupero informazioni di accesso in corso...";
				s.BeginControlloCredenziali (Imei, ControlloCredenzialiCallBack, null);



				t1 = new Timer (10000);
				t1.Interval = 10000;
				t1.Enabled = true;
				t1.Elapsed += T1_Elapsed;
			}

		}

		void BtnListaCommesse_Click (object sender, EventArgs e)
		{
			CaricaLista ();
		} 

		void T1_Elapsed (object sender, ElapsedEventArgs e)
		{
			RunOnUiThread (() => {
				CheckValidUser();
			});
		}

		void CheckValidUser() {
			ut =	s.ControlloCredenziali (Imei);
			if (ut.NumTel != Imei) {
				MsgBox(ut.NumTel).Show();
			}
		}

		/*Parte dopo le verifiche utente*/
		public void suUtenteVerificato(){
			/*Controllo se i servizi Play di Google Sono Attivi*/
			if (IsPlayServicesAvailable ()) {
				var intent = new Intent (this, typeof(RegistrationIntentService));
				intent.PutExtra ("Ute", ut.Matricola); //passo la matricola al servizio di registrazione messaggi
				StartService (intent); /*Start Servizio Google Play*/
				StartService (new Intent(this, typeof(MyGcmListenerService)));
			}

			CaricaLista ();

			/*Se provengo da una notifica devo aprire direttamente la pagina di dettaglio commesse.*/
			if (this.Intent.HasExtra ("commessanum")) {
				string numcommessa = this.Intent.GetStringExtra ("commessanum");
				Commesse commessa = s.GetCommessa (int.Parse (numcommessa));
				Intent frmCommesse = new Intent (this, typeof(frmDettagliCommesse));
				frmCommesse.PutExtra ("commessa", JsonConvert.SerializeObject (commessa));

				StartActivityForResult (frmCommesse,0);
				
			} else if (this.Intent.HasExtra("messaggio")) {
				Messaggio mess = JsonConvert.DeserializeObject<Messaggio>(this.Intent.GetStringExtra("messaggio"));

				MsgBox (mess.TestoMessaggio, mess.Mittente, "Letto", null, () => {
					if (!Directory.Exists(Android.OS.Environment.ExternalStorageDirectory.AbsolutePath+"/CIM/log/")) {
						Directory.CreateDirectory(Android.OS.Environment.ExternalStorageDirectory.AbsolutePath+"/CIM/log/" );

					}
					StreamWriter w = new StreamWriter(Android.OS.Environment.ExternalStorageDirectory.AbsolutePath+"/CIM/log/Messaggi.txt" ,true);
					w.WriteLine("["+DateTime.Now.ToShortDateString()+" " +
						DateTime.Now.ToShortTimeString()+ "] Messaggio da "+mess.Mittente+": " + mess.TestoMessaggio);
					w.Flush();
					w.Close();

				}).Show();

			
			}


		}

		protected override void OnActivityResult (int requestCode, Result resultCode, Intent data)
		{
			if (resultCode == Result.Ok) {
				CaricaLista ();
			}
		}

	
		private void ScriviOpzioni(string Opzione, string valore) {
			if (!Directory.Exists(Android.OS.Environment.ExternalStorageDirectory.AbsolutePath+"/CIM/opt/")) {
				Directory.CreateDirectory(Android.OS.Environment.ExternalStorageDirectory.AbsolutePath+"/CIM/opt/" );

			}
			StreamWriter w = new StreamWriter(Android.OS.Environment.ExternalStorageDirectory.AbsolutePath+"/CIM/opt/options.dat" ,false);
			w.WriteLine(Opzione+";"+valore);
			w.Flush();
			w.Close();
		}

		private string LeggiOpzione(string opzione) {
			string ret = "";
			try {
				StreamReader r = new StreamReader (Android.OS.Environment.ExternalStorageDirectory.AbsolutePath + "/CIM/opt/options.dat");	
				while (!r.EndOfStream) {
					string[] arr = r.ReadLine ().Split (new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
					if (arr [0] == opzione) {
						ret=  arr [1];
					}
					r.Close();
				}
			} catch (Exception) {
				
			}

			return ret;
		}

		/*Routine di caricamento lista*/
		Object obj = new object();
		private void CaricaLista() {
			prepareWaitDialog ("Carico commesse per la squadra...", false);
			dialog.Show ();
			s.BeginGetCommesseByOperatore (op, (ar) => {
				try {
					Commesse[] ls = s.EndGetCommesseByOperatore(ar);
					RunOnUiThread(()=> {
						CommesseListAdapter DatiLista = new CommesseListAdapter (this, ls);
						lstCommesse.Adapter = DatiLista;
						lstCommesse.FastScrollEnabled = true;
						lstCommesse.ItemClick += LstCommesse_ItemClick;
						dialog.Dismiss();
					});
				} catch (Exception ex) {
					RunOnUiThread(()=>{
						Toast.MakeText(this,"Errore:"+ex.Message,ToastLength.Short).Show();
						dialog.Dismiss();
						CaricaLista();
						return;
					});					
				}

			}, 
				obj);

		}

		/*********************************************************************/
		/*Click commessa selezionata dalla lista(Partenza frmDettagliCommessa*/
		void LstCommesse_ItemClick (object sender, AdapterView.ItemClickEventArgs e)
		{
			Commesse commessaSelezionata = lstCommesse.GetItemAtPosition (e.Position).Cast<Commesse> ();
			Intent frmCommesse = new Intent (this, typeof(frmDettagliCommesse));

			frmCommesse.PutExtra ("commessa", JsonConvert.SerializeObject(commessaSelezionata) );
			StartActivityForResult (frmCommesse,0);
		}
		/**********************************************************************/


		//Chiamata da Asincronia Controllo Credenziali Utente 
		private void ControlloCredenzialiCallBack (IAsyncResult ar) {
			ut = s.EndControlloCredenziali (ar);
			RunOnUiThread( () => {
				if (ut.NumTel != Imei) {
					MsgBox(ut.NumTel).Show();
				}
				lblInfoUser.Text = ut.Cognome+" "+ut.Nome+" ["+ut.Matricola+"]";
				dialog.SetMessage("Carico info operatore...");
				s.BeginGetOperatore(ut.Matricola, (ar1)=>{
					try {
						RunOnUiThread( ()=> {
							op = s.EndGetOperatore(ar1);
							lblInfoOp.Text = "Att:"+op.AttivitaSvolte.Length;
							dialog.Dismiss();
							suUtenteVerificato();
						});
					} catch (Exception ex) {
						dialog.Dismiss();
						string exm = ex.Message.Substring(ex.Message.IndexOf("-->")+3);
						RunOnUiThread(()=>{	MsgBox(exm).Show();;});
						return;
					}


				},null);

			});
		}


		/*Progress Dialog*/
		private ProgressDialog  prepareWaitDialog(string msg, bool CanDismiss) 
		{
			dialog = new ProgressDialog(this);
			dialog.Indeterminate = true;
			dialog.SetProgressStyle (ProgressDialogStyle.Spinner);
			dialog.SetMessage (msg);
			dialog.SetCancelable (CanDismiss);
			return dialog;
		}



		private AlertDialog.Builder MsgBox(string msg,string titolo="Messaggio CIM", 
			string PositiveText="OK", string NegativeText = "Annulla",
			Action PositiveAction = null, Action NegativeAction = null){
			AlertDialog.Builder d = new AlertDialog.Builder (this);
			d.SetCancelable (false);
			d.SetMessage (msg);
			d.SetPositiveButton (PositiveText, ( sender,  e) => {
				if (PositiveAction == null) {
					Android.OS.Process.KillProcess(Android.OS.Process.MyPid()); //Chiusura processo applicazione!
				} else {
					PositiveAction.Invoke();
				}
			});
			if (NegativeAction != null) {
				d.SetNegativeButton(NegativeText, (sender, e) => { NegativeAction.Invoke();});
			}
			d.SetTitle (titolo);
			return d;
		
		}


		/*Generata per GMS*/
		public bool IsPlayServicesAvailable ()
		{
			int resultCode = GooglePlayServicesUtil.IsGooglePlayServicesAvailable (this);
			if (resultCode != ConnectionResult.Success)
			{
				if (GooglePlayServicesUtil.IsUserRecoverableError (resultCode)) {
					MsgBox ("Problema con i servizi google: " + resultCode.ToString()).Show ();
					//Finish ();
				}
				else
				{
					MsgBox ("Problema con attivazione GooglePlay Services. Contattare ICT " + resultCode.ToString() ).Show ();
					//Finish ();
				}
				return false;
			}
			else
			{
				
				return true;
			}
		}

	}

	public static class ObjectTypeHelper
	{
		public static T Cast<T>(this Java.Lang.Object obj) where T : class
		{
			var propertyInfo = obj.GetType().GetProperty("Instance");
			return propertyInfo == null ? null : propertyInfo.GetValue(obj, null) as T;
		}
	}

}


