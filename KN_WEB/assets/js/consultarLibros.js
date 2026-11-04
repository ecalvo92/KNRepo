$(function () {

    $('#tablaLibros').DataTable({
        pageLength: 10,
        order: [[0, 'desc']],
        columnDefs: [{ targets: 3, orderable: false, searchable: false }],
        language: {
            url: 'https://cdn.datatables.net/plug-ins/1.13.8/i18n/es-ES.json'
        }
    });

});
