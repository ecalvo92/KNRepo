$(function () {
        
    $('#consultarLibroForm').validate({
        rules: {
            Titulo: { required: true, minlength: 5 }
        },
        messages: {
            Titulo: { required: 'El título es obligatorio', minlength: "Mínimo {0} caracteres." }
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


    $('#registrarLibroForm').validate({
        rules: {
            Titulo: { required: true },
            Autor: { required: true},
            Sinopsis: { required: true},
            Genero: { required: true },
            Portada: { required: true },
            Precio: { required: true, number: true, min: 1 }
        },
        messages: {
            Titulo: { required: 'El título es obligatorio' },
            Autor: { required: 'El Autor es obligatorio' },
            Sinopsis: { required: 'La Sinopsis es obligatoria' },
            Genero: { required: 'El Género es obligatorio' },
            Portada: { required: 'La Portada es obligatoria' },
            Precio: { required: 'El Precio es obligatorio', number: 'Ingrese un precio válido', min: 'El precio debe ser mayor a 0' },
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


    $('#resultadosLibros').on('change', function () {
        var opcion = $(this).find('option:selected');

        if (!this.value) {
            $('#registrarLibroForm').find('#Titulo, #Autor, #Sinopsis, #Portada, #Genero').val('');
            return;
        }

        $('#Titulo').val(this.value);
        $('#Autor').val(opcion.data('autor') || '');
        $('#Sinopsis').val(opcion.data('sinopsis') || '');
        $('#Genero').val(opcion.data('genero') || '');
        $('#Portada').val(opcion.data('portada') || '');
    });

});
