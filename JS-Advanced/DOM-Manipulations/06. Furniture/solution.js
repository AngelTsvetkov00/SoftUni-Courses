function solve() {
  let textAreaElements = document.getElementsByTagName('textarea');
  let buttonElements = document.getElementsByTagName('button');
  let tableBodyElement = document.getElementsByTagName('tbody')[0];

  buttonElements[0].addEventListener('click', () => {
    let furnitures = JSON.parse(textAreaElements[0].value);

    for (let furniture of furnitures) {
      let tableRowElement = document.createElement('tr');

      let furnitureImage = document.createElement('img');
      furnitureImage.src = furniture.img;

      let furnitureName = document.createElement('p');
      furnitureName.textContent = furniture.name;
      
      let furniturePrice = document.createElement('p');
      furniturePrice.textContent = furniture.price;
      
      let furnitureDecFactor = document.createElement('p');
      furnitureDecFactor.textContent = furniture.decFactor;
      
      let furnitureCheckbox = document.createElement('input');
      furnitureCheckbox.type = "checkbox";

      let elementsArray = [furnitureImage, furnitureName, furniturePrice, furnitureDecFactor, furnitureCheckbox];

      for (let i = 0; i < elementsArray.length; i++) {
        let td = document.createElement('td');
        td.appendChild(elementsArray[i]);
        tableRowElement.appendChild(td);
      }
      tableBodyElement.appendChild(tableRowElement);
    }
  })

  buttonElements[1].addEventListener('click', () => {
    let tableRowElements = document.querySelectorAll('tbody > tr');
    let boughtFurniture = [];
    let totalPrice = 0;
    let totalDecFactor = 0;
    let countFurnitures = 0;

    for (let i = 0; i < tableRowElements.length; i++) {
      let tableRowTds = tableRowElements[i].querySelectorAll('td');
      let checkBox = tableRowTds[4].querySelector('input:nth-child(1)');
      
      if (checkBox.checked) {
        boughtFurniture.push(tableRowTds[1].querySelector('p:nth-child(1)').textContent);
        totalPrice += Number(tableRowTds[2].querySelector('p:nth-child(1)').textContent);
        countFurnitures++;
        totalDecFactor += Number(tableRowTds[3].querySelector('p:nth-child(1)').textContent);
      }
    }

    let avgDecFactor=totalDecFactor/countFurnitures;
    
    let outputText=`Bought furniture: ${boughtFurniture.join(', ')}\n`+
    `Total price: ${totalPrice.toFixed(2)}\n`+
    `Average decoration factor: ${avgDecFactor}`;
    
    textAreaElements[1].textContent=outputText;
  })

}