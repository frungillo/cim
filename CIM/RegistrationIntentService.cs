using System;
using Android.App;
using Android.Content;
using Android.Util;
using Android.Gms.Gcm;
using Android.Gms.Gcm.Iid;
using CIM.ServiceNpk;

namespace CIM
{

	[Service(Exported = false)]
	class RegistrationIntentService : IntentService
	{
		public static String Ute;
		static object locker = new object();

		public RegistrationIntentService() : base("RegistrationIntentService") { }

		protected override void OnHandleIntent (Intent intent)
		{
			try
			{
				Log.Info ("RegistrationIntentService", "Calling InstanceID.GetToken");
				lock (locker)
				{
					ServiceControlloImpianti s = new ServiceControlloImpianti();

					Ute =intent.GetStringExtra("Ute");
					var instanceID = InstanceID.GetInstance (this);
					var token = instanceID.GetToken ("162590404769",
						GoogleCloudMessaging.InstanceIdScope, null);
					if(!s.RegisterDeviceID(token,Ute)) {
						Log.Info("GennyFrungilloLog", "Non registrato al servizio");
					}else {
						Log.Info("GennyFrungilloLog", "Registrato al servizio");
					}
					Log.Info ("RegistrationIntentService", "GCM Registration Token: " + token);
					SendRegistrationToAppServer (token);
					Subscribe (token);
				}
			}
			catch (Exception e)
			{
				Log.Debug("RegistrationIntentService", "Failed to get a registration token:"+e.Message.ToString());
				return;
			}
		}

		void SendRegistrationToAppServer (string token)
		{
			// Add custom implementation here as needed.
		}

		void Subscribe (string token)
		{
			var pubSub = GcmPubSub.GetInstance(this);
			pubSub.Subscribe(token, "/topics/global", null);
		}
	}
}

