using System;
using MasterDetail.Core.ViewModels;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace MasterDetail.Touch
{
	public partial class MasterViewController : UITableViewController
	{
	  private MasterViewModel viewModel;

	  public MasterViewModel ViewModel
	  {
      get { return viewModel ?? (viewModel = new MasterViewModel()); }
	  }

		public MasterViewController (IntPtr handle) : base (handle)
		{
			Title = NSBundle.MainBundle.LocalizedString ("Master", "Master");

			// Custom initialization
		}

		void AddNewItem (object sender, EventArgs args)
		{
			ViewModel.AddCommand.Execute(null);
			using (var indexPath = NSIndexPath.FromRowSection (0, 0))
				TableView.InsertRows (new[] { indexPath }, UITableViewRowAnimation.Automatic);
		}


		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			
			// Perform any additional setup after loading the view, typically from a nib.
			NavigationItem.LeftBarButtonItem = EditButtonItem;

			var addButton = new UIBarButtonItem (UIBarButtonSystemItem.Add, AddNewItem);
			NavigationItem.RightBarButtonItem = addButton;

			TableView.Source = new DataSource (this);
		}

		class DataSource : UITableViewSource
		{
			static readonly NSString CellIdentifier = new NSString ("Cell");
			
			readonly MasterViewController controller;

			public DataSource (MasterViewController controller)
			{
				this.controller = controller;
			}

			// Customize the number of sections in the table view.
			public override int NumberOfSections (UITableView tableView)
			{
				return 1;
			}

			public override int RowsInSection (UITableView tableview, int section)
			{
				return controller.ViewModel.Items.Count;
			}
			// Customize the appearance of table view cells.
			public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
			{
				var cell = tableView.DequeueReusableCell (CellIdentifier, indexPath);

        cell.TextLabel.Text = controller.ViewModel.Items[indexPath.Row].ToString();

				return cell;
			}

			public override bool CanEditRow (UITableView tableView, NSIndexPath indexPath)
			{
				// Return false if you do not want the specified item to be editable.
				return true;
			}

			public override void CommitEditingStyle (UITableView tableView, UITableViewCellEditingStyle editingStyle, NSIndexPath indexPath)
			{
				if (editingStyle == UITableViewCellEditingStyle.Delete) {
					// Delete the row from the data source.
          controller.ViewModel.DeleteCommand.Execute(indexPath.Row);
					controller.TableView.DeleteRows (new[] { indexPath }, UITableViewRowAnimation.Fade);
				}
			}
		}

		public override void PrepareForSegue (UIStoryboardSegue segue, NSObject sender)
		{
			if (segue.Identifier == "showDetail") {
				var indexPath = TableView.IndexPathForSelectedRow;
        var item = ViewModel.Items[indexPath.Row];

				((DetailViewController)segue.DestinationViewController).SetDetailItem (item);
			}
		}
	}
}

