namespace CryptoWatcher.Shared.Data
{
    /// <summary>
    /// Represents interface of service for working with external API
    /// </summary>
    internal interface ICryptoCurrencyService<T>
    {
        public Task<List<T>> GetCurrencies();
        public Task<T> GetCurrency(string currencyId);
    }
}