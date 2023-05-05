namespace KissU.CPlatform.Filters
{
    /// <summary>
    /// 过滤器
    /// </summary>
    public interface IFilter
    {
        /// <summary>
        /// Gets a value indicating whether [allow multiple].
        /// </summary>
        bool AllowMultiple { get; }
    }
}