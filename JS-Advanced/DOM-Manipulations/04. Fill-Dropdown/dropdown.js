function addItem() {
    let newItemText=document.getElementById('newItemText');
    let newItemValue=document.getElementById('newItemValue');

    let selectMenuElement=document.getElementById('menu');

    let optionElement=document.createElement('option');
    optionElement.textContent=newItemText.value;
    optionElement.value=newItemValue.value;

    newItemText.value='';
    newItemValue.value='';

    selectMenuElement.appendChild(optionElement);
}