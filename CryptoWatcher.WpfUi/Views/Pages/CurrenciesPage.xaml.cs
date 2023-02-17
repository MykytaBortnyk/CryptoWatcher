using CryptoWatcher.Shared.Data;
using CryptoWatcher.WpfUi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Wpf.Ui.Common.Interfaces;

namespace CryptoWatcher.WpfUi.Views.Pages
{
    /// <summary>
    /// Interaction logic for CurrenciesPage.xaml
    /// </summary>
    public partial class CurrenciesPage : INavigableView<ViewModels.CurrenciesViewModel>
    {
        private CryptoCurrencyService _currencyService;
        public CurrenciesViewModel ViewModel { get; }
        public CurrenciesPage(CryptoCurrencyService currencyService)
        {
            InitializeComponent();
            _currencyService = currencyService;
            GetCurrencies();
        }

        private async void GetCurrencies()
        {
            CurrenciesDg.ItemsSource = await _currencyService.GetCurrenciesAsync();
        }
    }
}
