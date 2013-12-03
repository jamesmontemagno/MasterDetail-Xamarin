using Android.App;
using Android.Content;
using Android.Views;
using Android.Widget;
using Android.OS;
using MasterDetail.Core.ViewModels;

namespace MasterDetail.Droid
{
  [Activity(Label = "MasterDetail.Droid", MainLauncher = true, Theme = "@style/android:Theme.Holo.Light")]
	public class MainActivity : ListActivity
	{
	  private static MasterViewModel viewModel;

	  public static MasterViewModel ViewModel
	  {
      get { return viewModel ?? (viewModel = new MasterViewModel()); }
	  }


		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Master);


      ListAdapter = new MasterAdapter(this, ViewModel.Items);

			ListView.ItemLongClick += (sender, e) => {
				ViewModel.DeleteCommand.Execute(e.Position);
        ((MasterAdapter)ListAdapter).NotifyDataSetChanged();
			};
		}

		private void NavigateToDetails(int index)
		{
			var intent = new Intent (this, typeof(DetailActivity));
			intent.PutExtra ("item", ViewModel.Items[index].ToString ());
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
				ViewModel.AddCommand.Execute(null);
        ((MasterAdapter)ListAdapter).NotifyDataSetChanged();
				return true;
			}
			return base.OnOptionsItemSelected (item);
		}

	}
}


