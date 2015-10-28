
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using CIM.ServiceNpk;

namespace CIM
{
	/*Creare un delegato per la creazione di un evento di uscita dal caricamento asincrono*/
	[Activity (Label = "frmCreaCommessa", NoHistory = true)]			
	public class frmCreaCommessa : Activity
	{
		AutoCompleteTextView txtImpianto;
		EditText txtDescrizione;
		ServiceControlloImpianti s = new ServiceControlloImpianti ();
		ListView lstAttivita;
		Impianti[] i;
		Attivita[] lsa;
		List<Attivita> AttivitaScelte;
		string Coddip;


		ProgressDialog dialog;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetTheme (Android.Resource.Style.ThemeHoloLightNoActionBar);
			SetContentView (Resource.Layout.frmCreaCommessa);
			txtImpianto = FindViewById<AutoCompleteTextView> (Resource.Id.txtImpianto_cc );
			txtDescrizione = FindViewById<EditText> (Resource.Id.txtDescrizione_cc);
			lstAttivita = FindViewById<ListView> (Resource.Id.lstAttivita_cc);
			Button btnSalvaCommessa = FindViewById<Button> (Resource.Id.btnSalva_cc);
			Button btnAnnulla = FindViewById<Button> (Resource.Id.btnAnnulla_cc);

			btnSalvaCommessa.Click+= BtnSalvaCommessa_Click;

			Coddip = this.Intent.GetStringExtra ("coddip");
			AttivitaScelte = new List<Attivita> ();

			prepareWaitDialog ("Carico Impianti...", false).Show();


			s.BeginGetImpianti (
				(ar) => {
					
					try {
						i = s.EndGetImpianti (ar);	
					} catch (Exception) {
						return;

					}
					List<string> ls = new List<string>();
					foreach (Impianti item in i) {
						ls.Add(item.Id+  " - " +item.Descrizione );
					}
					ArrayAdapter dati = new ArrayAdapter(this, Android.Resource.Layout.SimpleDropDownItem1Line, ls);
					RunOnUiThread(()=>{
						txtImpianto.Adapter = dati;
						//dialog.Dismiss ();
						dialog.SetMessage("Carico Attivita...");
						s.BeginGetAttivita (
							(ar1) => {
								try {
									lsa = s.EndGetAttivita(ar1);
									AttivitaListAdapter datiAtt = new AttivitaListAdapter(this,lsa);
									datiAtt.OnCheckChange += (int pos, bool stato) => {
										if (stato) 
											AttivitaScelte.Add(lsa[pos]);

										else 
											//datiAtt.StatoCheck[pos] = 0;
											AttivitaScelte.Remove(lsa[pos]);
										
									};
									RunOnUiThread(()=>{	lstAttivita.Adapter = datiAtt;dialog.Dismiss();});	
								} catch (Exception ) {
									return;

								}	

							}, null);
					});
				}, null);
		
			

			

		}

		void BtnSalvaCommessa_Click (object sender, EventArgs e)
		{
			Commesse c = new Commesse ();
			c.Descrizione = txtDescrizione.Text;
			c.Operatori = s.GetOperatoriByCommaMatricola (Coddip);
			c.Impianto = s.GetImpiantoByID (txtImpianto.Text.Substring (0, txtImpianto.Text.IndexOf ("-")).Trim ());
			c.Lavori = AttivitaScelte.ToArray();
			s.BeginSalvaCommessaAndroid (c, (ar) => {
				string ris = s.EndSalvaCommessaAndroid(ar);
				if (ris == "OK") {
					RunOnUiThread(()=>{Toast.MakeText(this,"Commessa inserita correttamente...", ToastLength.Short).Show();Finish();});
				} else {
					RunOnUiThread(()=>{Toast.MakeText(this,ris, ToastLength.Short).Show();});
				}
			}, null);
		}

		private ProgressDialog  prepareWaitDialog(string msg, bool CanDismiss) 
		{
			dialog = new ProgressDialog(this);
			dialog.Indeterminate = true;
			dialog.SetProgressStyle (ProgressDialogStyle.Spinner);
			dialog.SetMessage (msg);
			dialog.SetCancelable (CanDismiss);
			return dialog;
		}

    }
}

