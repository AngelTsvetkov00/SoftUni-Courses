function generateReport() {
    let table = document.querySelector("table");
    let tableHeaders=document.querySelectorAll("th");
    let checkboxes=document.querySelectorAll("th input");
    let indexesOfCheckedColumns=[];
    let outputArray=[];
    let areaForOutputElement=document.getElementById("output");
    areaForOutputElement.textContent='';

    for (let i = 0; i < checkboxes.length; i++) {
        if(checkboxes[i].checked==true){
            indexesOfCheckedColumns.push(i);
        }else{
            indexesOfCheckedColumns.push(33);
        }       
    }

    for (let i = 1; i < table.rows.length; i++) {
        let personInfo={};
        let tableRowElements = table.rows[i].getElementsByTagName("td");
        for (let i = 0; i < indexesOfCheckedColumns.length; i++) {
            let index=indexesOfCheckedColumns[i];
            if(i==index){
                personInfo[`${tableHeaders[index].textContent.toLowerCase().trim()}`]=tableRowElements[i].textContent;
            }
        }
        outputArray.push(personInfo);
    }
    
    
    areaForOutputElement.textContent=JSON.stringify(outputArray);
}