using System.Windows;
using _01Rovnina.Tools;
using _01Rovnina.Tools.Manager;

namespace _01Rovnina.ViewModels
{
    internal class MainWindowViewModel : BaseViewModel, ILoader
     {
         #region Fields
         private Visibility _loaderVisibility = Visibility.Hidden;
         private bool _isControlEnabled = true;
         #endregion

        #region Properties
        public Visibility LoaderVisibility
        {
            get { return _loaderVisibility; }
            set
            {
                _loaderVisibility = value;
                OnPropertyChanged();
            }
        }

        public bool IsControlEnabled
        {
            get { return _isControlEnabled; }
            set
            {
                _isControlEnabled = value;
                OnPropertyChanged();
            }
        }
        #endregion

        internal MainWindowViewModel()
        {
            LoaderManager.Instance.Initialize(this);
        }
     }
}
