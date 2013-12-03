using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using MasterDetail.Phone.Resources;

namespace MasterDetail.Phone
{
  public partial class DetailsPage : PhoneApplicationPage
  {
    // Constructor
    public DetailsPage()
    {
      InitializeComponent();
    }

    // When page is navigated to set data context to selected item in list
    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
      if (DataContext == null)
      {
        string selectedId = "";
        if (NavigationContext.QueryString.TryGetValue("selectedItem", out selectedId))
        {
          int id = int.Parse(selectedId);
          DataContext = App.ViewModel.Items.FirstOrDefault(i =>i.Id == id);
        }
      }
    }

    
  }
}