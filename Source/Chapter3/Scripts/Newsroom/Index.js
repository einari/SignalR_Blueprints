$(function () {
    var imageUrlElement = document.getElementById("imageUrl");
    var headlineElement = document.getElementById("headline");
    var leadElement = document.getElementById("lead");
    var bylineElement = document.getElementById("byline");
    var bodyElement = document.getElementById("body");

    var publishButton = document.getElementById("publishButton");
    publishButton.addEventListener("click", function () {
        var article = {
            ImageUrl: imageUrlElement.value,
            Headline: headlineElement.value,
            Lead: leadElement.value,
            Byline: bylineElement.value,
            Body: bodyElement.value
        }

        articleHub.server.publish(article).done(function () {
            imageUrlElement.value = "";
            headlineElement.value = "";
            leadElement.value = "";
            bylineElement.value = "";
            bodyElement.value = "";
            alert("Published");
        });
    });
});