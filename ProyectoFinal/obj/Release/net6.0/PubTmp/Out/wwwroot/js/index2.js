
/*var nav_toggle = document.querySelector(".nav-toggle");
var nav_menu = document.querySelector(".nav-menu");
var Vemail = document.getElementById('Email');
var Vpassword = document.getElementById('Password');

nav_toggle.addEventListener('click', function () {
  nav_menu.classList.toggle("nav-menu_active");
});*/


function calcularEdad() {
    var fechaNacimiento = new Date(document.getElementById("fechaNacimiento").value);
    var fechaActual = new Date();
    fech = fechaNacimiento;
    var diferenciaEnMilisegundos = fechaActual - fechaNacimiento;
    var edadEnMilisegundos = new Date(diferenciaEnMilisegundos);
    var edadAnios = Math.abs(edadEnMilisegundos.getUTCFullYear() - 1970);
    var edadMeses = edadEnMilisegundos.getUTCMonth();
    var edadDias = edadEnMilisegundos.getUTCDate() - 1;
    var resultadoElement = document.getElementById("resultado");
    resultadoElement.textContent = edadAnios + " años, " + edadMeses + " meses, " + edadDias + " días";
}


var price_hour = document.getElementById('hours-ordinary-price');
var number_hours_extra = document.getElementById('number-hours-extra');
var hour_extra_price = document.getElementById('hour-extra-price');
var sells_monts = document.getElementById('sells-monts');
var benefits_monts = document.getElementById('benefits-monts');
var law_bonus = document.getElementById('law-bonus');
var sub_total_salary = document.getElementById('sub-total-salary')

var iggs_share = document.getElementById('iggs-share');
var isr_share = document.getElementById('isr-share');
var advance = document.getElementById('advance');
var loan_share = document.getElementById('loan-share');
var total_discounts = document.getElementById('total-discounts');
var liquid_total = document.getElementById('liquid-total');

var salary_employer_table = document.getElementById('salary-employer-table');
var price_for_hour = document.getElementById('price-for-hour');
var iggs_employer_share = document.getElementById('iggs-employer-share');
var irtra_employer_share = document.getElementById('irtra-employer-share');


function add_family_data() {
    var mostrar_entrada_de_datos_familiares = document.getElementById('view-info-family');
    mostrar_entrada_de_datos_familiares.style.display = "flex";
}

function hidden_family_data() {
    var mostrar_entrada_de_datos_familiares = document.getElementById("view-info-family");
    mostrar_entrada_de_datos_familiares.style.display = "none";
    // eliminar_info_hijos()

}

function add_childrens_info() {
    var add_childrens = document.querySelector(".add-childrens-info");
}

var total_hora_extra;
var totalcomissions;
var salario_p_operaciones;

function calcularNomina() {

    //1 tabla de horas extra y ventas

    calcular_precio_de_horas();

    var result_benefits_sells;
    var law_bonus_monts = 250;
    var result_sub_salary;

    var salary_ordinary = salario_p_operaciones;
    var number_hours_extra_number = parseFloat(number_hours_extra.textContent)
    var number_sells_monts_number = parseFloat(sells_monts.textContent)

    console.log(salary_ordinary)
    console.log(salario_p_operaciones)
    var salary_calculation = salary_ordinary / 30 / 8;
    var hour_prices = salary_calculation.toFixed(2)
    var hour_extra_price_calculation = salary_calculation * 1.5 * number_hours_extra_number;
    var hours_extra_price_decimal = hour_extra_price_calculation.toFixed(2)

    if (number_sells_monts_number >= 400001) {
        result_benefits_sells = number_sells_monts_number * 4.5 / 100;
    } if (number_sells_monts_number > 200000 && number_sells_monts_number <= 400000) {
        result_benefits_sells = number_sells_monts_number * 3.5 / 100;
    }
    if (number_sells_monts_number > 100000 && number_sells_monts_number <= 200001) {
        result_benefits_sells = number_sells_monts_number * 2.5 / 100;
    }
    else if (number_sells_monts_number <= 100001) {
        result_benefits_sells = 0;
    }


    var result_benefits_sells_decimal = result_benefits_sells.toFixed(2);
    result_sub_salary = salary_ordinary + hour_extra_price_calculation + result_benefits_sells + law_bonus_monts;

    var result_sub_salary_decimal = result_sub_salary.toFixed(2);


    price_hour.textContent = hour_prices;
    hour_extra_price.textContent = hours_extra_price_decimal;
    benefits_monts.textContent = result_benefits_sells_decimal;
    law_bonus.textContent = law_bonus_monts;
    sub_total_salary.textContent = result_sub_salary_decimal;

    total_hora_extra = hour_extra_price_calculation;
    totalcomissions = result_benefits_sells
    //2 tabla de descuentos 



    var iggs_total_share = (salary_ordinary + hour_extra_price_calculation + result_benefits_sells) * 4.83 / 100;
    var iggs_total_share_decimal = iggs_total_share.toFixed(2);

    if (salary_ordinary > 4001) {
        var isr_total_share = ((result_sub_salary) - (iggs_total_share + 4000)) * 5 / 100;
        var isr_total_share_decimal = isr_total_share.toFixed(2);
        isr_share.textContent = isr_total_share_decimal;
    }
    else {
        isr_total_share = 0;
        isr_share.textContent = 0;
    }



    var advance_total = salary_ordinary * 45 / 100
    var advance_total_decimal = advance_total.toFixed(2);

    var loan_number = parseFloat(loan_share.textContent);

    var total_discounts_employee = iggs_total_share + isr_total_share + loan_number + advance_total;
    var total_discounts_employee_decimal = total_discounts_employee.toFixed(2);


    iggs_share.textContent = iggs_total_share_decimal;

    advance.textContent = advance_total_decimal;
    total_discounts.textContent = total_discounts_employee_decimal;

    //3 total liquido 
    var total_liquid = (result_sub_salary - total_discounts_employee);
    var total_liquid_decimal = total_liquid.toFixed(2);

    liquid_total.textContent = total_liquid_decimal;

    //4 Tabla de couta patronal 


    salary_employer_table.textContent = salary_ordinary;
    salary_employer_table = salary_ordinary;

    var price_for_hours = salary_employer_table / 30 / 8;
    var price_for_hours_decimal = price_for_hours.toFixed(2);

    var iggs_employer_share_total = salary_employer_table * 10.67 / 100;
    var iggs_employer_share_total_decimal = iggs_employer_share_total.toFixed(2);

    var irtra_employer_share_total = salary_employer_table * 1 / 100;
    var irtra_employer_share_total_decimal = irtra_employer_share_total.toFixed(2);

    price_for_hour.textContent = price_for_hours_decimal;
    iggs_employer_share.textContent = iggs_employer_share_total_decimal;
    irtra_employer_share.textContent = irtra_employer_share_total_decimal;

    var valorLabel = document.getElementById("number-hours-extra").textContent;
    var valorLabel1 = document.getElementById("hour-extra-price").textContent;
    var valorLabel2 = document.getElementById("sells-monts").textContent;
    var valorLabel3 = document.getElementById("producrion-monts").textContent;
    var valorLabel4 = document.getElementById("benefits-monts").textContent;
    var valorLabel5 = document.getElementById("law-bonus").textContent;
    var valorLabel6 = document.getElementById("sub-total-salary").textContent;
    var valorLabel7 = document.getElementById("iggs-share").textContent;
    var valorLabel8 = document.getElementById("isr-share").textContent;
    var valorLabel9 = document.getElementById("advance").textContent;
    var valorLabel10 = document.getElementById("loan-share").textContent;
    var valorLabel11 = document.getElementById("total-discounts").textContent;
    var valorLabel12 = document.getElementById("liquid-total").textContent;

    var valorLabel13 = document.getElementById("salary-employer-table").textContent;    
    var valorLabel14 = document.getElementById("iggs-employer-share").textContent;
    var valorLabel15 = document.getElementById("irtra-employer-share").textContent;
   
    document.getElementById("HorasExtras").value = valorLabel;
    document.getElementById("PrecioHoraExtra").value = valorLabel1;
    document.getElementById("Ventas").value = valorLabel2;
    document.getElementById("Produccion").value = valorLabel3;
    document.getElementById("Comisiones").value = valorLabel4;
    document.getElementById("Bonificaciones").value = valorLabel5;
    document.getElementById("TotalDevengado").value = valorLabel6;
    document.getElementById("IgssUsuario").value = valorLabel7;
    document.getElementById("ISR").value = valorLabel8;
    document.getElementById("Anticipo").value = valorLabel9;
    document.getElementById("Prestamo").value = valorLabel10;
    document.getElementById("TotalDescuentos").value = valorLabel11;
    document.getElementById("TotalLiquido").value = valorLabel12;

    document.getElementById("CuotaPatronalSueldo").value = valorLabel13;
    document.getElementById("CuotaPatronalIGSS").value = valorLabel14;
    document.getElementById("CuotaPatronalIRTRA").value = valorLabel15;    


}

function vaciar_nomina() {
    price_hour.textContent = "";
    hour_extra_price.textContent = "";
    benefits_monts.textContent = "";
    sub_total_salary.textContent = "";
    iggs_share.textContent = "";
    isr_share.textContent = "";
    advance.textContent = "";
    total_discounts.textContent = "";
    liquid_total.textContent = "";
    salary_employer_table.textContent = "";
    price_for_hour.textContent = "";
    iggs_employer_share.textContent = "";
    irtra_employer_share.textContent = "";
    salary - employer - table="";
}

var totalDias;
var promedioDeSueldos;
var promedioDeComisiones;
var salariosOrdinarios;
var comisionesOrdinarias;
var diasTrabajadostotales;
var totalmeses;
var totalHoras_money;


function tabla_sueldos() {
    const tablaSueldos = document.getElementById("tabla-sueldos");
    const sueldos = [];

    for (let fila of tablaSueldos.rows) {
        for (let celda of fila.cells) {
            const label = celda.querySelector("label");
            if (label) {
                const sueldoTexto = label.textContent;
                const sueldo = parseFloat(sueldoTexto.replace("$", ""));
                sueldos.push(sueldo);
            }
        }
    }

    const totalSalarios = sueldos.reduce((acumulador, sueldo) => acumulador + sueldo, 0);
    var totalSalarios_decimal = totalSalarios.toFixed(2);

    const sumaSueldos = sueldos.reduce((acumulador, sueldo) => acumulador + sueldo, 0);
    const promedioSueldos = sumaSueldos / sueldos.length;
    var promedioSueldos_decimal = promedioSueldos.toFixed(2);

    const diasRealesPorMes = [31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31];
    const datosEmpleado = [];
    sueldos.forEach((sueldo, index) => {
        let diasTrabajados = diasRealesPorMes[index % diasRealesPorMes.length];

        if (sueldo === 0) {
            diasTrabajados = 0;
        }

        datosEmpleado.push({ sueldo, diasTrabajados });
    });

    const totalDiasTrabajados = datosEmpleado.reduce((acumulador, dato) => acumulador + dato.diasTrabajados, 0);
    totalDias = totalDiasTrabajados;
    promedioDeSueldos = promedioSueldos;
    salariosOrdinarios = totalSalarios;

}
var total_comisiones_calculadas;

function comisiones() {
    var commissions_table = document.getElementById('commissions-table');
    const comisiones = [];

    for (let fila of commissions_table.rows) {
        for (let celda of fila.cells) {
            const label = celda.querySelector("label");
            if (label) {
                const comisionesTexto = label.textContent;

                const comision = parseFloat(comisionesTexto.replace("$", ""));
                comisiones.push(comision);
            }
        }
    }

    const totalComisiones = comisiones.reduce((acumulador, comision) => acumulador + comision, 0);
    var totalComisiones_decimal = totalComisiones.toFixed(2);

    const sumaComisiones = comisiones.reduce((acumulador, comision) => acumulador + comision, 0);
    const promedioComisiones = sumaComisiones / comisiones.length;

    total_comisiones_calculadas = sumaComisiones;
    promedioDeComisiones = promedioComisiones;
    comisionesOrdinarias = totalComisiones_decimal;
}

function calculo_bono_14() {
    var total_bono_14 = document.getElementById('total-bono-14');
    var salario_con_comisiones = document.getElementById('salario-con-comisiones');
    var promedio_salarios_anuales = document.getElementById('promedio-salarios-anuales');
    var total_sueldos = document.getElementById('total-salarios-anuales')
    var total_dias_trabajados_anuales = document.getElementById('total-dias-trabajados-anuales');
    var promedio_comisiones_anuales = document.getElementById('promedio-comisiones-anuales');
    var total_comisiones_anuales = document.getElementById('total-comisiones-anuales');

    comisiones()
    tabla_sueldos();

    var salario_comisiones_promedios_sumados = promedioDeSueldos + promedioDeComisiones;
    var salario_comisiones_promedios_sumados_decimal = salario_comisiones_promedios_sumados.toFixed(2);

    var total_de_bono_14 = (salario_comisiones_promedios_sumados * totalDias) / 365;
    var total_de_bono_14_decimal = total_de_bono_14.toFixed(2);
    var T_sueldos_decimal = salariosOrdinarios.toFixed(2);
    var salarios_decimal = promedioDeSueldos.toFixed(2);
    var comisiones_decimal = promedioDeComisiones.toFixed(2);
    var T_comisiones_decimal = total_comisiones_calculadas.toFixed(2);

    salario_con_comisiones.textContent = salario_comisiones_promedios_sumados_decimal;
    total_bono_14.textContent = total_de_bono_14_decimal;
    promedio_salarios_anuales.textContent = salarios_decimal;
    total_sueldos.textContent = T_sueldos_decimal;
    total_dias_trabajados_anuales.textContent = totalDias;
    promedio_comisiones_anuales.textContent = comisiones_decimal;
    total_comisiones_anuales.textContent = T_comisiones_decimal;

}

function calcular_aguinaldo() {
    var total_de_dias_trabajados = document.getElementById('total-de-dias-trabajados');
    var promedio_de_sueldos = document.getElementById('promedio-de-sueldos');
    var total_aguinaldo = document.getElementById('total-aguinaldo');
    tabla_sueldos();

    var aguinaldo_total = (totalDias * promedioDeSueldos) / 365;
    var aguinaldo_total_decimal = aguinaldo_total.toFixed(2);

    var promedio_de_sueldos_decimal = promedioDeSueldos.toFixed(2);

    promedio_de_sueldos.textContent = promedio_de_sueldos_decimal;
    total_aguinaldo.textContent = aguinaldo_total_decimal;
    total_de_dias_trabajados.textContent = totalDias;
}



function calcular_precio_de_horas() {
    var salario_base = document.getElementById('salario-base');
    var salary = document.getElementById('salary');
    var input_hours_work = document.getElementById('input-hours-calc');
    var result_price_hours_work = document.getElementById('result-price-hours-work');
    var salary_to_receive = document.getElementById('salary-to-receive');
    var salary_calc = 0;

    var salary_number = parseFloat(salario_base.textContent);
    var input_hours = input_hours_work.value

    var result_parameter_hours = salary_number / 192;
    var result_parameter_hours_decimal = result_parameter_hours.toFixed(2);
    result_price_hours_work.textContent = result_parameter_hours_decimal;
    if (input_hours == 0) {
        return;
    } else {
        salary_calc = input_hours * result_parameter_hours;
        var salary_to_recive_decimal = salary_calc.toFixed(2);

    }

    salary_to_receive.textContent = salary_to_recive_decimal;
    salary.textContent = salary_to_recive_decimal;
    salario_p_operaciones = salary_calc;

    console.log(salario_p_operaciones)
}


function calcular_vacaciones() {
    const tablaSueldos = document.getElementById("tabla-sueldos");
    var total_rdinary_salary = document.getElementById('total-ordinary-salary')
    var total_comosions_calc = document.getElementById('total-comisions-calc')
    var hours_extras = document.getElementById('hours-extras')
    var total_vacations_money = document.getElementById('total-vacations-money')

    const sueldos = [];
    const detecciones = Array(12).fill(0); // Inicializa un arreglo de 12 posiciones con 0s.

    for (let fila of tablaSueldos.rows) {
        for (let celda of fila.cells) {
            const label = celda.querySelector("label");
            if (label) {
                const sueldoTexto = label.textContent;
                const sueldo = parseFloat(sueldoTexto.replace("$", ""));
                sueldos.push(sueldo);
                if (sueldo > 0) {
                    detecciones[sueldos.length - 1] = 1;
                }
            }
        }
    }
    comisiones()
    tabla_sueldos();
    horas_extra_meses();

    const sumatoria = detecciones.reduce((total, valor) => total + valor, 0);

    var total_salary_hourextra_comissions = salariosOrdinarios + totalHoras_money + total_comisiones_calculadas;
    var result_promedio_meses = total_salary_hourextra_comissions / sumatoria;
    var result_salarios_meses = result_promedio_meses / 365;
    var result_vacations = (result_salarios_meses / 2) * totalDias;
    var result_vacations_decimal = result_vacations.toFixed(2)


    console.log(totalDias)
    total_rdinary_salary.textContent = salariosOrdinarios;
    total_comosions_calc.textContent = total_comisiones_calculadas;
    hours_extras.textContent = totalHoras_money;
    total_vacations_money.textContent = result_vacations_decimal;
}

function functions_validated_bono14() {
    var fecha_inicial = document.getElementById('fecha-inicio')
    var fecha_final = document.getElementById('fecha-fin');

    var FechaInicial = new Date(fecha_inicial.value);
    var FechaFinal = new Date(fecha_final.value);

    var dayInitial = FechaInicial.getUTCDate();
    var monthInitial = FechaInicial.getUTCMonth() + 1;

    var dayFinal = FechaFinal.getUTCDate();
    var monthFinal = FechaFinal.getUTCMonth() + 1;


    if (dayInitial == 1 && monthInitial == 7 && dayFinal == 31 && monthFinal == 7) {
        calculo_bono_14();
    } else {
        return;
    }

}

function functions_validated_aguinaldo() {
    var fecha_input_inicial = document.getElementById('fecha-inicio')
    var fecha_input_final = document.getElementById('fecha-fin');

    var FechaInicial = new Date(fecha_input_inicial.value);
    var FechaFinal = new Date(fecha_input_final.value);

    var dayInitial = FechaInicial.getUTCDate();
    var monthInitial = FechaInicial.getUTCMonth() + 1;

    var dayFinal = FechaFinal.getUTCDate();
    var monthFinal = FechaFinal.getUTCMonth() + 1;

    if (dayInitial == 1 && monthInitial == 12 && dayFinal == 31 && monthFinal == 12) {
        calcular_aguinaldo();
    } else {
        return;
    }
}



function functions_validated_nomina() {
    var fecha_input_inicial = document.getElementById('fecha-inicio')
    var fecha_input_final = document.getElementById('fecha-fin');

    var FechaInicial = new Date(fecha_input_inicial.value);
    var FechaFinal = new Date(fecha_input_final.value);

    var dayInitial = FechaInicial.getUTCDate();
    var monthInitial = FechaInicial.getUTCMonth() + 1;

    var dayFinal = FechaFinal.getUTCDate();
    var monthFinal = FechaFinal.getUTCMonth() + 1;

    if (isNaN(dayInitial) || dayInitial == 0) {
        return
    } else if (!isNaN(dayInitial) && !isNaN(dayFinal)) {
        calcularNomina();
        calcular_precio_de_horas();
    }
}

function calcular_indemnizacion() {
    var indemnizacion_total_sueldos = document.getElementById('indemnizacion-total-sueldos');
    var indemnizacion_total_comisiones = document.getElementById('indemnizacion-total-comisiones');
    var indemnizacion_total_horas_extra = document.getElementById('indemnizacion-total-horas-extra');
    var indemnizacion_promedio = document.getElementById('indemnizacion-promedio');
    var indemnizacion_sub_total = document.getElementById('indemnizacion-sub-total');
    var indemnizacion_a_recibir = document.getElementById('indemnizacion-a-recibir');

    tabla_sueldos();
    comisiones();
    horas_extra_meses();

    var promediodesueldos_decimal = salariosOrdinarios.toFixed(2);
    var total_comisiones_calculadas_decimal = total_comisiones_calculadas.toFixed(2);
    var totalHorasMoney_decimal = totalHoras_money.toFixed(2)
    var subtotal_indemnizacion = salariosOrdinarios + total_comisiones_calculadas + totalHoras_money;
    var subtotal_indemnizacion_decimal = subtotal_indemnizacion.toFixed(2);
    var promedio_de_indemnizacion = subtotal_indemnizacion / totalmeses;
    var promedio_de_indemnizacion_decimal = promedio_de_indemnizacion.toFixed(2);
    var total_indenmizacion = (totalDias * promedio_de_indemnizacion) / 365;
    var total_indenmizacion_decimal = total_indenmizacion.toFixed(2);

    indemnizacion_total_sueldos.textContent = promediodesueldos_decimal;
    indemnizacion_total_comisiones.textContent = total_comisiones_calculadas_decimal;
    indemnizacion_total_horas_extra.textContent = totalHorasMoney_decimal;
    indemnizacion_sub_total.textContent = subtotal_indemnizacion_decimal;
    indemnizacion_promedio.textContent = promedio_de_indemnizacion_decimal;
    indemnizacion_a_recibir.textContent = total_indenmizacion_decimal;

    console.log(salariosOrdinarios)
    console.log(total_comisiones_calculadas)
    console.log(totalHoras_money)
    console.log(subtotal_indemnizacion)
    console.log(totalmeses)

}

function horas_extra_meses() {
    var tablaSueldos = document.getElementById('tabla-sueldos')
    var hours_extra_table = document.getElementById('hours-extra-table');

    const extras = [];

    for (let fila of hours_extra_table.rows) {
        for (let celda of fila.cells) {
            const label = celda.querySelector("label");
            if (label) {
                const extraTexto = label.textContent;
                const extra = parseFloat(extraTexto.replace("$", ""));
                extras.push(extra);
            }
        }
    }

    const sueldos = [];
    const detecciones = Array(12).fill(0);

    for (let fila of tablaSueldos.rows) {
        for (let celda of fila.cells) {
            const label = celda.querySelector("label");
            if (label) {
                const sueldoTexto = label.textContent;
                const sueldo = parseFloat(sueldoTexto.replace("$", ""));
                sueldos.push(sueldo);
                if (sueldo > 0) {
                    detecciones[sueldos.length - 1] = 1;
                }
            }
        }
    }
    const totalhorasextra = extras.reduce((acumulador, extra) => acumulador + extra, 0);
    const sumatoria_meses = detecciones.reduce((total, valor) => total + valor, 0);
    totalmeses = sumatoria_meses;
    totalHoras_money = totalhorasextra;
    console.log(totalHoras_money)

}

function add_childrens_info() {
    const contenedor = document.getElementById("contenedor");
    var info_hijos_tittle = document.getElementById('info-hijos-tittle');
    info_hijos_tittle.style.display = "block";
    var contador = 0;

    const nuevoDiv = document.createElement("div");

    const labelNombres = document.createElement("label");
    labelNombres.textContent = "Nombres: ";
    const inputNombres = document.createElement("input");
    inputNombres.type = "text";

    const labelApellidos = document.createElement("label");
    labelApellidos.textContent = "Apellidos: ";
    const inputApellidos = document.createElement("input");
    inputApellidos.type = "text";

    nuevoDiv.appendChild(labelNombres);
    nuevoDiv.appendChild(inputNombres);
    nuevoDiv.appendChild(labelApellidos);
    nuevoDiv.appendChild(inputApellidos);

    contenedor.appendChild(nuevoDiv);

    console.log(contador)
    labelNombres.style.marginLeft = "2rem"
    labelNombres.style.fontFamily = "Arial, Helvetica, sans-serif"

    info_hijos_tittle.style.fontSize = "28px"
    info_hijos_tittle.style.fontFamily = "Arial, Helvetica, sans-serif"
    info_hijos_tittle.style.marginTop = "2rem"
    info_hijos_tittle.style.marginLeft = "3rem"
    info_hijos_tittle.style.marginBottom = "1rem"

    labelNombres.style.marginLeft = "3rem"
    labelApellidos.style.marginLeft = "3rem"

    inputNombres.style.width = "250px"
    inputNombres.style.height = "30px"
    inputNombres.style.borderRadius = "5px"
    inputNombres.style.border = "solid 1px black"
    inputNombres.style.fontSize = "18px"
    inputNombres.style.paddingLeft = "5px"


    inputApellidos.style.width = "250px"
    inputApellidos.style.height = "30px"
    inputApellidos.style.borderRadius = "5px"
    inputApellidos.style.border = "solid 1px black"
    inputApellidos.style.fontSize = "18px"
    inputApellidos.style.paddingLeft = "5px"
    inputApellidos.style.marginBottom = "2rem"

}

/*
function eliminar_info_hijos(){
  const contenedor = document.getElementById("contenedor");
  contador = 1;
  while (contenedor.firstChild) {
    contenedor.removeChild(contenedor.firstChild);
  }
 
}*/

document.addEventListener("DOMContentLoaded", function () {

    cargarVentasRealizadas();


    const ventaForm = document.getElementById("ventaForm");
    ventaForm.addEventListener("submit", function (event) {
        event.preventDefault();
        registrarVenta();
    });


    const cerrarSesionLink = document.getElementById("cerrarSesion");
    cerrarSesionLink.addEventListener("click", function (event) {
        event.preventDefault();
        cerrarSesion();
    });
});

function registrarVenta() {
    const id = document.getElementById("id").value;
    const producto = document.getElementById("producto").value;
    const cantidad = document.getElementById("cantidad").value;
    const precio = document.getElementById("precio").value;

    const ventasRealizadasTable = document.getElementById("ventasRealizadasTable").getElementsByTagName('tbody')[0];
    const newRow = ventasRealizadasTable.insertRow(ventasRealizadasTable.rows.length);
    const newCell1 = newRow.insertCell(0);
    const newCell2 = newRow.insertCell(1);
    const newCell3 = newRow.insertCell(2);
    const newCell4 = newRow.insertCell(3);

    newCell1.innerHTML = id;
    newCell2.innerHTML = producto;
    newCell3.innerHTML = cantidad;
    newCell4.innerHTML = precio;

    document.getElementById("id").value = "";
    document.getElementById("producto").value = "";
    document.getElementById("cantidad").value = "";
    document.getElementById("precio").value = "";


    guardarVentasRealizadas();
}

function guardarVentasRealizadas() {

    const ventasRealizadasTable = document.getElementById("ventasRealizadasTable").getElementsByTagName('tbody')[0];
    const ventasRealizadas = [];

    for (let i = 0; i < ventasRealizadasTable.rows.length; i++) {
        const row = ventasRealizadasTable.rows[i];
        const id = row.cells[0].innerText;
        const producto = row.cells[1].innerText;
        const cantidad = row.cells[2].innerText;
        const precio = row.cells[3].innerText;
        ventasRealizadas.push({ id, producto, cantidad, precio });
    }

    localStorage.setItem('ventasRealizadas', JSON.stringify(ventasRealizadas));
}

function cargarVentasRealizadas() {

    const ventasRealizadasTable = document.getElementById("ventasRealizadasTable").getElementsByTagName('tbody')[0];
    const ventasRealizadasData = localStorage.getItem('ventasRealizadas');

    if (ventasRealizadasData) {
        const ventasRealizadas = JSON.parse(ventasRealizadasData);

        for (const venta of ventasRealizadas) {
            const row = ventasRealizadasTable.insertRow(ventasRealizadasTable.rows.length);
            const cell1 = row.insertCell(0);
            const cell2 = row.insertCell(1);
            const cell3 = row.insertCell(2);
            const cell4 = row.insertCell(3);

            cell1.innerHTML = venta.id;
            cell2.innerHTML = venta.producto;
            cell3.innerHTML = venta.cantidad;
            cell4.innerHTML = venta.precio;
        }
    }
}
function cerrarSesion() {
    const ventasRealizadasTable = document.getElementById("ventasRealizadasTable").getElementsByTagName('tbody')[0];
    ventasRealizadasTable.innerHTML = '';
    localStorage.removeItem('ventasRealizadas');
}
