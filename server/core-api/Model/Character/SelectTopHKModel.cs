﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Model.Character
{
    [Serializable]
    public class SelectTopHKModel : RealmTypeModel
    {
        public int Limit { get; set; }
    }
}
