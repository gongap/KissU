using System.Threading;

namespace KissU.Util.Threading.Threading
{
    public interface ICancellationTokenProvider
    {
        CancellationToken Token { get; }
    }
}
