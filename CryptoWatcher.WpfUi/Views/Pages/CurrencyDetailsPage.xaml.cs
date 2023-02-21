using CryptoWatcher.WpfUi.ViewModels;
using Wpf.Ui.Common.Interfaces;
using System;
using static CryptoWatcher.Shared.Data.CryptoCurrency;

namespace CryptoWatcher.WpfUi.Views.Pages
{
    /// <summary>
    /// Interaction logic for CurrencyPage.xaml
    /// </summary>
    public partial class CurrencyDetailsPage : INavigableView<ViewModels.CurrencyDetailsViewModel>
    {
        public CurrencyDetailsPage(CurrencyDetailsViewModel viewModel)
        {
            ViewModel= viewModel;
            InitializeComponent();
        }

        public CurrencyDetailsViewModel ViewModel
        {
            get;
        }
    }
}
