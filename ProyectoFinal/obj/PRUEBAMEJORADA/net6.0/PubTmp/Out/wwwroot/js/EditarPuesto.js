$(document).ready(function () {
    GetDepartamentoPuesto();

    GetPuesto($('#departamentoPuesto').val());

    $('#departamentoPuesto').change(function () {
        var id = $(this).val();
        $('#Puesto').empty();
        $('#Puesto').append('<option>---Seleccione un Puesto---</option>');
        GetPuesto(id);
    });

    function GetDepartamentoPuesto() {
        $.ajax({
            url: '/user/DepartamentoTrabajo',
            success: function (result) {
                $.each(result, function (i, data, salary) {
                    $('#departamentoPuesto').append('<Option value=' + data.id + '>' + data.nombre + '</option>');
                });
            }
        });
    }

    function GetPuesto(puestoDepartamentoId) {
        if (puestoDepartamentoId) {
            $.ajax({
                url: '/user/Puesto?id=' + puestoDepartamentoId,
                success: function (result) {
                    $.each(result, function (i, data) {
                        $('#Puesto').append('<option value=' + data.id + '>' + data.nombre + '</option>');
                    });
                }
            });
        }
    }
});