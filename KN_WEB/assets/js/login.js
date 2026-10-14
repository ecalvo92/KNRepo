$(function() {

    $('#loginForm').validate({
        rules: {
            CorreoElectronico: { required: true, email: true },
            Contrasenna: { required: true }
        },
        messages: {
             CorreoElectronico: {
                required: 'El correo electrónico es obligatorio',
                email: 'Ingrese un correo electrónico válido'
            },
            Contrasenna: { required: 'La contraseña es obligatoria' }
        },
        errorElement: 'div',
        errorClass: 'login-error-message',
        errorPlacement: function(error, element) {
            error.insertAfter(element.closest('.login-input-group'));
        },
        highlight: function(element) {
            $(element).addClass('login-input-invalid');
        },
        unhighlight: function(element) {
            $(element).removeClass('login-input-invalid');
        }
    });

});