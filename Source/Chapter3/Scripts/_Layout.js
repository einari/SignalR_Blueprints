$(function () {
    var searchInput = document.getElementById("searchInput");

    $(searchInput).typeahead({
        hint: true,
        highlight: true,
        minLength: 1
    },
    {
        displayKey: 'Headline',
        source: function (query, callback) {
            searchHub.server.getArticlesContaining(query).done(function (articles) {
                callback(articles);
            });
        }
    });

    $(searchInput).bind('typeahead:selected', function (obj, article) {
        document.location = "/Article/Full/" + article.ID;
    });
});