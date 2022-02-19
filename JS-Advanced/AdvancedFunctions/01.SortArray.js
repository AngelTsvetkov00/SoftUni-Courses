function sortArray(numberArray,command){
    if(command=='asc'){
        numberArray.sort((a,b)=>{
            return a-b;
        })
    }else if(command=='desc'){
        numberArray.sort((a,b)=>{
            return b-a;
        })
    }
   return numberArray;
}

sortArray([14, 7, 17, 6, 8], 'desc');