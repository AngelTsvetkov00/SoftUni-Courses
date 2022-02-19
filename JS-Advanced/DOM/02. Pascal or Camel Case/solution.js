function solve() {
  let input = document.getElementById("text").value;
  let currentCase = document.getElementById("naming-convention").value;
  let result = document.getElementById("result");

  if (currentCase != "Camel Case" && currentCase != "Pascal Case") {
    result.textContent = "Error!"
  } else if (currentCase == "Camel Case") {
    let wordsArray = input.split(/\s+/g);

    wordsArray[0] = wordsArray[0].toLowerCase();
    for (let i = 1; i < wordsArray.length; i++) {
      let element = wordsArray[i].split('');
      for (let j = 0; j < element.length; j++) {
        if (j === 0) {
          element[j] = element[j].toUpperCase();
        } else {
          element[j] = element[j].toLowerCase();
        }
      }
      element = element.join('');
      wordsArray[i] = element;
    }
    result.textContent = wordsArray.join('');
  } else if (currentCase == "Pascal Case") {
    let wordsArray = input.split(/\s+/g);

    for (let i = 0; i < wordsArray.length; i++) {
      let element = wordsArray[i].split('');
      for (let j = 0; j < element.length; j++) {
        if (j === 0) {
          element[j] = element[j].toUpperCase();
        } else {
          element[j] = element[j].toLowerCase();
        }
      }
      element = element.join('');
      wordsArray[i] = element;
    }
    result.textContent = wordsArray.join('');
  }
}