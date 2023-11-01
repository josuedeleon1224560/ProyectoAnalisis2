$(document).ready(function () {
    GetDepartamento();
    $('#Departamento').change(function () {
        var id = $(this).val();
        $('#Municipio').empty();
        $('#Municipio').append('<option>--Seleccione Municipio--</option>');
        $.ajax({
            url: '/user/Municipio?id=' + id,
            success: function (result) {
                $.each(result, function (i, data) {
                    $('#Municipio').append('<option value=' + data.id + '>' + data.nombre + '</option>');
                });
            }
        });
    });
});

function GetDepartamento() {
    $.ajax({
        url: '/user/Departamento',
        success: function (result) {
            $.each(result, function (i, data) {
                $('#Departamento').append('<Option value=' + data.id + '>' + data.nombre + '</option>');
            });
        }
    });
}

