namespace CryptoWatcher.Shared.Data
{
    /// <summary>
    /// Represents interface of service for working with external API
    /// </summary>
    internal interface ICryptoCurrencyService<T>
    {
        public Task<List<T>> GetCurrenciesAsync();
        public Task<T> GetCurrencyAsync(string currencyId);
    }
}