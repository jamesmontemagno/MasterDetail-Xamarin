using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace MasterDetail.Droid
{
  [Activity(Label = "DetailActivity", Theme = "@style/android:Theme.Holo.Light")]			
	public class DetailActivity : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.Detail);


			var detailText = Intent.GetStringExtra ("item");

			var detailTextView = FindViewById<TextView> (Resource.Id.item_text);
			detailTextView.Text = detailText;
		}
	}
}

