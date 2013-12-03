using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace MasterDetail.Core.ViewModels
{

  public class RelayCommand : ICommand
  {
    private readonly Action handler;
    private bool isEnabled;
    private readonly Func<object, bool> canExecute;

    public RelayCommand(Action handler, Func<object, bool> canExecute = null)
    {
      this.handler = handler;
      this.canExecute = canExecute;
      if (canExecute == null)
        isEnabled = true;
    }

    public bool IsEnabled
    {
      get { return isEnabled; }
      set
      {
        if (value != isEnabled)
        {
          isEnabled = value;
          if (CanExecuteChanged != null)
          {
            CanExecuteChanged(this, EventArgs.Empty);
          }
        }
      }
    }

    public bool CanExecute(object parameter)
    {
      if(canExecute != null)
        IsEnabled = canExecute(parameter);

      return IsEnabled;
    }

    public event EventHandler CanExecuteChanged;

    public void Execute(object parameter)
    {
      handler();
    }
  }

  public class RelayCommand<T> : ICommand
  {
    private readonly Action<T> handler;
    private bool isEnabled = true;

    private readonly Func<T, bool> canExecute;

    public RelayCommand(Action<T> handler, Func<T, bool> canExecute = null)
    {
      this.handler = handler;
      this.canExecute = canExecute;
      if (canExecute == null)
        isEnabled = true;
    }

    public bool IsEnabled
    {
      get { return isEnabled; }
      set
      {
        if (value != isEnabled)
        {
          isEnabled = value;
          if (CanExecuteChanged != null)
          {
            CanExecuteChanged(this, EventArgs.Empty);
          }
        }
      }
    }

    public bool CanExecute(object parameter)
    {
      if (canExecute != null)
        IsEnabled = canExecute((T)parameter);

      return IsEnabled;
    }

    public event EventHandler CanExecuteChanged;

    public void Execute(object parameter)
    {
      handler((T)parameter);
    }
  }
}
