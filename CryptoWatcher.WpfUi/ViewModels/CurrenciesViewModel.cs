using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CryptoWatcher.Shared.Data;
using CryptoWatcher.WpfUi.Views.Pages;
using CryptoWatcher.WpfUi.Views.Windows;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Wpf.Ui.Common.Interfaces;
using Wpf.Ui.Controls;
using Wpf.Ui.Mvvm.Contracts;
using Wpf.Ui.Mvvm.Services;
using static CryptoWatcher.Shared.Data.CryptoCurrency;

namespace CryptoWatcher.WpfUi.ViewModels
{
    public partial class CurrenciesViewModel : ObservableObject, INavigationAware
    {
        private bool _isInitialized = false;

        private CryptoCurrencyService currencyService;
        private IServiceProvider serviceProvider;
        private INavigationService navigationService;

        [ObservableProperty]
        private IEnumerable<Asset> assets;
        [ObservableProperty]
        private IEnumerable<Asset> searchResults;

        [ObservableProperty]
        private Asset selectedAsset;

        [ObservableProperty]
        private string? searchQuery;

        public CurrenciesViewModel(CryptoCurrencyService currencyService,
            INavigationService navigationService,
            IServiceProvider provider
            )
        {
            this.currencyService = currencyService;
            this.navigationService = navigationService;
            serviceProvider = provider;
        }

        public void OnNavigatedFrom()
        {  
        }

        public void OnNavigatedTo()
        {
            if (!_isInitialized)
                InitializeViewModel();
        }
        /// <summary>
        /// Блястящий вин тысячилетия, я таких колёс на стаке не видел
        /// </summary>
        [RelayCommand]
        private void OnShowDetails(object asset)
        {
            if (asset == null)
                return;

            var currencyDetailsVm = serviceProvider.GetRequiredService<CurrencyDetailsViewModel>();
            currencyDetailsVm.CurrentAsset = (Asset)asset;

            var nav = (Application.Current.MainWindow as MainWindow).GetNavigation();
            nav.Navigate(typeof(CurrencyDetailsPage), asset);
        }
        [RelayCommand]
        private void OnSearchQuery(string value)
        {
            if (value == null)
                return;
            value = value.ToLower();
            SearchResults = Assets.Where(p => p.Name.ToLower() == value || p.Symbol.ToLower() == value || p.Id.ToLower() == value);
        }

        private async void InitializeViewModel()
        {
            Assets = await currencyService.GetCurrenciesAsync();
            _isInitialized = true;
        }
    }
}
