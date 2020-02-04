using System.Threading;

namespace KissU.Core.Protocol.Mqtt.Util
{
    /// <summary>
    /// MessageIdGenerater.
    /// </summary>
    public class MessageIdGenerater
    {

        private static  int _index;
        private static int _lock;
        /// <summary>
        /// Generates the identifier.
        /// </summary>
        /// <returns>System.Int32.</returns>
        public static int GenerateId()
        {
            for (; ; )
            {
                if (Interlocked.Exchange(ref _lock, 1) != 0)
                {
                    default(SpinWait).SpinOnce();
                    continue;
                }
                if (int.MaxValue > _index)
                    _index++;
                else
                    _index = 0;
          
                Interlocked.Exchange(ref _lock, 0);
                return _index;
            }
        }
    }
}
