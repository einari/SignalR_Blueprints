Bifrost.namespace("Chapter5.HumanResources.Employees", {
    List: Bifrost.views.ViewModel.extend(function (employeesHub) {
        var self = this;
        this.employees = ko.observableArray();

        employeesHub.server.getAll().continueWith(function(employees) {
            employees.forEach(function (employee) {
                self.employees.push(employee);
            });
        });

        employeesHub.client(function (client) {
            client.hired = function (employee) {
                self.employees.push(employee);
            }
        });
    })
});