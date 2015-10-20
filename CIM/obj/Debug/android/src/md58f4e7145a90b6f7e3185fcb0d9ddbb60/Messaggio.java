package md58f4e7145a90b6f7e3185fcb0d9ddbb60;


public class Messaggio
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		java.io.Serializable
{
	static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("CIM.Messaggio, CIM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", Messaggio.class, __md_methods);
	}


	public Messaggio () throws java.lang.Throwable
	{
		super ();
		if (getClass () == Messaggio.class)
			mono.android.TypeManager.Activate ("CIM.Messaggio, CIM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}

	public Messaggio (java.lang.String p0, java.lang.String p1) throws java.lang.Throwable
	{
		super ();
		if (getClass () == Messaggio.class)
			mono.android.TypeManager.Activate ("CIM.Messaggio, CIM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "System.String, mscorlib, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e:System.String, mscorlib, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e", this, new java.lang.Object[] { p0, p1 });
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
