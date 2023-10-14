document.addEventListener('DOMContentLoaded', function () {
    const form = document.getElementById('FormularioCrear');

    form.addEventListener('submit', function (event) {
        const nombreInput = form.querySelector('[name="Nombres"]');
        const errorNombre = document.getElementById('errorNombre');
        const nombre = nombreInput.value;

        const ApellidoInput = form.querySelector('[name="Apellidos"]');
        const errorApellido = document.getElementById('errorApellido');
        const apellido = ApellidoInput.value;

        const DireccionInput = form.querySelector('[name="Direccion"]');
        const errorDireccion = document.getElementById('errorDireccion');
        const direccion = DireccionInput.value;

        const DepartamentoGtInput = form.querySelector('[name="DepartamentoGT"]');
        const errorDepartamento = document.getElementById('errorDepartamento');
        const departamentoGt = DepartamentoGtInput.value;

        const MunicipioGtInput = form.querySelector('[name="MunicipioGT"]');
        const errorMunicipio = document.getElementById('errorMunicipio');
        const municipio = MunicipioGtInput.value;

        const FechaInput = form.querySelector('[name="Fecha"]');
        const errorFecha = document.getElementById('errorFecha');

        const TelefonoInput = form.querySelector('[name="Telefono"]');
        const errorTelefono = document.getElementById('errorTelefono');
        const telefono = parseInt(TelefonoInput.value);

        const CuiInput = form.querySelector('[name="Cui"]');
        const errorCui = document.getElementById('errorCui');
        const cui = parseInt(CuiInput.value);

        const GeneroInput = form.querySelector('[name="Genero"]');
        const errorGenero = document.getElementById('errorGenero');
        const genero = GeneroInput.value;

        const RoleInput = form.querySelector('[name="Role"]');
        const errorRole = document.getElementById('errorRole');
        const role = RoleInput.value;

        const DepInput = form.querySelector('[name="Departamento"]');
        const errorDept = document.getElementById('errorDepartamento');
        const departamento = DepInput.value;

        const PuestoInput = form.querySelector('[name="Puesto"]');
        const errorPuesto = document.getElementById('errorPuesto');
        const puesto = PuestoInput.value;

        if (nombre.lenght < 3) {
            errorNombre.textContent = 'El nombre debe contener al menos 3 caracteres';
            errorNombre.style.display = 'block';
        } else {
            errorNombre.textContent = '';
            errorNombre.style.display = 'none';
        }

        if (apellido.lenght < 3) {
            errorApellido.textContent = 'El apellido debe contener al menos 3 caracteres';
            errorApellido.style.display = 'block';
        } else {
            errorApellido.textContent = '';
            errorApellido.style.display = 'none';
        }

        if (direccion.lenght < 5) {
            errorDireccion.textContent = 'La direccion debe tener minimo 5 caracteres';
            errorDireccion.style.display = 'block';
        } else {
            errorDireccion.textContent = '';
            errorDireccion.style.display = 'none';
        }

        if (departamentoGt === '') {
            errorDepartamento.textContent = 'Seleccione una opcion valida';
            errorDepartamento.style.display = 'block';
        } else {
            errorDepartamento.textContent = '';
            errorDepartamento.style.display = 'none';
        }

        if (municipio === '') {
            errorMunicipio.textContent = 'Seleccione una opcion valida';
            errorMunicipio.style.display = 'block';
        } else {
            errorMunicipio.textContent = '';
            errorMunicipio.style.display = 'none';
        }

        if (isNaN(telefono) || edad < 9999999 || edad > 100000000) {
            errorTelefono.textContent = 'El telefono debe contener 8 digitos';
            errorTelefono.style.display = 'block';
        } else {
            errorTelefono.textContent = '';
            errorTelefono.style.display = 'none';
        }
        2912354091001
        if (isNaN(cui) || cui < 999999999999 || cui > 10000000000000) {
            errorCui.textContent = 'El telefono debe contener 8 digitos';
            errorCui.style.display = 'block';
        } else {
            errorCui.textContent = '';
            errorCui.style.display = 'none';
        }

        if (genero === '') {
            errorGenero.textContent = 'Seleccione una opcion valida';
            errorGenero.style.display = 'block';
        } else {
            errorGenero.textContent = '';
            errorGenero.style.display = 'none';
        }

        if (role === '') {
            errorRole.textContent = 'Seleccione una opcion valida';
            errorRole.style.display = 'block';
        } else {
            errorRole.textContent = '';
            errorRole.style.display = 'none';
        }


        if (departamento === '') {
            errorDept.textContent = 'Seleccione una opcion valida';
            errorDept.style.display = 'block';
        } else {
            errorDept.textContent = '';
            errorDept.style.display = 'none';
        }

        if (puesto === '') {
            errorPuesto.textContent = 'Seleccione una opcion valida';
            errorPuesto.style.display = 'block';
        } else {
            errorPuesto.textContent = '';
            errorPuesto.style.display = 'none';
        }
    });
});