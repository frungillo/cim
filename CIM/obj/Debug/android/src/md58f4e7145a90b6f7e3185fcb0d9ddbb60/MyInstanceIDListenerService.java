package md58f4e7145a90b6f7e3185fcb0d9ddbb60;


public class MyInstanceIDListenerService
	extends com.google.android.gms.iid.InstanceIDListenerService
	implements
		mono.android.IGCUserPeer
{
	static final String __md_methods;
	static {
		__md_methods = 
			"n_onTokenRefresh:()V:GetOnTokenRefreshHandler\n" +
			"";
		mono.android.Runtime.register ("CIM.MyInstanceIDListenerService, CIM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", MyInstanceIDListenerService.class, __md_methods);
	}


	public MyInstanceIDListenerService () throws java.lang.Throwable
	{
		super ();
		if (getClass () == MyInstanceIDListenerService.class)
			mono.android.TypeManager.Activate ("CIM.MyInstanceIDListenerService, CIM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onTokenRefresh ()
	{
		n_onTokenRefresh ();
	}

	private native void n_onTokenRefresh ();

	java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
