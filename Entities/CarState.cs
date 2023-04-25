using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public enum CarState
    {
        [EnumMember (Value = "Available")]
        Available ,
        [EnumMember(Value = "Rented")]
        Rented,
        [EnumMember(Value = "Maintenance")]
        Maintenance
    }
}
