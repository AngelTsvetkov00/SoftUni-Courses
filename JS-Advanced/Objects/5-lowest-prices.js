function object(input) {
    let citiesProducts = [];

    for (const array of input) {
        let info = array.split(' | ');
        let product = {
            name: info[1],
            city: info[0],
            price: Number(info[2]),
        }

        let sameProduct = citiesProducts.find(x => {
            return x.name == product.name;
        })

        if (sameProduct) {
            if (Number(info[2]) < sameProduct.price) {
                sameProduct.city = product.city;
                sameProduct.price = product.price;
            }
        } else {
            citiesProducts.push(product);
        }

    }

    for (const cityProduct of citiesProducts) {
        console.log(`${cityProduct.name} -> ${cityProduct.price} (${cityProduct.city})`);
    }
}

object(['Sample Town | Sample Product | 1000',
    'Sample Town | Orange | 2',
    'Sample Town | Peach | 1',
    'Sofia | Orange | 3',
    'Sofia | Peach | 2',
    'New York | Sample Product | 1000.1',
    'New York | Burger | 10',
    'Varna | Sample Product | 999']
)