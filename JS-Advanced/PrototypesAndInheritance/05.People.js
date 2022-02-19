function solve() {
    class Employee {
        constructor(name, age) {
            this.name = name;
            this.age = age;
        };

        salary=0;

        // set salary(value) {
        //     this.salary = value;
        // }

        // get salary(){
        //     return this.salary;
        // }

        count=0;

        work() { 
            console.log(this.tasks[this.count]);
            this.count++;
            if(this.count==this.tasks.length) this.count=0;               
        };

        collectSalary() {
            console.log(`${this.name} received ${this.salary} this month.`);
        };
    };

    class Junior extends Employee {
        constructor(name,age) {
            super(name,age);
        };

        tasks=[`${this.name} is working on a simple task.`];
    }


    class Senior extends Employee{
        constructor(name,age){
            super(name,age);
        }

        tasks=[`${this.name} is working on a complicated task.`,
        `${this.name} is taking time off work.`,
        `${this.name} is supervising junior workers.`];
    }

    class Manager extends Employee{
        constructor(name,age){
            super(name,age);
        }

        dividend=0;

        tasks=[`${this.name} scheduled a meeting.`,	
        `${this.name} is preparing a quarterly report.`]

        // set dividend(value){
        //     this.dividend=value;
        // }

        // get dividend(){
        //     return this.dividend;
        // }

        collectSalary(){
            console.log(`${this.name} received ${this.salary+this.dividend} this month.`);  
        }
    }

    return {
        Employee:Employee,
        Junior:Junior,
        Senior:Senior,
        Manager:Manager,
    };
}

function solution() {
    class Employee {
        constructor(name, age) {
            this.name = name;
            this.age = age;
            this.salary=0;
            this.tasks=[];
        };

        count=0;

        work() { 
            console.log(this.tasks[this.count]);
            this.count++;
            if(this.count==this.tasks.length) this.count=0;               
        };

        collectSalary() {
            console.log(`${this.name} received ${this.salary} this month.`);
        };
    };

    class Junior extends Employee {
        constructor(name,age) {
            super(name,age);
            this.tasks=[`${this.name} is working on a simple task.`];
        };

    }


    class Senior extends Employee{
        constructor(name,age){
            super(name,age);
            this.tasks=[`${this.name} is working on a complicated task.`,
            `${this.name} is taking time off work.`,
            `${this.name} is supervising junior workers.`];
        }

        
    }

    class Manager extends Employee{
        constructor(name,age){
            super(name,age);
            this.dividend=0;
            this.tasks=[`${this.name} scheduled a meeting.`,	
            `${this.name} is preparing a quarterly report.`]
        }

        collectSalary(){
            console.log(`${this.name} received ${this.salary+this.dividend} this month.`);  
        }
    }

    return {
        Employee,
        Junior,
        Senior,
        Manager,
    };
}


const classes = solve();
const junior = new classes.Junior('Ivan', 25);

junior.work();
junior.work();

junior.salary = 5811;
junior.collectSalary();

const sinior = new classes.Senior('Alex', 31);

sinior.work();
sinior.work();
sinior.work();
sinior.work();

sinior.salary = 12050;
sinior.collectSalary();

const manager = new classes.Manager('Tom', 55);

manager.salary = 15000;
manager.collectSalary();
manager.dividend = 2500;
manager.collectSalary();  

