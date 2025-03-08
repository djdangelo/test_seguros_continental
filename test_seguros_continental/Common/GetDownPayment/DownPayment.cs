namespace test_seguros_continental.Common.GetDownPayment
{
    public class DownPayment
    {
        public static double GetDownPayment(double rate, double total)
        {
            return rate * total;
        }
    }
}
