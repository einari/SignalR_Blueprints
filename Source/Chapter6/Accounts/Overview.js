Bifrost.namespace("Web.Accounts", {
    Overview: Bifrost.views.ViewModel.extend(function (accountsOverview, overviewHub) {
        var self = this;

        this.accounts = accountsOverview.all();

        overviewHub.client(function (client) {
            client.accountBalanceChanged = function (accountNumber, balance) {
                var accountOverviewFound;
                self.accounts().forEach(function (accountOverview) {
                    if (accountOverview.accountNumber == accountNumber) {
                        accountOverviewFound = accountOverview;
                    }
                });

                self.accounts.replace(accountOverviewFound, {
                    id: accountOverviewFound.id,
                    accountNumber: accountNumber,
                    balance: balance
                });
            };
        });

    })
});