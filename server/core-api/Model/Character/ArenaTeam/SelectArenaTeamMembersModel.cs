using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Model.Character.ArenaTeam
{
    public class SelectArenaTeamMembersModel : RealmTypeModel
    {
        public List<int> Teams { get; set; }
    }
}
