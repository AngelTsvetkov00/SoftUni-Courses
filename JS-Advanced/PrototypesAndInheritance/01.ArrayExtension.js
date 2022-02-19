(function solve() {

    Array.prototype.last = function () {

        return this[this.length - 1];

    };

    Array.prototype.skip = function (n) {

        return this.slice(n);

    };

    Array.prototype.take = function (n) {

        return this.slice(0, n);

    };

    Array.prototype.sum = function () {

        const reducer = (accumulator, currrentValue) => accumulator + currrentValue;

        return this.reduce(reducer);

    }

    Array.prototype.average = function () {

        let count = 0;

        const reducer = (accumulator, currrentValue) => accumulator + currrentValue;

        let sum = this.reduce(reducer);

        for (const item of this) {

            count++;

        }

        return sum / count;
    }
})();