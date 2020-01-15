using System;

namespace Core.Attributes
{
    [AttributeUsage(AttributeTargets.Field)]
    public class ActivityTypeMetaDataAttribute : Attribute
    {
        public string DisplayValue { get; private set; }

        public ActivityTypeMetaDataAttribute(string displayValue)
        {
            DisplayValue = displayValue;
        }
    }
}
