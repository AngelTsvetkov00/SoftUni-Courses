function solve() {
  let divElement = document.getElementById("output");
  let textAreaElement = document.getElementById("input").value;
  let sentences = textAreaElement.split('.').filter(Boolean);
  
  for (let i = 0; i < sentences.length; i += 3) {
    let p = document.createElement("p");
    let counter = i;
    for (let j = counter; j < counter + 3; j++) {
      if (j >= sentences.length) {
        break;
      }
      if (sentences[j].length > 0) {
        p.textContent += `${sentences[j]}.`;
      } 
    }
    divElement.appendChild(p);
  }
}


