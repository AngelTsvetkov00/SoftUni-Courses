function search() {
   let nums = document.getElementById("towns");
   let listItem = nums.getElementsByTagName("li");
   let searTextElement=document.getElementById("searchText").value;
   let count =0;
   
   for (let town of listItem) {
      if(town.innerHTML.includes(searTextElement)){
         town.style.fontWeight="bold";
         town.style.textDecoration="underline";
         count++;
      }else{
         town.style.fontWeight="normal";
         town.style.textDecoration="none";
      }
   }

   let result = document.getElementById("result");
   result.textContent=`${count} matches found`;
}
