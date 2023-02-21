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
        private Asset _currentAsset;

        public void OnNavigatedFrom()
        {
            throw new NotImplementedException();
        }

        public void OnNavigatedTo()
        {
            throw new NotImplementedException();
        }
        private void InitializeViewModel()
        {
            _isInitialized = true;
        }
    }
}
