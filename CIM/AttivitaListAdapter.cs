using CIM.ServiceNpk;
using System;
using Android.Widget;
using Android.App;
using Android.Views;
using Newtonsoft.Json;

namespace CIM
{
	public delegate void CheckChangeEventHandler(int pos, bool stato);
	
	public class AttivitaListAdapter : BaseAdapter<Attivita>
	{
		
		public event CheckChangeEventHandler OnCheckChange;

		private Attivita[] attivita;
		private Activity context;
		private int posizione;

		private class MyHolderView : Java.Lang.Object
		{
			public TextView txtDescrizione;
			public CheckBox chkStatoAttivita;
		}

		public AttivitaListAdapter (Activity context, Attivita[] attivita)
		{
			this.attivita = attivita;
			this.context = context;
		}

		#region implemented abstract members of BaseAdapter

		public override long GetItemId (int position)
		{
			return position;
		}

		public override View GetView (int position, View convertView, ViewGroup parent)
		{
			posizione = position;
			View view = convertView;
			MyHolderView holder = new MyHolderView ();
			if (view != null) {
				holder = view.Tag as MyHolderView;
			} else {
				view = context.LayoutInflater.Inflate (Resource.Layout.CheckedListItem, null);
				holder.txtDescrizione = view.FindViewById<TextView> (Resource.Id.txtDescrizioneChk);
				holder.chkStatoAttivita = view.FindViewById<CheckBox> (Resource.Id.chkCheckBoxChk);
				view.Tag = holder;

			}

			holder.chkStatoAttivita.Checked = attivita [position].Completata;
			if (holder.chkStatoAttivita.Checked) {
				holder.chkStatoAttivita.Enabled = false;
				holder.txtDescrizione.SetBackgroundResource (Resource.Drawable.TextBoxVerde);
			} else {
				holder.chkStatoAttivita.Enabled = true;
				holder.txtDescrizione.SetBackgroundResource (Resource.Drawable.TextBoxRossa);
			}
			holder.chkStatoAttivita.Tag = new MyWrapper<int> (position);
			holder.txtDescrizione.Text = attivita [position].Descrizione;

			holder.chkStatoAttivita.CheckedChange += Holder_chkStatoAttivita_CheckedChange;
			return view;

		}

		void Holder_chkStatoAttivita_CheckedChange (object sender, CompoundButton.CheckedChangeEventArgs e)
		{
			var chk = sender as CheckBox;
			if (OnCheckChange != null) {
				int p = ((MyWrapper<int>)chk.Tag).Value;
				OnCheckChange (p, e.IsChecked);
			}

		}

		public override int Count {
			get {
				return attivita.Length;
			}
		}

		#endregion

		#region implemented abstract members of BaseAdapter

		public override Attivita this [int index] {
			get {
				return attivita [index];
			}
		}

		#endregion
	}

	public class MyWrapper<T> : Java.Lang.Object 
	{
		private T _value;
		public MyWrapper(T managedValue)
		{
			_value = managedValue;
		}

		public T Value { get { return _value; } }
	}
}

