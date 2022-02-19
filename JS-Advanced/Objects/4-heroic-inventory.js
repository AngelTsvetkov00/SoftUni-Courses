function object(input) {
    let result=[];

    for (let heroInfo of input) {
        let info = heroInfo.split(' / ');
        let items= info[2] ? info[2].split(', ') : [];
        
        let hero={
            name:`${info[0]}`,
            level:Number(info[1]),
            items,
        }

        result.push(hero);
    }

    return JSON.stringify(result);
}
object(['Isacc / 25 / Apple, GravityGun',
'Derek / 12 / BarrelVest, DestructionSword',
'Hes / 1 / Desolator, Sentinel, Antara']
);