(function () {
    'use strict';

    const catalogo = document.getElementById('catalogo-libros');
    const tarjetas = Array.from(catalogo.querySelectorAll('.catalogo-tarjeta'));

    catalogo.querySelectorAll('.catalogo-portada img').forEach(function (imagen) {
        function mostrarAlternativa() {
            imagen.hidden = true;
        }

        imagen.addEventListener('error', mostrarAlternativa);
        if (imagen.complete && imagen.naturalWidth === 0) {
            mostrarAlternativa();
        }
    });

    const busqueda = document.getElementById('catalogo-busqueda');
    if (!busqueda) return;

    const sinResultados = document.getElementById('catalogo-sin-resultados');
    const estado = document.getElementById('catalogo-estado');

    function normalizar(texto) {
        return texto.toLocaleLowerCase('es').normalize('NFD').replace(/[\u0300-\u036f]/g, '');
    }

    const textos = tarjetas.map(function (tarjeta) {
        return normalizar(tarjeta.dataset.busqueda);
    });

    function filtrar() {
        const terminos = normalizar(busqueda.value.trim()).split(/\s+/).filter(Boolean);
        let visibles = 0;

        tarjetas.forEach(function (tarjeta, indice) {
            const coincide = terminos.every(function (termino) {
                return textos[indice].includes(termino);
            });
            tarjeta.hidden = !coincide;
            if (coincide) visibles++;
        });

        sinResultados.hidden = visibles !== 0;
        estado.textContent = visibles === 1 ? '1 libro encontrado' : visibles + ' libros encontrados';
    }

    busqueda.closest('.catalogo-buscador').hidden = false;
    busqueda.addEventListener('input', filtrar);
    filtrar();
}());
