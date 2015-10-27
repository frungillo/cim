
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
	[Activity (Label = "frmCreaCommessa", NoHistory = true)]			
	public class frmCreaCommessa : Activity
	{
		AutoCompleteTextView txtImpianto;
		EditText txtDescrizione;
		ServiceControlloImpianti s = new ServiceControlloImpianti ();
		ListView lstAttivita;


		ProgressDialog dialog;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetTheme (Android.Resource.Style.ThemeHoloLightNoActionBar);
			SetContentView (Resource.Layout.frmCreaCommessa);
			txtImpianto = FindViewById<AutoCompleteTextView> (Resource.Id.txtImpianto_cc );
			txtDescrizione = FindViewById<EditText> (Resource.Id.txtDescrizione_cc);
			lstAttivita = FindViewById<ListView> (Resource.Id.lstAttivita_cc);

			prepareWaitDialog ("Carico Impianti...", false).Show();
			s.BeginGetImpianti (
				(ar) => {
					Impianti[] i = s.EndGetImpianti (ar);
					List<string> ls = new List<string>();
					foreach (Impianti item in i) {
						ls.Add(item.Id+  " - " +item.Descrizione );
					}
					ArrayAdapter dati = new ArrayAdapter(this, Android.Resource.Layout.SimpleDropDownItem1Line, ls);
					RunOnUiThread(()=>{
						txtImpianto.Adapter = dati;
						dialog.Dismiss ();
						prepareWaitDialog("Carico Attivita...",false);
						s.BeginGetAttivita (
							(ar1) => {
								Attivita[] lsa = s.EndGetAttivita(ar1);
								AttivitaListAdapter datiAtt = new AttivitaListAdapter(this,lsa);
								RunOnUiThread(()=>{	lstAttivita.Adapter = datiAtt;dialog.Dismiss();});
							}, null);
					});
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

