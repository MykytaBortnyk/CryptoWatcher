using CryptoWatcher.Shared.Data;
using CryptoWatcher.WpfUi.ViewModels;
using System.Windows.Input;
using System.Windows.Navigation;
using Wpf.Ui.Common.Interfaces;
using static CryptoWatcher.Shared.Data.CryptoCurrency;

namespace CryptoWatcher.WpfUi.Views.Pages
{
    /// <summary>
    /// Interaction logic for CurrenciesPage.xaml
    /// </summary>
    public partial class CurrenciesPage : INavigableView<ViewModels.CurrenciesViewModel>
    {
        public CurrenciesViewModel ViewModel { get; }
        public CurrenciesPage(ViewModels.CurrenciesViewModel viewModel)
        {
            ViewModel = viewModel;

            InitializeComponent();
        }
    }
}
