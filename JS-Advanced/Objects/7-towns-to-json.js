function object(input) {
    let result = [];

    for (let i = 1; i < input.length; i++) {
        let townSplit = input[i].split('|').filter(x => x != '');
        result.push({
            Town: townSplit[0].trim(),
            Latitude: Number(Number(townSplit[1]).toFixed(2)),
            Longitude: Number(Number(townSplit[2]).toFixed(2))
        });
    }

    console.log(JSON.stringify(result));
}

object(['| Town | Latitude | Longitude |',
    '| Sofia | 42.696552 | 23.32601 |',
    '| Beijing | 39.913818 | 116.363625 |']
)