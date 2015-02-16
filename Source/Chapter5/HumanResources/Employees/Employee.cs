using System;
namespace Chapter5.HumanResources.Employees
{
    public class Employee
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string SocialSecurityNumber { get; set; }

        public string HiredDate { get; set; }
    }
}
