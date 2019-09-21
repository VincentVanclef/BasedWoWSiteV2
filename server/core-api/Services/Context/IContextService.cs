using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server.Context;
using server.Util;

namespace server.Services.Context
{
    public interface IContextService
    {
        CharacterContext GetCharacterContext(RealmType type);
        WorldContext GetWorldContext(RealmType type);
    }
}
