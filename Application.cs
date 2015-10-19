using System;
using Android.App;
using Android.Runtime;
using Android.Content;

namespace CIM
{
	[Application]
	public class Applicazione : Application
	{
		public static Context AppContext;

		public Applicazione(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
		{

		}

		public override void OnCreate()
		{
			base.OnCreate();

			AppContext = this.ApplicationContext;


			//This service will keep your app receiving push even when closed.              
			StartPushService();
		}

		public static void StartPushService()
		{
			AppContext.StartService(new Intent(AppContext, typeof(MyGcmListenerService)));

			if (Android.OS.Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.Kitkat)
			{

				PendingIntent pintent = PendingIntent.GetService(AppContext, 0, new Intent(AppContext, typeof(MyGcmListenerService)), 0);
				AlarmManager alarm = (AlarmManager)AppContext.GetSystemService(Context.AlarmService);
				alarm.Cancel(pintent);
			}
		}

		public static void StopPushService()
		{
			AppContext.StopService(new Intent(AppContext, typeof(MyGcmListenerService)));
			if (Android.OS.Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.Kitkat)
			{
				PendingIntent pintent = PendingIntent.GetService(AppContext, 0, new Intent(AppContext, typeof(MyGcmListenerService)), 0);
				AlarmManager alarm = (AlarmManager)AppContext.GetSystemService(Context.AlarmService);
				alarm.Cancel(pintent);
			}
		}
	}
}

