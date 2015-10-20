
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

namespace CIM
{
	[Activity (Label = "frmLeggiMessaggi")]			
	public class frmLeggiMessaggi : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.frmLeggiMessaggi);
			//TextView txtMittente = FindViewById<TextView>(Resource.Id.txtDataChiusura////
			// Create your application here
		}
	}
}

