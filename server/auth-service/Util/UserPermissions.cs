using Microsoft.EntityFrameworkCore;
using server.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Util
{
    public class UserPermissions
    {
        private readonly AuthContext _authContext;

        public UserPermissions(AuthContext authContext)
        {
            _authContext = authContext;
        }

        public async Task<int> GetRankByAccountId(int accountId)
        {
            var result = await _authContext.AccountAccess.FirstOrDefaultAsync(x => x.Id == accountId);
            if (result == null)
                return 0;

            return result.Gmlevel;
        }

        public class Permission
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        public async Task<List<Permission>> GetPermissionsByRank(int rank)
        {
            var result = (from rbl in _authContext.RbacLinkedPermissions
                         join rbp in _authContext.RbacPermissions
                         on rbl.LinkedId equals rbp.Id
                         where rbl.Id == rank
                         select new Permission { Id = rbp.Id, Name = rbp.Name }).ToListAsync();

            return await result;
        }
    }
}
