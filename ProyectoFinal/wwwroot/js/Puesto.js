$(document).ready(function () {
    GetDepartamentoPuesto();
    $('#departamentoPuesto').change(function () {
        var id = $(this).val();
        $('#Puesto').empty();
        $('#Puesto').append('<option>---Seleccione un Puesto---</option>');
        $.ajax({
            url: '/account/Puesto?id=' + id,
            success: function (result) {
                $.each(result, function (i, data) {
                    $('#Puesto').append('<option value=' + data.id + '>' + data.nombre + '</option>');
                });
            }
        });
    });
})
function GetDepartamentoPuesto() {
    $.ajax({
        url: '/account/DepartamentoTrabajo',
        success: function (result) {
            $.each(result, function (i, data, salary) {
                $('#departamentoPuesto').append('<Option value=' + data.id + '>' + data.nombre + '</option>');
            });
        }
    });
}
