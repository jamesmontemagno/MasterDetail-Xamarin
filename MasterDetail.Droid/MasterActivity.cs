using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;
using MasterDetail.Core.Models;

namespace MasterDetail.Droid
{
	[Activity (Label = "MasterDetail.Droid", MainLauncher = true)]
	public class MainActivity : ListActivity
	{
		private List<TimeEntry> objects = new List<TimeEntry>();


		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Master);


			ListAdapter = new MasterAdapter (this, objects);

			ListView.ItemLongClick += (sender, e) => {
				DeleteItem(e.Position);
			};
		}

		private void AddItem()
		{
			objects.Insert (0, new TimeEntry());
			RunOnUiThread (() => {
				((MasterAdapter)ListAdapter).NotifyDataSetChanged();
			});
		}

		private void DeleteItem(int index)
		{
			objects.RemoveAt (index);
			RunOnUiThread (() => {
				((MasterAdapter)ListAdapter).NotifyDataSetChanged();
			});
		}

		private void NavigateToDetails(int index)
		{
			var intent = new Intent (this, typeof(DetailActivity));
			intent.PutExtra ("item", objects [index].ToString ());
			StartActivity (intent);
		}

		protected override void OnListItemClick (ListView l, View v, int position, long id)
		{
			base.OnListItemClick (l, v, position, id);
			NavigateToDetails (position);
		}

		public override bool OnCreateOptionsMenu (IMenu menu)
		{
			MenuInflater.Inflate (Resource.Menu.master_menu, menu);
			return base.OnCreateOptionsMenu (menu);
		}

		public override bool OnOptionsItemSelected (IMenuItem item)
		{
			switch (item.ItemId) {
			case Resource.Id.action_add:
				AddItem ();
				return true;
			}
			return base.OnOptionsItemSelected (item);
		}

	}
}


