using System;

namespace Core.Attributes
{
    [AttributeUsage(AttributeTargets.Field)]
    public class AccountTypeMetaDataAttribute : Attribute
    {
        public string DisplayValue { get; private set; }

        public string UrlValue { get; private set; }

        public AccountTypeMetaDataAttribute(string displayValue, string urlValue)
        {
            DisplayValue = displayValue;
            UrlValue = urlValue;
        }
    }
}
