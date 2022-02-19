function object(input) {
    let foods = {};

    let sortFoods = function (a, b) {
        return a.localeCompare(b);
    };

    input.sort(sortFoods)

    for (let food of input) {
        let foodInfo = food.split(' : ');
        let foodLetter = foodInfo[0][0];

        let currentFood = {
            [`${foodInfo[0]}`]: Number(foodInfo[1])
        }

        let foundLetter = Object.keys(foods).find(x => {
            return x == foodLetter;
        })

        if (!foundLetter) {
            foods[`${foodLetter}`] = [];
            foods[`${foodLetter}`].push(currentFood)
        } else {
            foods[`${foodLetter}`].push(currentFood)
        }
    }

    for (const [key, value] of Object.entries(foods)) {
        console.log(key);

        for (let i = 0; i < value.length; i++) {
            for (const [foodKey, foodValue] of Object.entries(value[i])) {
                console.log(`  ${foodKey}: ${foodValue}`);
            }
        }
    }
}

object(['Appricot : 20.4',
    'Fridge : 1500',
    'TV : 1499',
    'Deodorant : 10',
    'Boiler : 300',
    'Apple : 1.25',
    'Anti-Bug Spray : 15',
    'T-Shirt : 10']
)