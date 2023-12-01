using UniversityRegistration.Logic;
using UniversityRegistration.Models;
using UniversityRegistration.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityRegistration
{
    internal class MemberLogic : IMemberLogic
    {
        private List<Member> _members;
        private Dictionary<string, Student> _student;
        private Dictionary<string, Teacher> _teacher;

        public MemberLogic()
        {
            _members = new List<Member>
            {
                new Student
                {
                    Id = 1,
                    Name = "Xavier",
                    Email = "Xavier@univ.com",
                    Courses = new List<string> {"Course 1", "Couse 2" },
                },

                new Teacher
                {
                    Id = 11111,
                    Name = "Thomas",
                    Email = "Thomas@univ.com",
                    Degree = "Doctorat",
                    Courses = new List<string> { "Course 1", "Couse 3" },
                },

                new Assistant
                {
                    Id = 11144,
                    Name = "Anne",
                    Email = "Anne@univ.com",
                    IdSupervisor = 11111,
                    Courses = new List<string> { "Course 1" },
                }
            };

            _student = new Dictionary<string, Student>();
            _teacher = new Dictionary<string, Teacher>();
        }

        public void AddMember(Member member)
        {
            if (member is Student)
            {
                var validator = new StudentVaLidator();
                if (validator.Validate(member as Student).IsValid)
                {
                    _student.Add(member.Name, member as Student);
                }
                else
                {
                    throw new ValidationException("Sorry, one entry isn't valid for student");
                }
                
            }
            if (member is Teacher)
            {
                _teacher.Add(member.Name, member as Teacher);
            }
            _members.Add(member);
        }

        public List<Member> GetAllMembers()
        {
            return _members;
        }

        public T GetMemberByEmail<T>(string email) where T : Member
        {
            try
            {
                if (typeof(T) == typeof(Student))
                {
                    return _student[email] as T;
                }
                else if (typeof(T) == typeof(Teacher))
                {
                    return _teacher[email] as T;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<string> GetOnlyActiveMembers()
        {
            return _members.ActiveMember().Select(x=>x.Name).ToList();
        }

        public int GetTotalCoursesOfMember(string email)
        {
            return 0;
        }
    }
}
