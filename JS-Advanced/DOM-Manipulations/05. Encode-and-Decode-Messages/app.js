function encodeAndDecodeMessages() {
    let containerElement = document.getElementById('container');
    let buttonElements = Array.from(containerElement.querySelectorAll('button'));
    let textAreaElements = Array.from(containerElement.querySelectorAll('textarea'));

    function getChar(c, number) {
        return String.fromCharCode(c.charCodeAt(0) + number);
    }

    function switchChar(textArea, number) {
        let textFromTextArea = textArea.value;
        let textToReturn = '';

        for (let i = 0; i < textFromTextArea.length; i++) {
            textToReturn += getChar(textFromTextArea[i], number);
        }
        return textToReturn;
    }

    buttonElements[0].addEventListener('click', () => {
        textAreaElements[1].value = switchChar(textAreaElements[0], 1);
        textAreaElements[0].value = '';
    })

    buttonElements[1].addEventListener('click', () => {
        textAreaElements[1].value = switchChar(textAreaElements[1], -1);
    })
}