using System.Windows.Input;
using System;


// RelayCommand is a basic implementation of the ICommand interface.
// It is used to create commands in MVVM applications without having to create a new command class for each action.

public class RelayCommand : ICommand
{
    // Fields to hold the execute action and the can execute predicate.
    private readonly Action<object> _execute;
    private readonly Predicate<object> _canExecute;

  
    // Initializes a new instance of the RelayCommand class.

    public RelayCommand(Action<object> execute, Predicate<object> canExecute = null)
    {
        // Throws an exception if the execute action is null.
        _execute = execute ?? throw new ArgumentNullException(nameof(execute));
        _canExecute = canExecute;
    }

   
    // Event that is raised when the command's ability to execute has changed.
  
    public event EventHandler CanExecuteChanged
    {
        // Adds or removes the event handler to the CommandManager's RequerySuggested event.
        // This ensures that CanExecute is queried again if something in the application changes.
        add => CommandManager.RequerySuggested += value;
        remove => CommandManager.RequerySuggested -= value;
    }

  
    // Method to trigger a reevaluation of the CanExecute method to determine if the command can execute.
   
    public void NotifyCanExecuteChanged()
    {
        // Invalidate the CommandManager's cache, causing it to requery the CanExecute methods.
        CommandManager.InvalidateRequerySuggested();
    }

  
    // Determines whether the command can be executed.
   

    public bool CanExecute(object parameter) => _canExecute?.Invoke(parameter) ?? true;

   
    // Executes the RelayCommand on the current command target.
   
   
    public void Execute(object parameter) => _execute(parameter);
}
