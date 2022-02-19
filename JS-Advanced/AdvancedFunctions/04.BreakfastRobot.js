function solution() {
    let currentIngredients = {
        protein: 0,
        carbohydrate: 0,
        fat: 0,
        flavour: 0,
    }

    const apple = {
        name: 'apple',
        carbohydrate: 1,
        flavour: 2,
    }

    const lemonade = {
        name: 'lemonade',
        carbohydrate: 10,
        flavour: 20,
    }

    const burger = {
        name: 'burger',
        carbohydrate: 5,
        fat: 7,
        flavour: 3,
    }

    const eggs = {
        name: 'eggs',
        protein: 5,
        fat: 1,
        flavour: 1,
    }

    const turkey = {
        name: 'turkey',
        protein: 10,
        carbohydrate: 10,
        fat: 10,
        flavour: 10,
    }

    let recipes = [apple, lemonade, burger, eggs, turkey];

    return function (command) {
        let commandArgs = command.split(' ');
        let isEnough = true;
        let stringToReturn = 'Success';
        if (commandArgs[0] == 'restock') {
            let ingredient = commandArgs[1];
            let quantity = Number(commandArgs[2]);
            currentIngredients[ingredient] += quantity;
        } else if (commandArgs[0] == 'prepare') {
            let desiredProduct = recipes.find(x => x.name == commandArgs[1]);
            let productIngredients = Object.getOwnPropertyNames(desiredProduct);
            let quantity = Number(commandArgs[2]);

            for (const ingredient of productIngredients) {
                if (desiredProduct[ingredient] * quantity > currentIngredients[ingredient]) {
                    stringToReturn = `Error: not enough ${ingredient} in stock`;
                    isEnough = false;
                    break;
                }
            }

            if (isEnough) {
                for (const ingredient of productIngredients) {
                    currentIngredients[ingredient] -= desiredProduct[ingredient] * quantity;
                }
            }
        } else if (commandArgs[0] == 'report') {
            stringToReturn = '';
            for (const [key, value] of Object.entries(currentIngredients)) {
                if (key != 'name') {
                    stringToReturn += `${key}=${value} `;
                }
            }
            stringToReturn = stringToReturn.trim();
        }
        return stringToReturn;
    }
}

let manager = solution();
console.log(manager("restock flavour 50")); // Success 
console.log(manager("prepare lemonade 4"));
console.log(manager("restock carbohydrate 10"));
console.log(manager("restock flavour 10"));
console.log(manager("prepare apple 1"));
console.log(manager("restock fat 10"));
console.log(manager("prepare burger 1"));
console.log(manager("report"));