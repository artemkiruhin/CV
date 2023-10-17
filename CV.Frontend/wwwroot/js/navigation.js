class Navigator {
    static indexOfActiveLink = localStorage.getItem('activeLinkIndex') || 0;

    clicked = () => {
        let links = document.getElementsByClassName('nav_link');

        for (let i = 0; i < links.length; i++) {
            links[i].addEventListener('click', function () {
                for (let j = 0; j < links.length; j++) {
                    links[j].classList.remove('link_active');
                }
                this.classList.add('link_active');
                Navigator.indexOfActiveLink = i;
                localStorage.setItem('activeLinkIndex', i);
            });
        }

        links[Navigator.indexOfActiveLink].classList.add('link_active');
    }
}

let navigator = new Navigator();
navigator.clicked();
