using CIM.ServiceNpk;
using System;
using Android.Widget;
using Android.App;
using Android.Views;

namespace CIM
{
	public class CommesseListAdapter : BaseAdapter<Commesse>
	{
		Commesse[] commesse;
		Activity context;

		public CommesseListAdapter (Activity context, Commesse[] commesse) : base()
		{
			this.context = context;
			this.commesse = commesse;
		}

		public override long GetItemId (int position)
		{
			return position;
		}
		public override int Count {
			get { return commesse.Length; }
		}
		public override Android.Views.View GetView (int position, Android.Views.View convertView, Android.Views.ViewGroup parent)
		{
			View view = convertView;
			if (view == null) 
				view = context.LayoutInflater.Inflate (Android.Resource.Layout.SimpleListItem1, null);
			view.FindViewById<TextView> (Android.Resource.Id.Text1).Text = commesse [position].Descrizione;
			return view;
			
		}

		#region implemented abstract members of BaseAdapter

		public override Commesse this [int index] {
			get {
				return commesse[index];
			}
		}

		#endregion
	}
}

