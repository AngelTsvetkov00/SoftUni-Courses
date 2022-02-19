function solve() {
   document.querySelector('#searchBtn').addEventListener('click', onClick);

   function onClick() {
      let table = document.getElementsByClassName("container")[0];
      let inputTextElement = document.getElementById("searchField");
      let inputText=inputTextElement.value;

      //console.log(table.rows[3].getElementsByTagName("td")[0].textContent);

      for (let i = 1; i < table.rows.length; i++) {
         let tableElements = table.rows[i].getElementsByTagName("td");
         for (let j = 0; j < tableElements.length; j++) {
            if(tableElements[j].textContent.includes(inputText)){
               tableElements[j].parentNode.classList.add('select');
               break;
            }else {
               if(tableElements[j].parentNode.classList.contains('select')){
                  tableElements[j].parentNode.classList.remove('select');
               }
            } 
         }
      }
      inputTextElement.value='';
   }
}