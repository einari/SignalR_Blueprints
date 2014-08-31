function expandTemplateWithData(templateName, data) {
    var template = document.getElementById(templateName);
    if (template == null) return document.createElement("span");
    var templateString = template.innerHTML;

    for (var property in data) {
        templateString = templateString.split("%"+property+"%").join(data[property]);
    }

    return $(templateString)[0];
}
