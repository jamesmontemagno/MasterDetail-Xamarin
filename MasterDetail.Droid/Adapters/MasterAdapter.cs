using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MasterDetail.Core.Models;

namespace MasterDetail.Droid
{

	public class MasterAdapter : BaseAdapter
	{
		private Activity activity;
    ObservableCollection<TimeEntry> items;
		public MasterAdapter(Activity activity, ObservableCollection<TimeEntry> items)
		{
			this.activity = activity;
			this.items = items;
		}

		//Wrapper class for adapter for cell re-use
		private class MasterAdapterHelper : Java.Lang.Object
		{
			public TextView Title { get; set; }
		}




		#region implemented abstract members of BaseAdapter
		public override Java.Lang.Object GetItem (int position)
		{
			return position;
		}

		public override long GetItemId (int position)
		{
			return position;
		}

		public override View GetView (int position, View convertView, ViewGroup parent)
		{
			MasterAdapterHelper helper = null;
			if (convertView == null) {
				convertView = activity.LayoutInflater.Inflate (Android.Resource.Layout.SimpleListItem1, null);
				helper = new MasterAdapterHelper ();
				helper.Title = convertView.FindViewById<TextView> (Android.Resource.Id.Text1);
				convertView.Tag = helper;
			} else {
				helper = convertView.Tag as MasterAdapterHelper;
			}

			helper.Title.Text = items [position].ToString ();

			return convertView;
		}

		public override int Count {
			get {
				return items.Count;
			}
		}
		#endregion
	}
}

