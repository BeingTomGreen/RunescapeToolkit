using Core.Attributes;
using Core.Enums;

namespace Core.Extensions
{
    public static class AccountTypeExtensions
    {
        public static string DisplayValue(this AccountType accountType)
        {
            return accountType.GetAttribute<DisplayValueAttribute>().DisplayValue;
        }

        public static string UrlValue(this AccountType accountType)
        {
            return accountType.GetAttribute<UrlValueAttribute>().UrlValue;
        }
    }
}
