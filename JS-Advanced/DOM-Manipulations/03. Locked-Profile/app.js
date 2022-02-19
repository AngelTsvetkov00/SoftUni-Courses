function lockedProfile() {
    let profileDivs = document.getElementsByClassName('profile');

    for (let i = 0; i < profileDivs.length; i++) {
        profileDivs[i].querySelector('button').addEventListener('click', onClick);
    }

    function onClick(event) {
        let unlockRadio = event.target.parentElement.querySelector('input[value="unlock"]');

        let hiddenInfo = event.target.parentElement.querySelector(`div`);
        console.log(hiddenInfo.id);
        if (unlockRadio.checked == true && hiddenInfo.style.display != 'block') {
            event.target.textContent = 'Hide it';
            hiddenInfo.style.display = 'block';
        } else if (unlockRadio.checked == true) {
            hiddenInfo.style.display = 'none';
            event.target.textContent = 'Show more';
        }
    }
}