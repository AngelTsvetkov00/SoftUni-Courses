function solve(arrayOfCars) {
    
    let cars = {};
    
    let mapped = arrayOfCars.map(x => x.split(' | '));

    for (let [brand, model, producedCars] of mapped) {
    
        if (!cars.hasOwnProperty(brand)) {
    
            cars[brand] = {};
    
        }
    
        if (!cars[brand].hasOwnProperty(model)) {
    
            cars[brand][model] = Number(producedCars);
    
        } else {
    
            cars[brand][model] += Number(producedCars);
    
        }
    
    }

    for (let [brand, model] of Object.entries(cars)) {
        
        console.log(brand);
        
        for (let [k, v] of Object.entries(model)) {
        
            console.log(`###${k} -> ${v}`);
        
        }
    }
}


solve(['Skoda | Fabia | 1',
    'Audi | Q7 | 1000',
    'Audi | Q6 | 100',
    'BMW | X5 | 1000',
    'BMW | X6 | 100',
    'Citroen | C4 | 123',
    'Volga | GAZ-24 | 1000000',
    'Lada | Niva | 1000000',
    'Lada | Jigula | 1000000',
    'Citroen | C4 | 22',
    'Citroen | C5 | 10']
)