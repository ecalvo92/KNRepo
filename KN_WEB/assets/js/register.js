$(function () {

    $('#registerForm').validate({
        rules: {
            Identificacion: { required: true },
            NombreCompleto: { required: true },
            CorreoElectronico: { required: true, email: true },
            Contrasenna: { required: true }
        },
        messages: {
            Identificacion: { required: 'La identificación es obligatoria' },
            NombreCompleto: { required: 'El nombre es obligatorio' },
            CorreoElectronico: {
                required: 'El correo electrónico es obligatorio',
                email: 'Ingrese un correo electrónico válido'
            },
            Contrasenna: { required: 'La contraseña es obligatoria' }
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

async function ConsultarNombre() {

    let identificacion = document.getElementById("Identificacion").value;
    document.getElementById("NombreCompleto").value = "";

    if (identificacion.length >= 9) { 
        const resp = await fetch(`https://apis.gometa.org/cedulas/${identificacion}`)

        if (resp.ok)
        { 
            const datos = await resp.json();

            if (datos.resultcount >= 1) { 
                document.getElementById("NombreCompleto").value = datos.nombre;
            }
        } 
    }
}