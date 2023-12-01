
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
        /// <summary>
        /// Add a new member (teacher or student to the university
        /// </summary>
        /// <param name="member">The member that will be added. </param>
        public void AddMember(Member member);

        /// <summary>
        /// Get all the members of the University
        /// </summary>
        public List<Member> GetAllMembers();

        /// <summary>
        /// Gets a member by his email 
        /// </summary>
        /// <param name="email">The email registred for the member. </param>
        public T GetMemberByEmail<T>(string email) where T : Member;

        /// <summary>
        /// Get all members who have a current course.
        /// </summary>
        /// <returns>The names of the active members </returns>
        public List<string> GetOnlyActiveMembers();

        /// <summary>
        /// Returns the number of courses for a member
        /// </summary>
        /// <param name="email">The email registred for the member. </param>
        /// <returns>number of courses</returns>
        //public int GetTotalCoursesOfMember(string email);
    }
}
