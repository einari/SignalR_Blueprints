Bifrost.namespace("Chapter5.HumanResources.Employees", {
    Register: Bifrost.views.ViewModel.extend(function (employeesHub) {
        var self = this;

        this.employee = {
            firstName: "",
            lastName: "",
            socialSecurityNumber: "",
            hiredDate: ""
        };

        this.hire = function () {
            employeesHub.server.hire(self.employee);
        };
    })
});