var articleHub = $.connection.articleHub;
var searchHub = $.connection.searchHub;
var hubsConnected = false;
var hubsConnectedCallbacks = [];

function onHubsConnected(callback) {
    if (hubsConnected == true) {
        callback();
    } else {
        hubsConnectedCallbacks.push(callback);
    }
};

$.connection.hub.start().done(function () {
    hubsConnected = true;

    hubsConnectedCallbacks.forEach(function (callback) {
        callback();
    })
});
