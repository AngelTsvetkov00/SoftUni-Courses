function printInfo(){
    let argsArray=arguments;
    let argsNumbers={};
    let argsNumbersSorted=[];
    for (const argument of argsArray) {
        console.log(typeof argument+`: ${argument}`);
        if(!argsNumbers.hasOwnProperty(`${typeof argument}`)){
            argsNumbers[`${typeof argument}`]=1;
        }else{
            argsNumbers[`${typeof argument}`]++;
        }
    }
    
    for (const [key,value] of Object.entries(argsNumbers)) {
        argsNumbersSorted.push([key,value]);
    }
    argsNumbersSorted = argsNumbersSorted.sort((a,b)=>{
        return b[1] - a[1];
    });
    
    for (const [key,value] of argsNumbersSorted) {
        console.log(`${key} = ${value}`);
    }
}

printInfo({ name: 'bob'}, 3.333, 9.999);