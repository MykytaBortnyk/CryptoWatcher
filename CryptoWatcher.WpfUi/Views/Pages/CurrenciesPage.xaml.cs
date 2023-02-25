using CryptoWatcher.Shared.Data;
using CryptoWatcher.WpfUi.ViewModels;
using System.Windows.Input;
using System.Windows.Navigation;
using Wpf.Ui.Common.Interfaces;
using System.Linq;
using static CryptoWatcher.Shared.Data.CryptoCurrency;
using System.Collections.Generic;
using Wpf.Ui.Controls;

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
            suggestBox.QuerySubmitted += AutoSuggestBox_QuerySubmitted;
        }

        private void AutoSuggestBox_QuerySubmitted(object sender, System.Windows.RoutedEventArgs e)
        {

        }

        private void AutoSuggestBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            //var items = CurrenciesDg.ItemsSource.Cast<Asset>().ToList();
            //suggestBox.ItemsSource = items.Where(i => i.Id.ToLower() == (sender as AutoSuggestBox).Text);
        }
    }
}
