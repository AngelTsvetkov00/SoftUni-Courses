function calculator() {
    let selector1, selector2, resultSelector='';

    let objectToReturn= {
        init: function (sel1, sel2, resultSel) {
            selector1 = document.getElementById('num1');
            selector2 = document.getElementById('num2');
            resultSelector = document.getElementById('result');
        },
        add: function(){
            resultSelector.value=Number(selector1.value)+Number(selector2.value);
        },
        subtract: function(){
            resultSelector.value=Number(selector1.value)-Number(selector2.value);
        }
    }

    return objectToReturn;
}



const calculate = calculator();
calculate.init('#num1', '#num2', '#result');
// let num1 = $('#num1');
// let num2 = $('#num2');
// let res = $('#result');
// num1.val(5);
// num2.val(5);
// obj.add();
