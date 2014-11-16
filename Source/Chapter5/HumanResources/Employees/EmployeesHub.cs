using System;
using System.Collections.Generic;
using Bifrost.Entities;
using Microsoft.AspNet.SignalR;

namespace Web.HumanResources.Employees
{
    public class EmployeesHub : Hub
    {
        IEntityContext<Employee> _employeesEntityContext;

        public EmployeesHub(IEntityContext<Employee> employeesEntityContext)
        {
            _employeesEntityContext = employeesEntityContext;
        }

        public IEnumerable<Employee>  GetAll()
        {
            return _employeesEntityContext.Entities;
        }


        public void Hire(Employee employee)
        {
            employee.Id = Guid.NewGuid();
            _employeesEntityContext.Insert(employee);
            _employeesEntityContext.Commit();

            Clients.All.hired(employee);
        }
    }
}