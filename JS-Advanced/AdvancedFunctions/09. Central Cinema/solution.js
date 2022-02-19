function solve() {
    let inputElements = Array.from(document.querySelectorAll("div[id=container] > input"));
    console.log(inputElements);

    let onScreenButtonElement = document.querySelectorAll("div[id=container] > button")[0];
    console.log(onScreenButtonElement);

    let clearButtonElement = document.querySelectorAll("section[id=archive] > button")[0];

    let moviesOnScreenSectionElement = document.getElementById('movies');
    let archiveSectionElement = document.getElementById('archive');

    onScreenButtonElement.addEventListener('click', (e) => {
        e.preventDefault();
        if (!inputElements.some(x => x.value == '') && inputElements[2].value.match(/^[0-9]+(.[0-9]+)?$/)) {
            let movieName = inputElements[0].value;
            let hall = inputElements[1].value;
            let tickerPrice = inputElements[2].value;

            let listItem = createMovieItemList(movieName, hall, tickerPrice);
            moviesOnScreenSectionElement.querySelector('ul').appendChild(listItem);
            //moviesOnScreenSectionElement.appendChild(listItem);

            for (const element of inputElements) {
                element.value = '';
            }
        }
    })

    function createMovieItemList(movieName, hall, tickerPrice) {
        let itemToReturn = document.createElement('li');

        let movieNameSpanElement = document.createElement('span');
        movieNameSpanElement.textContent = movieName;
        itemToReturn.appendChild(movieNameSpanElement);

        let hallStrongElement = document.createElement('strong');
        hallStrongElement.textContent = `Hall: ${hall}`;
        itemToReturn.appendChild(hallStrongElement);

        let divElement = document.createElement('div');

        let priceStrongElement = document.createElement('strong');
        priceStrongElement.textContent = Number(tickerPrice).toFixed(2);
        divElement.appendChild(priceStrongElement);

        let ticketsSoldInputElement = document.createElement('input');
        ticketsSoldInputElement.placeholder = "Tickets Sold";
        divElement.appendChild(ticketsSoldInputElement);

        let divButtonElement = document.createElement('button');
        divButtonElement.textContent = 'Archive';
        divButtonElement.addEventListener('click', (e) => {
            try {
                archiveSectionElement.querySelectorAll('section[id=archive] > ul')[0].removeChild(itemToReturn);
            }
            catch (error) {
                //e.preventDefault();
                if (ticketsSoldInputElement.value.match(/^[0-9]+(.[0-9]+)?$/)) {
                    let totalPrice = Number(ticketsSoldInputElement.value * (Number(tickerPrice))).toFixed(2);
                    itemToReturn.removeChild(divElement);
                    hallStrongElement.textContent = `Total amount: ${totalPrice}`;
                    divButtonElement.textContent = 'Delete';
                    itemToReturn.appendChild(divButtonElement);
                    moviesOnScreenSectionElement.querySelector('ul').removeChild(itemToReturn);
                    archiveSectionElement.querySelectorAll('section[id=archive] > ul')[0].appendChild(itemToReturn);
                }
            }
        });

        divElement.appendChild(divButtonElement);

        itemToReturn.appendChild(divElement);
        return itemToReturn;
    }

    clearButtonElement.addEventListener('click', () => {
        for (const listItem of document.querySelectorAll("section[id=archive] > ul > li")) {
            archiveSectionElement.querySelectorAll('section[id=archive]>ul')[0].removeChild(listItem);
        }
    })
}