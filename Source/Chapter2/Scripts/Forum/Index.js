function addOrReplaceRow(thread) {
    var tableBody = document.getElementById("threadTableBody");
    var row = expandTemplateWithData("threadRowTemplate", thread);

    row.addEventListener("click", function (e) {
        document.location = "/Forum/Thread/" + thread.ID;
    });

    var $existingRow = $("[data-thread='" + thread.ID + "']");
    if ($existingRow.length == 1) {
        tableBody.replaceChild(row, $existingRow[0]);
    } else {
        tableBody.appendChild(row);
    }
}

function mapThread(thread) {
    thread.Started = new Date(thread.Started).format("dd/MM-yyyy hh:mm");
    thread.LastPost = new Date(thread.LastPost).format("dd/MM-yyyy hh:mm");
}

$(function () {
    var threadHub = $.connection.threadHub;

    var button = document.getElementById("saveThreadButton");
    var title = document.getElementById("title");
    var content = document.getElementById("content");

    button.addEventListener("click", function () {
        threadHub.server.create(title.value, content.value).done(function () {
            title.value = "";
            content.value = "";
        });
    });

    threadHub.client.threadUpdated =
    threadHub.client.threadCreated = function (thread) {
        mapThread(thread);
        addOrReplaceRow(thread);
    };

    $.connection.hub.start().done(function () {
        threadHub.server.getAll().done(function (threads) {
            threads.forEach(threadHub.client.threadUpdated);
        });
    });
});
