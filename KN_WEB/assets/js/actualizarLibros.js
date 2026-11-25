$(function () {

    $('#actualizarLibroForm').validate({
        rules: {
            IdLibro: { required: true },
            Titulo: { required: true },
            Autor: { required: true },
            Sinopsis: { required: true },
            Genero: { required: true },
            Portada: { required: true },
            Precio: { required: true, number: true, min: 1 },
            Inventario: { required: true, number: true, min: 0 }
        },
        messages: {
            IdLibro: { required: 'El título es obligatorio' },
            Titulo: { required: 'El título es obligatorio' },
            Autor: { required: 'El Autor es obligatorio' },
            Sinopsis: { required: 'La Sinopsis es obligatoria' },
            Genero: { required: 'El Género es obligatorio' },
            Portada: { required: 'La Portada es obligatoria' },
            Precio: { required: 'El Precio es obligatorio', number: 'Ingrese un precio válido', min: 'El precio debe ser mayor a 0' },
            Inventario: { required: 'El Inventario es obligatorio', number: 'Ingrese un inventario válido', min: 'El inventario debe ser mayor o igual a 0' },
        },
        errorElement: 'div',
        errorClass: 'login-error-message',
        errorPlacement: function (error, element) {
            error.insertAfter(element.closest('.login-input-group'));
        },
        highlight: function (element) {
            $(element).addClass('login-input-invalid');
        },
        unhighlight: function (element) {
            $(element).removeClass('login-input-invalid');
        }
    });

});
