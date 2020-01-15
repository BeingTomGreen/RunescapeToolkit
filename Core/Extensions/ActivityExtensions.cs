using Core.Attributes;
using Core.Enums;

namespace Core.Extensions
{
    public static class ActivityExtensions
    {
        public static string DisplayValue(this ActivityName accountType)
        {
            return accountType.GetAttribute<ActivityTypeMetaDataAttribute>().DisplayValue;
        }
    }
}
