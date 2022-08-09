using BusinessObject;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eStore.Models
{
    public class UserModel
    {
        public MemberObject user;
        public string confirmationCode;
        [Display(Name ="Verification Code")]
        public string inputComfirmationCode;
    }
}
