using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using MasterDetail.Core.Models;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using MasterDetail.Phone.Resources;
using MasterDetail.Core.ViewModels;

namespace MasterDetail.Phone
{
  public partial class MainPage : PhoneApplicationPage
  {

    // Constructor
    public MainPage()
    {
      InitializeComponent();

      // Set the data context of the LongListSelector control to the sample data
      DataContext = App.ViewModel;

      ((ApplicationBarIconButton) ApplicationBar.Buttons[0]).Click += (sender, args) =>
      {
        App.ViewModel.AddCommand.Execute(null);
      };
    }


    // Handle selection changed on LongListSelector
    private void MainLongListSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      // If selected item is null (no selection) do nothing
      if (MainLongListSelector.SelectedItem == null)
        return;

      // Navigate to the new page
      //NavigationService.Navigate(new Uri("/DetailsPage.xaml?selectedItem=" + (MainLongListSelector.SelectedItem as ItemViewModel).ID, UriKind.Relative));

      // Reset selected item to null (no selection)
      MainLongListSelector.SelectedItem = null;
    }

    private void TextBlock_Tap(object sender, System.Windows.Input.GestureEventArgs e)
    {
		var item = ((TextBlock)sender).DataContext as TimeEntry;
    	NavigationService.Navigate(new Uri("/DetailsPage.xaml?selectedItem=" + item.Id, UriKind.Relative));

    }
  }
}