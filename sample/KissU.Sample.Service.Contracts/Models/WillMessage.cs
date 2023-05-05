namespace KissU.Msm.Sample.Service.Contracts.Models
{
    public class WillMessage
    {
        public string Topic { get; set; }

        public string Message { get; set; }

        public bool WillRetain { get; set; }

        public int Qos { get; set; }
    }
}
