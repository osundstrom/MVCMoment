
function activeRead(id) {
 

    let listEl = document.getElementById(id);
    
    if (listEl) {
        if(listEl.style.backgroundColor === "yellow") {
            listEl.style.backgroundColor = "rgb(224, 224, 224)";
            console.log("TestIF");
        }
        else {
            listEl.style.backgroundColor = "yellow";
            console.log("testElse");
        }
    } 
    
    
}