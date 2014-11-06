Bifrost.namespace("Web.Accounts", {
    Transfer: Bifrost.views.ViewModel.extend(function (transfer) {
        var self = this;
        var from = ko.observableQueryParameter("from");
        this.transfer = transfer;
        this.transfer.from(from());
        this.transfer.amount(0);

        this.commandResult = ko.observable();

        transfer.failed(function (commandResult) {
            self.commandResult(commandResult);
        });

        transfer.succeeded(function () {
            Bifrost.navigation.navigateTo("/");
        });
    })
});