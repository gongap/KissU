namespace KissU.Core.System.MongoProvider
{
    /// <summary>
    /// QueryParams.
    /// </summary>
    public class QueryParams
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="QueryParams" /> class.
        /// </summary>
        public QueryParams()
        {
            Index = 1;
            Size = 15;
        }

        /// <summary>
        /// Gets or sets the total.
        /// </summary>
        public int Total { get; set; }

        /// <summary>
        /// Gets or sets the index.
        /// </summary>
        public int Index { get; set; }

        /// <summary>
        /// Gets or sets the size.
        /// </summary>
        public int Size { get; set; }
    }

    /// <summary>
    /// QueryParams.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class QueryParams<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="QueryParams{T}" /> class.
        /// </summary>
        public QueryParams()
        {
            Index = 1;
            Size = 15;
        }

        /// <summary>
        /// Gets or sets the total.
        /// </summary>
        public int Total { get; set; }

        /// <summary>
        /// Gets or sets the parameters.
        /// </summary>
        public T Params { get; set; }

        /// <summary>
        /// Gets or sets the index.
        /// </summary>
        public int Index { get; set; }

        /// <summary>
        /// Gets or sets the size.
        /// </summary>
        public int Size { get; set; }
    }
}