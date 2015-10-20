
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
using Newtonsoft.Json;

namespace CIM
{
	[Activity (Label = "frmLeggiMessaggi", NoHistory=true, Theme = "@android:style/Theme.Holo.Light.Dialog.MinWidth")]			
	public class frmLeggiMessaggi : Activity
	{
		
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.frmLeggiMessaggi);
			TextView txtMittente = FindViewById<TextView> (Resource.Id.txtMittenteMessaggio);
			TextView txtMessaggio = FindViewById<TextView> (Resource.Id.txtTestoMessaggio);

			Messaggio m = JsonConvert.DeserializeObject<Messaggio>(Intent.GetStringExtra ("messaggio"));

			txtMessaggio.Text = m.TestoMessaggio;
			txtMittente.Text = m.Mittente;


		}
	}


}

