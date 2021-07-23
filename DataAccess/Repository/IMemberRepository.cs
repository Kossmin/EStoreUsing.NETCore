using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IMemberRepository
    {
        IEnumerable<MemberObject> GetMembers();
        MemberObject GetMemberByID(int memberID);
        void InsertMember(MemberObject member);
        void DeleteMember(int memberID);
        void UpdateMember(MemberObject member);
        MemberObject GetMemberByEmail(string email);

    }
}
