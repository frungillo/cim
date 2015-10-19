
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CIM.ServiceNpk;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;

namespace CIM
{
	[Activity (Label = "frmDettagliCommesse", Theme = "@android:style/Theme.DeviceDefault.Light.NoActionBar")]			
	public class frmDettagliCommesse : Activity
	{
		Commesse commessa;
		Attivita[] ls;
		TextView txtIdDescrizione, txtDataCommessa, txtDataLimite, txtDataChiusura, txtImpianto,
					txtRichiedente, txtSquadreInteressate, txtStatoCommessa;
		ListView lstAttivita;
		Button btnSalvaStato;
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.frmDettagliCommesse);
			txtIdDescrizione = FindViewById<TextView> (Resource.Id.txtIdDescrizione);
			txtDataCommessa = FindViewById<TextView> (Resource.Id.txtDataCommessa);
			txtDataLimite = FindViewById<TextView> (Resource.Id.txtDataLimite);
			txtDataChiusura = FindViewById<TextView> (Resource.Id.txtDataChiusura);
			txtImpianto = FindViewById<TextView> (Resource.Id.txtImpianto);
			txtRichiedente = FindViewById<TextView> (Resource.Id.txtRichiedente);
			txtSquadreInteressate = FindViewById<TextView> (Resource.Id.txtSquadreInteressate);
			txtStatoCommessa= FindViewById<TextView> (Resource.Id.txtStatoCommessa);
			lstAttivita = FindViewById<ListView> (Resource.Id.lstAttivita);
			btnSalvaStato = FindViewById<Button> (Resource.Id.btnSalvaCommessa);

			btnSalvaStato.Click+= BtnSalvaStato_Click;

			commessa = JsonConvert.DeserializeObject<Commesse>(Intent.GetStringExtra("commessa"));

			txtIdDescrizione.Text = "[Num: " + commessa.Id + "] --> " +  commessa.Descrizione;
			txtDataCommessa.Text = "Del: " + commessa.DataCreazione.Day.ToString ().PadLeft (2, char.Parse("0")) +
				"/" + commessa.DataCreazione.Month.ToString ().PadLeft (2, char.Parse("0")) +
			"/" + commessa.DataCreazione.Year.ToString ().Substring (2);
			txtDataLimite.Text = "Scad.: "+ commessa.DataLimite.Day.ToString ().PadLeft (2, char.Parse("0")) +
				"/" + commessa.DataLimite.Month.ToString ().PadLeft (2, char.Parse("0")) +
				"/" + commessa.DataLimite.Year.ToString ().Substring (2);

			if (commessa.DataChiusura.ToShortDateString ().Contains ("01/01/0001")) {
				txtDataChiusura.Text = "Chiusa: No";
				txtDataChiusura.Background = Resources.GetDrawable (Resource.Drawable.TextBoxRossa);
			} else {
				txtDataChiusura.Text = "Chiusa:" + commessa.DataChiusura.Day.ToString ().PadLeft (2,char.Parse("0")) +
					"/" + commessa.DataChiusura.Month.ToString ().PadLeft (2, char.Parse("0")) +
					"/" + commessa.DataChiusura.Year.ToString ().Substring (2);


				txtDataChiusura.Background = Resources.GetDrawable (Resource.Drawable.TextBoxVerde);
			}
			txtImpianto.Text = "Impianto: " + commessa.Impianto.Localizzazione + " [" + commessa.Impianto.Descrizione + "]";
			txtRichiedente.Text = "Richiesta da :" + commessa.Richiedente;
			txtSquadreInteressate.Text = " --- Squadre: ";
			foreach (Squadre sq	in commessa.Squadre) {
				txtSquadreInteressate.Text += "[" + sq.Id + "] ";
			}
			txtStatoCommessa.Text = "Stato: "+commessa.Stato.ToString () + " ---- Tipo: "+ commessa.Tipo.ToString();

			//ServiceNpk.ServiceControlloImpianti s = new ServiceControlloImpianti ();
		

			ls = commessa.Lavori;
			AttivitaListAdapter datiLista = new AttivitaListAdapter (this, ls);
			lstAttivita.Adapter = datiLista;
			datiLista.OnCheckChange+= (int pos, bool stato) => {
				ls[pos].Completata = stato;
				commessa.Lavori = ls;
			};
	
		}

		void BtnSalvaStato_Click (object sender, EventArgs e)
		{
			ServiceControlloImpianti s = new ServiceControlloImpianti ();
			s.BeginSalvaStatoAttivitaCommessa (commessa, (ar) => {
				bool esito = s.EndSalvaStatoAttivitaCommessa(ar);
				if(esito) {
					RunOnUiThread(()=>{	Toast.MakeText(this, "Stato salvato correttamente...", ToastLength.Long).Show();});
				} else {
					RunOnUiThread(()=>{	Toast.MakeText(this, "ERRORE SALVATAGGIO STATO", ToastLength.Long).Show();});
				}
			}, null);
		}

	


	}
}

