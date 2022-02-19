function create(words) {
   let contentElement = document.getElementById('content');

   for (let i = 0; i < words.length; i++) {
      let newDivElement = document.createElement('div');
      let newParagraphElement = document.createElement('p');
      
      newParagraphElement.textContent = words[i];
      newParagraphElement.style.display = "none";

      newDivElement.appendChild(newParagraphElement);
      contentElement.appendChild(newDivElement);

      contentElement.addEventListener('click', (event) => {
         event.target.children[0].style.display = "block";
      });
   }
}