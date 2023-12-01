using UniversityRegistration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityRegistration.Logic
{
    internal interface IMemberLogic
    {
        public void AddMember(Member member);

        public List<Member> GetAllMembers();

        public T GetMemberByEmail<T>(string email) where T : Member;

        public List<string> GetOnlyActiveMembers();

        public int GetTotalCoursesOfMember(string email);
    }
}
