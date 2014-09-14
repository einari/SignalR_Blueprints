$(function () {
    var viewModel = function () {
        var self = this;
        this.requests = ko.observableArray([]);
        this.failedRequests = ko.observableArray([]);

        var hub = $.connection.requestStatisticsHub;
        var initializedCount = 0;

        function handleRequest(key, value) {
            var result = self.requests().forEach(function (request) {
                if (request[0] == key) {
                    request[1](value);
                    return true;;
                }
            });

            if (result !== true) {
                self.requests.push([key, ko.observable(value)]);
            }
        };

        function handleFailedRequest(key, value) {
            var result = self.failedRequests().forEach(function (request) {
                if (request[0] == key) {
                    request[1](value);
                    return true;;
                }
            });

            if (result !== true) {
                self.failedRequests.push([key, ko.observable(value)]);
            }
        };

        hub.client.requestCountChanged = function (key, value) {
            if (initializedCount < 2) return;
            handleRequest(key, value);
        }

        hub.client.failedRequestCountChanged = function (key, value) {
            if (initializedCount < 2) return;
            handleFailedRequest(key, value);
        }

        $.connection.hub.start().done(function () {
            hub.server.getRequests().done(function (requests) {
                for (var property in requests) {
                    handleRequest(property, requests[property]);
                }

                initializedCount++;
            });
            hub.server.getFailedRequests().done(function (requests) {
                for (var property in requests) {
                    handleFailedRequest(property, requests[property]);
                }

                initializedCount++;
            });
        });
    };

    ko.applyBindings(new viewModel());
});