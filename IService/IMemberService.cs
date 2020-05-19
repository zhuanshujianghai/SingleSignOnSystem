using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IService
{
    public interface IMemberService
    {
        Task<Members> GetByStr(string username, string pwd);//根据用户名和密码查找用户
        Members GetMember(string username);
    }
}
