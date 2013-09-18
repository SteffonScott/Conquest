using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace Conquest.Service.Actions
{
    [DataContract]
    public enum PlayerActionType
    {
        [EnumMember]
        Person,
        [EnumMember]
        Review,
        [EnumMember]
        Pray,
        [EnumMember]
        Tavern,
        [EnumMember]
        Roll
    }

}