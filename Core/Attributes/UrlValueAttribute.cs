using System;

namespace Core.Attributes
{
    [AttributeUsage(AttributeTargets.Field)]
    class UrlValueAttribute : Attribute
    {
        public string UrlValue { get; private set; }

        public UrlValueAttribute(string urlValue)
        {
            UrlValue = urlValue;
        }
    }
}
