﻿using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Text;

namespace KissU.IModuleServices.Common.Models
{
    [ProtoContract]
    public class AuthenticationRequestData
    {
        [ProtoMember(1)]
        public string UserName { get; set; }

        [ProtoMember(2)]
        public string Password { get; set; }
    }
}
