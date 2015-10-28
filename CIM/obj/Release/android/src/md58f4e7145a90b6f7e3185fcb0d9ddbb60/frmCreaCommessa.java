package md58f4e7145a90b6f7e3185fcb0d9ddbb60;


public class frmCreaCommessa
	extends android.app.Activity
	implements
		mono.android.IGCUserPeer
{
	static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("CIM.frmCreaCommessa, CIM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", frmCreaCommessa.class, __md_methods);
	}


	public frmCreaCommessa () throws java.lang.Throwable
	{
		super ();
		if (getClass () == frmCreaCommessa.class)
			mono.android.TypeManager.Activate ("CIM.frmCreaCommessa, CIM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);

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
