namespace CryptoWatcher.Shared.Data
{
    /// <summary>
    /// <para>Represesnts all the stuff for <see href="docs.coincap.io"/></para>
    /// For real usage with multiple api should use absract class with inheritance 
    /// </summary>
    static public class CryptoCurrency
    {
        public static class Interval
        {
            public static readonly string m1 = "m1";
            public static readonly string m2 = "m2";
            public static readonly string m15 = "m15";
            public static readonly string m30 = "m30";
            public static readonly string h1 = "h1";
            public static readonly string h2 = "h2";
            public static readonly string h6 = "h6";
            public static readonly string h12 = "h12";
            public static readonly string d1 = "d1";
        }
        /// <summary>
        /// Model for <see href="docs.coincap.io"/>
        /// </summary>
        public class Asset
        {
            /// <summary>
            /// unique identifier for asset
            /// </summary>
            public String Id { get; set; }
            /// <summary>
            /// rank is in ascending order - this number is directly associated with the marketcap whereas the highest marketcap receives rank 1
            /// </summary>
            public Int32 Rank { get; set; }
            /// <summary>
            /// most common symbol used to identify this asset on an exchange
            /// </summary>
            public String Symbol { get; set; }
            /// <summary>
            /// proper name for asset
            /// </summary>
            public String Name { get; set; }
            /// <summary>
            /// available supply for trading
            /// </summary>
            public Decimal? Supply { get; set; }
            /// <summary>
            /// total quantity of asset issued
            /// </summary>
            public Decimal? MaxSupply { get; set; }
            /// <summary>
            /// supply x price
            /// </summary>
            public Decimal? MarketCapUsd { get; set; }
            /// <summary>
            /// quantity of trading volume represented in USD over the last 24 hours
            /// </summary>
            public Decimal? VolumeUsd24Hr { get; set; }
            /// <summary>
            /// volume-weighted price based on real-time market data, translated to USD
            /// </summary>
            public Decimal? PriceUsd { get; set; }
            /// <summary>
            /// the direction and value change in the last 24 hours
            /// </summary>
            public Decimal? ChangePercent24Hr { get; set; }
            /// <summary>
            /// Volume Weighted Average Price in the last 24 hours
            /// </summary>
            public Decimal? Vwap24Hr { get; set; }
            public Uri? Explorer { get; set; }
            /*public class History
            {
                /// <summary>
                /// volume-weighted price based on real-time market data, translated to USD
                /// </summary>
                public Double PriceUsd { get; set; }
                /// <summary>
                /// timestamp in UNIX in milliseconds
                /// </summary>
                public DateTime Time { get; set; }
            }*/
        }
    }
}
