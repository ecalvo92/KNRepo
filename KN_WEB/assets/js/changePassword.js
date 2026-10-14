$(function () {

    $('#changePasswordForm').validate({
        rules: {
            Contrasenna: { required: true },
            ConfirmarContrasenna: { required: true, equalTo: '#Contrasenna' }
        },
        messages: {
            Contrasenna: { required: 'La contraseña es obligatoria' },
            ConfirmarContrasenna: { required: 'Debe confirmar la contraseña', equalTo: 'Las contraseñas no coinciden' }
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