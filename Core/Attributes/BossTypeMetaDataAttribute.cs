using System;

namespace Core.Attributes
{
    [AttributeUsage(AttributeTargets.Field)]
    public class BossTypeMetaDataAttribute : Attribute
    {
        public string DisplayValue { get; private set; }

        public BossTypeMetaDataAttribute(string displayValue)
        {
            DisplayValue = displayValue;
        }
    }
}