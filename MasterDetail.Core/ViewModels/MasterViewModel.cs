using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Windows.Input;
using MasterDetail.Core.Models;

namespace MasterDetail.Core.ViewModels
{
  public class MasterViewModel : ViewModelBase
  {
    private ObservableCollection<TimeEntry> items = new ObservableCollection<TimeEntry>();
    public ObservableCollection<TimeEntry> Items
    {
      get { return items; }
      set { items = value;  }
    }

    private RelayCommand addCommand;

    public ICommand AddCommand
    {
      get { return addCommand ?? (addCommand = new RelayCommand(ExecuteAddCommand)); }
    }

    public void ExecuteAddCommand()
    {
      Items.Insert(0, new TimeEntry());
      OnPropertyChanged("Items");
    }

    private RelayCommand<int> deleteCommand;

    public ICommand DeleteCommand
    {
      get { return deleteCommand ?? (deleteCommand = new RelayCommand<int>(ExecuteDeleteCommand)); }
    }

    public void ExecuteDeleteCommand(int index)
    {
      Items.RemoveAt(index);
      OnPropertyChanged("Items");
    }

    private RelayCommand<int> deleteIdCommand;

    public ICommand DeleteIdCommand
    {
      get { return deleteIdCommand ?? (deleteIdCommand = new RelayCommand<int>(ExecuteDeleteIdCommand)); }
    }

    public void ExecuteDeleteIdCommand(int id)
    {
      Items.Remove(Items.FirstOrDefault(i => i.Id == id));
      OnPropertyChanged("Items");
    }

  }
}