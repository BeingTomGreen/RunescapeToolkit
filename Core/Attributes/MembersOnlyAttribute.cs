using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Attributes
{
    [AttributeUsage(AttributeTargets.Field)]
    class MembersOnlyAttribute : Attribute
    {
        public bool MembersOnly { get; private set; }

        public MembersOnlyAttribute(bool membersOnly)
        {
            MembersOnly = membersOnly;
        }
    }
}
