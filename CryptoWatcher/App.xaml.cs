using CryptoWatcher.Shared.Data;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace CryptoWatcher
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private ServiceProvider serviceProvider;
        #region localization
        public static event EventHandler LanguageChanged;
        private static List<CultureInfo> m_Languages = new List<CultureInfo>();
        public static List<CultureInfo> Languages => m_Languages;
        public static CultureInfo Language
        {
            get => Thread.CurrentThread.CurrentUICulture;
            set
            {
                if (value == null) throw new ArgumentNullException("value"); //Culture may not be null
                if (value == Thread.CurrentThread.CurrentUICulture) return; //Do nothing of current culter alredy equal

                Thread.CurrentThread.CurrentUICulture = value; //Changing app culture

                ResourceDictionary dictionary = new();
                switch (value.Name)
                {
                    case "uk":
                        dictionary.Source = new(String.Format("Resources/lang.{0}.xaml", value.Name), UriKind.Relative);
                        break;
                    default:
                        dictionary.Source = new Uri("Resources/lang.xaml", UriKind.Relative);
                        break;
                }

                ResourceDictionary oldCultire = Current.Resources.MergedDictionaries
                    .First(d => 
                    d.Source != null &&
                    d.Source.OriginalString.StartsWith("Resources/lang."));

                if (oldCultire != null)
                {
                    int id = Current.Resources.MergedDictionaries.IndexOf(oldCultire);
                    Current.Resources.MergedDictionaries.Remove(oldCultire);
                    Current.Resources.MergedDictionaries.Insert(id, oldCultire);
                }
                else Current.Resources.MergedDictionaries.Add(dictionary);

                LanguageChanged(Current, new EventArgs());
            }
        }
        private void App_LanguageChanged(Object sender, EventArgs e)
        {
            CryptoWatcher.Properties.Settings.Default.DefaultLanguage = Language;
            CryptoWatcher.Properties.Settings.Default.Save();
        }
        #endregion
        public App()
        {
            ServiceCollection services = new();
            ConfigureServices(services);
            serviceProvider = services.BuildServiceProvider();

            App.LanguageChanged += App_LanguageChanged;

            m_Languages.Clear();
            m_Languages.Add(new CultureInfo("en-US")); //Нейтральная культура для этого проекта
            m_Languages.Add(new CultureInfo("uk"));

            Language = CryptoWatcher.Properties.Settings.Default.DefaultLanguage;
        }
        private void ConfigureServices(ServiceCollection services)
        {
            services.AddSingleton<CryptoCurrencyService>();
        }
        private void OnStartup(object sender, StartupEventArgs e)
        {
            var mainWindow = serviceProvider.GetService<MainWindow>();
            mainWindow.Show();
        }
    }
}
