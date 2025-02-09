
function activeRead(id) {
 

    let listEl = document.getElementById(id);
    
    if (listEl) {

        let markBook = sessionStorage.getItem(id);

        if(markBook === "true") {
            listEl.style.backgroundColor = "rgb(224, 224, 224)";
            sessionStorage.setItem(id, "false");
        }
        else {
            listEl.style.backgroundColor = "rgb(249, 186, 139)";
            sessionStorage.setItem(id, "true");
        }
       
    } 
    
    
}

window.onload = function () {
    markedBooks();
};


function markedBooks() {
    let allBooks = document.querySelectorAll(".allBooks li");

    for (let i = 0; i < allBooks.length; i++) {
        let markId = allBooks[i].id;
        let markBook = sessionStorage.getItem(markId);
        if(markBook === "true") {
            allBooks[i].style.backgroundColor = "rgb(249, 186, 139)";
        }
    }
}

