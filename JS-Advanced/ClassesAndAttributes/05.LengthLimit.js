class Stringer {
    
    constructor(innerString, innerLength) {
    
        this.innerString = innerString;
    
        this.innerLength = innerLength < 0 ? 0 : innerLength;
    
    }

    
    decrease(length) {
    
        this.innerLength -= length;
    
        if (this.innerLength < 0) {
    
    
            this.innerLength = 0;
    
        }
    
    }

    
    increase(length) {
    
        this.innerLength += length;
    
    }

    
    toString() {
    
        return this.innerLength === 0 ? '...' : 
    
        this.innerLength >= this.innerString.length - 1 ? this.innerString : 
    
        this.innerString.slice(0, this.innerLength) + '...';
    
    }
}

let test = new Stringer("Acho", 5);

console.log(Object.getOwnPropertyDescriptors(test));

console.log(test.toString()); // Acho

test.decrease(3);
console.log(test.toString()); // Ac...

test.decrease(5);
console.log(test.toString()); // ...

test.increase(4);
console.log(test.toString()); // Acho

