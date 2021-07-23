using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class MemberRepository : IMemberRepository
    {
        public void DeleteMember(int memberID) => MemberDAO.Instance.DeleteMember(memberID);


        public MemberObject GetMemberByEmail(string email) => MemberDAO.Instance.GetMemberByEmail(email);



        public MemberObject GetMemberByID(int memberID) => MemberDAO.Instance.GetMemberByID(memberID);



        public IEnumerable<MemberObject> GetMembers() => MemberDAO.Instance.Members();



        public void InsertMember(MemberObject member) => MemberDAO.Instance.InsertMember(member);


        public void UpdateMember(MemberObject member) => MemberDAO.Instance.UpdateMember(member);

    }
}
