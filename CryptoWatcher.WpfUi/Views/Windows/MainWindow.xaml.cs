using CryptoWatcher.WpfUi.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using Wpf.Ui.Controls.Interfaces;
using Wpf.Ui.Mvvm.Contracts;

namespace CryptoWatcher.WpfUi.Views.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : INavigationWindow
    {
        public ViewModels.MainWindowViewModel ViewModel
        {
            get;
        }

        public MainWindow(ViewModels.MainWindowViewModel viewModel, IPageService pageService, INavigationService navigationService)
        {
            ViewModel = viewModel;
            DataContext = this;

            InitializeComponent();
            SetPageService(pageService);

            navigationService.SetNavigationControl(RootNavigation);

            SettingsViewModel.CurrentCultureChanged += OnCultureChanged;
        }

        #region INavigationWindow methods

        public Frame GetFrame()
            => RootFrame;

        public INavigation GetNavigation()
            => RootNavigation;

        public bool Navigate(Type pageType)
            => RootNavigation.Navigate(pageType);

        public void SetPageService(IPageService pageService)
            => RootNavigation.PageService = pageService;

        public void ShowWindow()
            => Show();  

        public void CloseWindow()
            => Close();

        #endregion INavigationWindow methods

        /// <summary>
        /// Raises the closed event.
        /// </summary>
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            // Make sure that closing this window will begin the process of closing the application.
            Application.Current.Shutdown();
        }
        //by ChatGPR
        private void OnCultureChanged(string value)
        {
            CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo(value);
            CultureInfo.CurrentUICulture = CultureInfo.GetCultureInfo(value);
            var xmlLanguage = XmlLanguage.GetLanguage(CultureInfo.CurrentCulture.Name);
            RootNavigation.Language = xmlLanguage;
            RootMainGrid.Language = xmlLanguage;
            RootNavigation.Language = xmlLanguage;
        }
    }
}