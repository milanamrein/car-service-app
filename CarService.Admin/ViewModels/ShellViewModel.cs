using Prism.Commands;
using Prism.Mvvm;
using System.Windows;

namespace CarService.Admin.ViewModels
{
    /// <summary>
    /// Shell ViewModel
    /// </summary>
    public class ShellViewModel : BindableBase
    {

        #region Private Members

        /// <summary>
        /// The window
        /// </summary>
        private Window _window;

        /// <summary>
        /// Indicates which
        /// resize window button should be shown
        /// </summary>
        private bool _showRestoreButton;

        #endregion

        #region Public Properties

        /// <summary>
        /// Property that indicates which
        /// resize window button should be shown
        /// </summary>
        public bool ShowRestoreButton
        {
            get { return this._showRestoreButton; }
            set { SetProperty(ref _showRestoreButton, value); }
        }

        /// <summary>
        /// Minimizes the Window
        /// </summary>
        public DelegateCommand MinimizeCommand { get; set; }
        
        /// <summary>
        /// Maximizes the Window
        /// </summary>
        public DelegateCommand MaximizeCommand { get; set; }

        /// <summary>
        /// Closes the Window
        /// </summary>
        public DelegateCommand CloseCommand { get; set; }

        #endregion

        #region Constructor

        public ShellViewModel(Window window)
        {
            _window = window;
            _showRestoreButton = false;

            MinimizeCommand = new DelegateCommand(() => _window.WindowState = WindowState.Minimized);
            MaximizeCommand = new DelegateCommand(() => 
            {
                _window.WindowState ^= WindowState.Maximized;
                if (_window.WindowState == WindowState.Maximized)
                    this.ShowRestoreButton = true;
                else
                    this.ShowRestoreButton = false;
            });
            CloseCommand = new DelegateCommand(() => _window.Close());

            // fixing resize bugs
            var resizer = new WindowResizer(_window);
        }

        #endregion

    }
}
