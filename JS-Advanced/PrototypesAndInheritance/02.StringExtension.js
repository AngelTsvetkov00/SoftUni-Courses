(function solve(){

    String.prototype.ensureStart=function(str){

        if(!this.startsWith(str)){

            return `${str}${this}`;

        }

        return `${this}`;

    }

    String.prototype.ensureEnd=function(str){

        if(!this.endsWith(str)){

            return `${this}${str}`;

        }
        
        return `${this}`;
    }

    String.prototype.isEmpty=function(){

        return this=='';
    
    }

    String.prototype.truncate=function(n){
        
        if(n>=this.length){
        
            return `${this}`;
        
        }else if(n<4){
        
            let stringToReturn='';
        
            for (let i = 0; i < n; i++) {
        
                stringToReturn+='.';
        
            }
        
            return stringToReturn;
        
        }else{
        
            let splittedWords=this.split(' ');
        
            if(splittedWords.length==1){
                
                    return `${splittedWords[0].substring(0,n-3)}...`;
                
            }else{
        
                let stringToReturn=splittedWords[0];
        
                let countOfSpaces=0;
        
                for (let i = 0; i < splittedWords.length-1; i++) {
        
                    if(stringToReturn.length+countOfSpaces+ splittedWords[i+1].length > n-3){
        
                        stringToReturn+='...';
        
                        break;
        
                    }else{
        
                        stringToReturn+=' ';
        
                        countOfSpaces++;
        
                        stringToReturn+=splittedWords[i+1];
                    }
                }

                return stringToReturn;
            }
        } 
    }

    String.format=function(string,...params){
        for (let i = 0; i < params.length; i++) {
            string = string.replace(`{${i}}`,params[i]);
        }

        return string;
    }

})();


let str = 'my string';
str = str.ensureStart('my');
console.log(str);
str = str.ensureStart('hello ');
console.log(str);
str = str.truncate(16);
console.log(str);
str = str.truncate(14);
console.log(str);
str = str.truncate(8);
console.log(str);
str = str.truncate(4);
console.log(str);
str = str.truncate(2);
console.log(str);
str = String.format('The {0} {1} fox',
  'quick', 'brown');
  console.log(str);
str = String.format('jumps {0} {1}',
  'dog');
  console.log(str);
