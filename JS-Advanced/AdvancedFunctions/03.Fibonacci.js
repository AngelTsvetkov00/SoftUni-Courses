function getFibonator(){
    let previous=0;
    let current=1;
    let fibonacciNumber=0;
    let temp=0;
    return function (){  
        fibonacciNumber=current;
        temp=current;
        current+=previous;
        previous=temp;
        return fibonacciNumber;
    }
}

let fib = getFibonator();
console.log(fib()); // 1
console.log(fib()); // 1
console.log(fib()); // 2
console.log(fib()); // 3
console.log(fib()); // 5
console.log(fib()); // 8
console.log(fib()); // 13
//1,1,2,3,5,8,13