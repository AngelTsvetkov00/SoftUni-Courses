function tickets(ticketsArray, sortCriteria) {
    class Ticket {
        constructor(destination, price, status) {
            this.destination = destination;
            this.price = price;
            this.status = status;
        }
    }

    let ticketContainer = [];

    for (const ticketString of ticketsArray) {
        let ticketArgs = ticketString.split('|');
        let newTicket = new Ticket(ticketArgs[0], Number(ticketArgs[1]), ticketArgs[2]);
        ticketContainer.push(newTicket);
    }

    if (sortCriteria == "destination" || sortCriteria == "status") {
        ticketContainer = ticketContainer.sort((a, b) => {
            return a[sortCriteria].localeCompare(b[sortCriteria]);
        });
    } else if (sortCriteria == "price") {
        ticketContainer = ticketContainer.sort((a, b) => {
            return a[sortCriteria] - b[sortCriteria];
        });
    }
    return ticketContainer;
}

console.log(tickets(['Philadelphia|94.20|available',
    'New York City|95.99|available',
    'New York City|95.99|sold',
    'Boston|126.20|departed'],
    'price'
));