using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using UniversityRegistration;
using UniversityRegistration.Logic;
using UniversityRegistration.Models;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

var services = CreateServiceCollection();

var memberLogic = services.GetService<IMemberLogic>();

string userInput = DisplayMenuAndGetInput();

while (userInput.ToLower() != "exit")
{
    if (userInput == "1")
    {
        Console.WriteLine("Please add a new Student in JSON format");
        var userInputAsJson = Console.ReadLine();
        var student = JsonSerializer.Deserialize<Student>(userInputAsJson);
        memberLogic.AddMember(student);
    }
    if (userInput == "2")
    {
        Console.Write("Enter the email of the member : ");
        var memberEmail = Console.ReadLine();
        var member = memberLogic.GetMemberByEmail<Member>(memberEmail);
        Console.WriteLine(JsonSerializer.Serialize(member));
        Console.WriteLine();
    }
    if (userInput == "3")
    {
        Console.WriteLine("This is the list of the students and teacher for the current : ");
        var activeMember = memberLogic.GetOnlyActiveMembers();
        foreach (var aMember in activeMember)
        {
            Console.WriteLine(aMember);
        }
        Console.WriteLine();
    }
    if (userInput == "4")
    {
        Console.Write("Enter the email of the member : ");
        var memberEmail = Console.ReadLine();
        if (IsValid(memberEmail))
        {
            Console.WriteLine($"The total price of inventory on hand is {memberLogic.GetTotalCoursesOfMember(memberEmail)}");
        }

        Console.WriteLine();
    }

    userInput = DisplayMenuAndGetInput();
}

static string DisplayMenuAndGetInput()
{
    Console.WriteLine("Press 1 to add a student or teacher");
    Console.WriteLine("Press 2 to view a Member detail");
    Console.WriteLine("Press 3 to view active personnel for the current session");
    Console.WriteLine("Press 4 to view the total course of a member");
    Console.WriteLine("Type 'exit' to quit");

    return Console.ReadLine();
}

// To use a regex to validate email format
static bool IsValid(string email)
{
    string regex = @"^[^@\s]+@[^@\s]+\.(com|net|org|gov)$";

    return Regex.IsMatch(email, regex, RegexOptions.IgnoreCase);
}

static IServiceProvider CreateServiceCollection()
{
    return new ServiceCollection()
        .AddTransient<IMemberLogic, MemberLogic>()
        .BuildServiceProvider();
}