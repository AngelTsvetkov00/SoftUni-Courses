function toggle() {
    let buttonElement = document.getElementsByClassName("button")[0];
    let divToShowElement=document.getElementById("extra");
    if(buttonElement.textContent=="More"){
        divToShowElement.style.display="block";
        buttonElement.textContent="Less";
    }else{
        divToShowElement.style.display="none";
        buttonElement.textContent="More";
    } 
}