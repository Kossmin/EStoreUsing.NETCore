using BusinessObject;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Xunit;

namespace Demo.Test
{
    public class MemberDAOTests
    {
        [Fact]
        public void AddMemberToList()
        {
            MemberObject member = new MemberObject { City = "HCM", CompanyName = "None",
                Country = "VietNam", Email = "123@gmail.com", MemberId = 6, Password = "14545646" };
            List<MemberObject> members = new List<MemberObject>();

            MemberDAO.Instance.AddMemberToList(members, member);
            Assert.True(members.Count == 1);
        }
    }
}
