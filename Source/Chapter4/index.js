$(function () {
    var viewModel = function () {
        var self = this;
        this.requests = ko.observableArray();
        this.failedRequests = ko.observableArray();

        function handleEntry(log, key, value) {
            var result = log().forEach(function (entry) {
                if (entry[0] == key) {
                    entry[1](value);
                    return true;;
                }
            });

            if (result !== true) {
                log.push([key, ko.observable(value)]);
            }
        };


        var hub = $.connection.requestStatisticsHub;
        var initializedCount = 0;

        hub.client.requestCountChanged = function (key, value) {
            if (initializedCount < 2) return;
            handleEntry(self.requests, key, value);
        }

        hub.client.failedRequestCountChanged = function (key, value) {
            if (initializedCount < 2) return;
            handleEntry(self.failedRequests, key, value);
        }

        $.connection.hub.start().done(function () {
            hub.server.getRequests().done(function (requests) {
                for (var property in requests) {
                    handleEntry(self.requests, property, requests[property]);
                }

                initializedCount++;
            });
            hub.server.getFailedRequests().done(function (requests) {
                for (var property in requests) {
                    handleEntry(self.failedRequests, property, requests[property]);
                }

                initializedCount++;
            });
        });
    };

    ko.applyBindings(new viewModel());
});