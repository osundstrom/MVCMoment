

//funktion  för att markera/ avmarkera
function activeRead(id) {
 
    //hittar element baserat på id som skickades med vid klick på knapp
    let listEl = document.getElementById(id);
    
    //om elemntet hittas
    if (listEl) {

        //hämta från session 
        let markBook = sessionStorage.getItem(id);

        //om väördet är true
        if(markBook === "true") {
            listEl.style.backgroundColor = "rgb(224, 224, 224)";
            sessionStorage.setItem(id, "false");
        }
        //Om ej true eller fasle då.
        else {
            listEl.style.backgroundColor = "rgb(249, 186, 139)";
            sessionStorage.setItem(id, "true");
        }
       
    } 
    
    
}

//körs när sidan laddas,
window.onload = function () {
    markedBooks(); 
};

//funktion för att hämta redan markerade
function markedBooks() {
    //hämtar alla element för böcker
    let allBooks = document.querySelectorAll(".allBooks li");
    //loppar igenom allBooks
    for (let i = 0; i < allBooks.length; i++) {
        let markId = allBooks[i].id; //id för respektive bok
        let markBook = sessionStorage.getItem(markId); //hämtar från session
        if(markBook === "true") { // om den var satt till true i session
            allBooks[i].style.backgroundColor = "rgb(249, 186, 139)";
        }
    }
}

