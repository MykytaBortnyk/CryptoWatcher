using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpf.Ui.Common.Interfaces;
using static CryptoWatcher.Shared.Data.CryptoCurrency;

namespace CryptoWatcher.WpfUi.ViewModels
{
    public partial class CurrencyDetailsViewModel : ObservableObject, INavigationAware
    {
        private bool _isInitialized = false;

        [ObservableProperty]
        private Asset currentAsset;
        public CurrencyDetailsViewModel(object assetValue)
        {
            currentAsset = (Asset)assetValue;
        }

        public void OnNavigatedFrom()
        {
        }

        public void OnNavigatedTo()
        {
            if (!_isInitialized)
                InitializeViewModel();
        }
        private void InitializeViewModel()
        {
            _isInitialized = true;
        }
    }
}
