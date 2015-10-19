package md58f4e7145a90b6f7e3185fcb0d9ddbb60;


public class MyWrapper_1
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer
{
	static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("CIM.MyWrapper`1, CIM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", MyWrapper_1.class, __md_methods);
	}


	public MyWrapper_1 () throws java.lang.Throwable
	{
		super ();
		if (getClass () == MyWrapper_1.class)
			mono.android.TypeManager.Activate ("CIM.MyWrapper`1, CIM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
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
