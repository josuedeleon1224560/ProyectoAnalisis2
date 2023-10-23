$(document).ready(function () {
    GetDepartamento();

    // Carga inicial de municipios basados en el valor seleccionado de Departamento
    GetMunicipio($('#Departamento').val());

    $('#Departamento').change(function () {
        var id = $(this).val();
        $('#Municipio').empty();
        $('#Municipio').append('<option>--Seleccione Municipio--</option>');
        GetMunicipio(id);
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

    function GetMunicipio(departamentoId) {
        if (departamentoId) {
            $.ajax({
                url: '/user/Municipio?id=' + departamentoId,
                success: function (result) {
                    $.each(result, function (i, data) {
                        $('#Municipio').append('<option value=' + data.id + '>' + data.nombre + '</option>');
                    });
                }
            });
        }
    }
});
