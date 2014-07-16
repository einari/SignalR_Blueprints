function getCurrentThreadID() {
    var elements = document.location.toString().split("/");
    var threadID = parseInt(elements[elements.length - 1]);
    return threadID;
}

function addOrReplaceRow(post) {
    var tableBody = document.getElementById("postTableBody");
    var row = expandTemplateWithData("postRowTemplate", post);

    row.addEventListener("click", function (e) {
        document.location = "/Forum/Thread/" + post.ID;
    });

    var $existingRow = $("[data-post='" + post.ID + "']");
    if ($existingRow.length == 1) {
        tableBody.replaceChild(row, $existingRow[0]);
    } else {
        tableBody.appendChild(row);
    }
}

function mapPost(post) {
    post.Created = new Date(post.Created).toLocaleString();
}


$(function () {
    var postHub = $.connection.postHub;

    var postReplyButton = document.getElementById("postReplyButton");
    postReplyButton.addEventListener("click", function () {
        var threadID = getCurrentThreadID();
        var contentTextArea = document.getElementById("content");
        postHub.server.addPostToThread(threadID, contentTextArea.value);
        contentTextArea.value = "";
    });

    postHub.client.postAdded = function (post) {
        mapPost(post);
        addOrReplaceRow(post);
    };

    $.connection.hub.start().done(function () {
        var threadID = getCurrentThreadID();
        postHub.server.getForThread(threadID).done(function (posts) {
            posts.forEach(postHub.client.postAdded);
        });
    });
});