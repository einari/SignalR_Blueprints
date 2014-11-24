$(function () {
    var livenewsContainer = document.getElementById("livenewsContainer");

    function mapArticleAndExpandTemplate(article) {
        article.PublishedDateString = new Date(article.PublishedDate).toLocaleString();
        var articleElement = expandTemplateWithData("liveNewsItemTemplate", article);
        return articleElement;
    }

    articleHub.client.published = function (article) {
        var articleElement = mapArticleAndExpandTemplate(article);
        if (livenewsContainer.firstChild) {
            livenewsContainer.insertBefore(articleElement, livenewsContainer.firstChild);
        } else {
            livenewsContainer.appendChild(articleElement);
        }
    };
    
    onHubsConnected(function () {
        articleHub.server.getArticles().done(function (articles) {

            articles.forEach(function (article) {
                var articleElement = mapArticleAndExpandTemplate(article);
                livenewsContainer.appendChild(articleElement);
            });
        });
    });
});