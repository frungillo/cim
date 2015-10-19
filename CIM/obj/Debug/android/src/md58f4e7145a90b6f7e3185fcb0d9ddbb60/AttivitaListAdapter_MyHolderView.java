package md58f4e7145a90b6f7e3185fcb0d9ddbb60;


public class AttivitaListAdapter_MyHolderView
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer
{
	static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("CIM.AttivitaListAdapter/MyHolderView, CIM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", AttivitaListAdapter_MyHolderView.class, __md_methods);
	}


	public AttivitaListAdapter_MyHolderView () throws java.lang.Throwable
	{
		super ();
		if (getClass () == AttivitaListAdapter_MyHolderView.class)
			mono.android.TypeManager.Activate ("CIM.AttivitaListAdapter/MyHolderView, CIM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}

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
