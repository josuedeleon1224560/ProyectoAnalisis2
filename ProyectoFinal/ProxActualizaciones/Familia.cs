//< script >
//    document.addEventListener('DOMContentLoaded', function() {
//    const familiaresContainer = document.getElementById('familiares-container');
//    const agregarFamiliarButton = document.getElementById('agregar-familiar');

//    // Inicializa un índice
//    let indiceFamiliar = 0;

//    agregarFamiliarButton.addEventListener('click', function() {
//        // Incrementa el índice
//        indiceFamiliar++;

//        // Crea un nuevo conjunto de campos para el familiar
//        const nuevoFamiliar = document.createElement('div');

//        // Añade campos para recopilar datos del familiar
//        nuevoFamiliar.innerHTML = `
//                < h3 > Familiar </ h3 >
//                < label for= "familiares[${indiceFamiliar}].CUI" > CUI:</ label >
//                < input type = "text" name = "familiares[${indiceFamiliar}].CUI" required >

//                < label for= "familiares[${indiceFamiliar}].Nombre" > Nombre:</ label >
//                < input type = "text" name = "familiares[${indiceFamiliar}].Nombre" required >

//                < label for= "familiares[${indiceFamiliar}].Parentesco" > Parentesco:</ label >
//                < input type = "text" name = "familiares[${indiceFamiliar}].Parentesco" required >
//            `;

//            // Agrega el conjunto de campos del familiar al contenedor
//            familiaresContainer.appendChild(nuevoFamiliar);
//        });
//});
//</ script >