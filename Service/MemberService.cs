using DataModel;
using IService;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service
{
    public class MemberService : IMemberService
    {
        public EFContext db;
        public MemberService(EFContext _efContext)
        {
            db = _efContext;
        }
        /// <summary>
        /// 验证用户，成功则返回用户信息，否则返回null
        /// </summary>
        /// <param name="username"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public async Task<Members> GetByStr(string username, string pwd)
        {
            Members m = await db.Members.Where(a => a.UserName == username && a.Password == pwd).SingleOrDefaultAsync();
            if (m != null)
            {
                return m;
            }
            else
            {
                return null;
            }
        }

        public Members GetMember(string username)
        {
            Members m = db.Members.Where(a=>a.UserName==username).SingleOrDefault();
            return m;
        }
    }
}
