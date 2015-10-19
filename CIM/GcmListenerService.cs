using Android.App;
using Android.Content;
using Android.OS;
using Android.Gms.Gcm;
using Android.Util;
using Android.Media;

namespace CIM
{
	[Service (Exported = false), IntentFilter (new [] { "com.google.android.c2dm.intent.RECEIVE" })]
	public class MyGcmListenerService : GcmListenerService
	{
		public override void OnMessageReceived (string from, Bundle data)
		{
			MessaggioNotifica m = new MessaggioNotifica ();
			string messaggio = data.GetString ("messaggio");
			string titolo = data.GetString ("titolo"); 
			string commessa = data.GetString ("commessa");
			string tipo = data.GetString ("tipo");
			m.Titolo = titolo; m.Messaggio = messaggio; m.Commessa = commessa; m.Tipo = tipo;
			Log.Debug ("MyGcmListenerService", "Message: " + messaggio);
			SendNotification (m);
		}

		void SendNotification (MessaggioNotifica m)
		{
			var intent = new Intent (this, typeof(MainActivity));
			intent.PutExtra ("commessanum", m.Commessa);
			intent.AddFlags (ActivityFlags.ClearTop);
			var pendingIntent = PendingIntent.GetActivity (this, 0, intent, PendingIntentFlags.OneShot);

			var notifica = new Notification.Builder (this);
			switch (m.Tipo) {
			case "1":
				notifica.SetSmallIcon (Resource.Drawable.alert_1);
				break;
			case "2":
				notifica.SetSmallIcon (Resource.Drawable.alert_2);
				break;
			case "3":
				notifica.SetSmallIcon (Resource.Drawable.alert_3);
				break;
			default:
				notifica.SetSmallIcon (Resource.Drawable.InvioDoc);
				break;
			}
			notifica.SetContentTitle (m.Titolo);
			notifica.SetContentText (m.Messaggio);
			notifica.SetAutoCancel (true);
			notifica.SetContentInfo (m.Commessa);
			notifica.SetSubText ("Commessa " + m.Commessa);
			notifica.SetVibrate (new long[] {100,200,100});
			notifica.SetSound (RingtoneManager.GetDefaultUri(RingtoneType.Notification));
			notifica.SetContentIntent (pendingIntent);
			var notificationManager = (NotificationManager)GetSystemService(Context.NotificationService);
			notificationManager.Notify (0, notifica.Build());
		}


		private class MessaggioNotifica {
			public string Titolo { get; set; }
			public string Messaggio { get; set; }
			public string Commessa { get; set; }
			public string Tipo { get; set; }

			public MessaggioNotifica() {}
		}


	}



}

