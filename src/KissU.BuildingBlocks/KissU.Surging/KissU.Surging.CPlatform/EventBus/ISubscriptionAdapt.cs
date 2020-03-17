namespace KissU.Surging.CPlatform.EventBus
{
    /// <summary>
    /// 订阅适应器
    /// </summary>
    public interface ISubscriptionAdapt
    {
        /// <summary>
        /// 订阅.
        /// </summary>
        void SubscribeAt();

        /// <summary>
        /// 退订.
        /// </summary>
        void Unsubscribe();
    }
}