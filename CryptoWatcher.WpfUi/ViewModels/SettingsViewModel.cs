using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.Localization;
using CryptoWatcher.WpfUi.Views.Windows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;
using Wpf.Ui.Common.Interfaces;
using System.Resources;
using System.ComponentModel.DataAnnotations;
using System.Collections;
using System.Threading;
using System.Security.Cryptography.X509Certificates;

namespace CryptoWatcher.WpfUi.ViewModels
{
    public partial class SettingsViewModel : ObservableObject, INavigationAware
    {
        private bool _isInitialized = false;

        [ObservableProperty]
        private string _appVersion = String.Empty;

        [ObservableProperty]
        private Wpf.Ui.Appearance.ThemeType _currentTheme = Wpf.Ui.Appearance.ThemeType.Unknown;

        private CultureInfo _currentCultureInfo = System.Threading.Thread.CurrentThread.CurrentUICulture;

        [ObservableProperty]
        private string currentLanguage = System.Threading.Thread.CurrentThread.CurrentUICulture.NativeName;

        public static event CultureChangedHandler? CurrentCultureChanged;
        public delegate void CultureChangedHandler(string value);
        public ObservableCollection<CultureInfo> SupportedLanguages { get; } = new ObservableCollection<CultureInfo>
        {
            new("en-US", false),
            new("uk-UA", false)
        };
        public void OnNavigatedTo()
        {
            if (!_isInitialized)
                InitializeViewModel();
        }

        public void OnNavigatedFrom()
        {
        }

        private void InitializeViewModel()
        {
            CurrentTheme = Wpf.Ui.Appearance.Theme.GetAppTheme();
            AppVersion = $"CryptoWatcher.WpfUi - {GetAssemblyVersion()}";

            _isInitialized = true;
        }

        private string GetAssemblyVersion()
        {
            return System.Reflection.Assembly.GetExecutingAssembly().GetName().Version?.ToString() ?? String.Empty;
        }

        [RelayCommand]
        private void OnChangeTheme(string parameter)
        {
            switch (parameter)
            {
                case "theme_light":
                    if (CurrentTheme == Wpf.Ui.Appearance.ThemeType.Light)
                        break;

                    Wpf.Ui.Appearance.Theme.Apply(Wpf.Ui.Appearance.ThemeType.Light);
                    CurrentTheme = Wpf.Ui.Appearance.ThemeType.Light;

                    break;

                default:
                    if (CurrentTheme == Wpf.Ui.Appearance.ThemeType.Dark)
                        break;

                    Wpf.Ui.Appearance.Theme.Apply(Wpf.Ui.Appearance.ThemeType.Dark);
                    CurrentTheme = Wpf.Ui.Appearance.ThemeType.Dark;

                    break;
            }
        }
        partial void OnCurrentLanguageChanged(String value)
        {
            CurrentCultureChanged?.Invoke(value);
        }
    }
}
