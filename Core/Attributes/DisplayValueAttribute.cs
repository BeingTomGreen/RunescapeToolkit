using System;

namespace Core.Attributes
{
    [AttributeUsage(AttributeTargets.Field)]
    class DisplayValueAttribute : Attribute
    {
        public string DisplayValue { get; private set; }

        public DisplayValueAttribute(string displayValue)
        {
            DisplayValue = displayValue;
        }
    }
}
