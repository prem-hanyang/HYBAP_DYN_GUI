using System;
using System.Diagnostics;
using System.Windows.Input;

namespace HYBAP
{
    /// <summary>
    /// This class is relay command.
    /// </summary>
    public class RelayCommand : ICommand
    {
        /// <summary>
        /// The delegate
        /// </summary>
        private readonly Action<object> m_execute;
        /// <summary>
        /// The delegate
        /// </summary>
        private readonly Predicate<object> m_canExecute;

        /// <summary>
        /// Initializes a new instance of the <see cref="RelayCommand"/> class.
        /// </summary>
        /// <param name="execute">the delegate</param>
        public RelayCommand(Action<object> execute)
            : this(execute, null)
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="RelayCommand"/> class.
        /// </summary>
        /// <param name="execute">the delegate</param>
        /// <param name="canExecute">the delegate</param>
        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
        {
            if (execute == null)
            {
                throw new ArgumentNullException("execute");
            }

            this.m_execute = execute;
            this.m_canExecute = canExecute;
        }
        /// <summary>
        /// The event handler
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        /// <summary>
        /// Evaluate execution
        /// </summary>
        /// <param name="parameter">the object</param>
        /// <returns>the value</returns>
        [DebuggerStepThrough]
        public bool CanExecute(object parameter)
        {
            return this.m_canExecute == null ? true : this.m_canExecute(parameter);
        }
        /// <summary>
        /// The excution function
        /// </summary>
        /// <param name="parameter">the object</param>
        public void Execute(object parameter)
        {
            this.m_execute(parameter);
        }
    }
}
