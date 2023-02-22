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
using System.Windows.Markup;
using System.Threading;
using System.Text.RegularExpressions;

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
        // by ChatGPT
        partial void OnCurrentLanguageChanged(String value)
        {
            var dictionary = new ResourceDictionary();
            var uri = new Uri($"pack://application:,,,/Properties/Resources.{value}.xaml");
            dictionary.Source = uri;
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(value);
            // Find the language dictionary to remove
            var dictionariesToRemove = new List<ResourceDictionary>();
            foreach (var mergedDictionary in Application.Current.Resources.MergedDictionaries)
            {
                if (mergedDictionary.GetType() == dictionary.GetType())
                {
                    dictionariesToRemove.Add(mergedDictionary);
                }
            }

            // Remove the language dictionary
            foreach (var dictionaryToRemove in dictionariesToRemove)
            {
                Application.Current.Resources.MergedDictionaries.Remove(dictionaryToRemove);
            }

            // Add the new language dictionary
            Application.Current.Resources.MergedDictionaries.Add(dictionary);
        }
    }
}
