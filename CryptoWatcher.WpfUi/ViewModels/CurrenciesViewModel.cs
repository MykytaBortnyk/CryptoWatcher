using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CryptoWatcher.Shared.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpf.Ui.Common.Interfaces;
using static CryptoWatcher.Shared.Data.CryptoCurrency;

namespace CryptoWatcher.WpfUi.ViewModels
{
    public partial class CurrenciesViewModel : ObservableObject, INavigationAware
    {
        private bool _isInitialized = false;

        private CryptoCurrencyService currencyService;

        [ObservableProperty]
        private IEnumerable<Asset> assets;

        [ObservableProperty]
        private Asset selectedAsset;

        public CurrenciesViewModel(CryptoCurrencyService currencyService)
        {
            this.currencyService = currencyService;
        }

        public void OnNavigatedFrom()
        {  
        }

        public void OnNavigatedTo()
        {
            if (!_isInitialized)
                InitializeViewModel();
        }

        [RelayCommand]
        private void OnShowDetails()
        {

        }

        private async void InitializeViewModel()
        {
            Assets = await currencyService.GetCurrenciesAsync();
            _isInitialized = true;
        }
    }
}
