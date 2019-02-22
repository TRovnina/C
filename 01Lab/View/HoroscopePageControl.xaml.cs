using System.Windows.Controls;
using _01Rovnina.ViewModels;

namespace _01Rovnina.View
{
    /// <summary>
    /// Interaction logic for ViewControl.xaml
    /// </summary>
    public partial class HoroscopePageControl : UserControl
    {
        internal HoroscopePageControl()
        {
            InitializeComponent();
            DataContext = new HoroscopePageViewModel();
        }

    }
}
