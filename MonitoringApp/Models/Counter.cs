namespace MonitoringApp.Models
{
    public class Counter
    {
        public int Less10Mb { get; set; }
        public int From10MbTo50Mb { get; set; }
        public int More100Mb { get; set; }

        public static Counter operator +(Counter c1, Counter c2)
        {
            return new Counter
            {
                Less10Mb = c1.Less10Mb + c2.Less10Mb,
                From10MbTo50Mb = c1.From10MbTo50Mb + c2.From10MbTo50Mb,
                More100Mb = c1.More100Mb + c2.More100Mb
            };
        }

        public static Counter operator -(Counter c1, Counter c2)
        {
            return new Counter
            {
                Less10Mb = c1.Less10Mb - c2.Less10Mb,
                From10MbTo50Mb = c1.From10MbTo50Mb - c2.From10MbTo50Mb,
                More100Mb = c1.More100Mb - c2.More100Mb
            };
        }
    }
}