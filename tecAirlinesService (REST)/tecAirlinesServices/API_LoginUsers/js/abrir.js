function createForms() {
    var e = document.getElementById("CBox");
    var value = e.options[e.selectedIndex].value;
    
    for (var i = 0; i < value; i++) {
        var div = document.createElement("div")
        div.id = i;

        var entrada = document.createElement("input");
        entrada.type = "text";
        entrada.id = i;
        entrada.size = "30";
        entrada.class="c";
        entrada.placeholder = "Salida";

        var salida = document.createElement("input");
        salida.type = "text";
        salida.size = "30";
        salida.id = i;
        salida.class="c";
        salida.placeholder = "Destino";

        div.appendChild(entrada);
        div.appendChild(salida);

        var element = document.getElementById("pedro");
        element.appendChild(div);
       
    }
}