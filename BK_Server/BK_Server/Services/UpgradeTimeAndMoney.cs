using Org.BouncyCastle.Asn1.Cms;
using System.Linq.Expressions;

namespace BK_Server.Services
{
    public class UpgradeTimeAndMoney
    {
        private static Tuple<double, TimeSpan> timeAndMoney;
        private static TimeSpan time;
        private static double money;

        public static short calculateMoney(sbyte attributeLevel, sbyte gymLevel)
        {
            return (short)(20 + (attributeLevel * 3) - (gymLevel * 1.5));
        }

        public static DateTime calculateTime(sbyte attributeLevel, sbyte gymLevel)
        {
            return DateTime.Now + TimeSpan.FromSeconds(1 + (attributeLevel * 5) - (gymLevel * 2));
        }
    }
}