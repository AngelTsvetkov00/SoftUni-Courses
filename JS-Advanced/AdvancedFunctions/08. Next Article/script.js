function getArticleGenerator(articles) {
    let count = 0;
    let divElement = document.getElementById('content');
    return function () {
        if (count < articles.length) {
            let articleElement = document.createElement('article');
            articleElement.textContent = articles[count];
            divElement.appendChild(articleElement);
            count++;
        }
    }
}
