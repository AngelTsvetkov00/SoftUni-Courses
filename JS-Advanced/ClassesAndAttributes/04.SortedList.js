class List {
    constructor() {
        this.myList = [];
        this.size = 0;
    }

    add(element) {
        this.myList.push(element);
        this.myList.sort((a, b) => {
            return a - b;
        })
        this.size++;
    }

    remove(index) {
        if (index < this.myList.length && index >=0) {
                    this.myList.splice(index, 1);
                    this.size--;  
        }
    }

    get(index) {
        if (!(index >= this.size)) {
            return this.myList[index];
        }
    }
}


let list = new List();
list.add(0);
console.log(list.size);
list.add(1);
console.log(list.size);
list.add(2);
console.log(list.size);
list.add(3);
console.log(list.size);
console.log(list.get(1));
list.remove(1);
console.log(list);
list.remove(2);
console.log(list.size);
