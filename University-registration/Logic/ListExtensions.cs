using UniversityRegistration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityRegistration.Logic
{
    internal static class ListExtensions
    {
        public static List<T> ActiveMember<T>(this List<T> list) where T : Member
        {
            return list.Where(x => x.Courses.Count>0).ToList();
        }
    }
}
