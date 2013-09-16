using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Conquest.Service.Actions;

namespace Conquest.Service
{
    [DataContract]
    [KnownType(typeof(PlayerActionResult))]
    public class ActionResult
    {
        [DataMember]
        public bool succ { get; set; }
        [DataMember]
        public ResultType resulttype { get; set; }
    }


}
