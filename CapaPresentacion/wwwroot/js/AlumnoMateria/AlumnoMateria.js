$(document).ready(function () { //click
    SelectAlumnoMateria();
});

function SelectAlumnoMateria() {
    $.ajax({
        type: 'GET',
        url: 'http://localhost:41245/api/alumnomateria/GetAll',
        success: function (result) { //200 OK
            $('#SelectAlumnoMateria tbody').empty();
            $.each(result, function (i, alumno) {
                var filas =
                    '<tr>'
                    + '<td class="text-center"> <button class="btn btn-warning bi bi-pen-fill" onclick="ObtenerMateriasAsignadasAlumno(' + alumno.idAlumno + ')"></button></td>' //Editar Boton
                    + '</a> ' + '</td>' + "<td  id='id' class='d-none'>"
                    + alumno.idAlumno + "</td>" + "<td class='text-center'>"
                    + alumno.nombre + " " + alumno.apellidoPaterno + " " + alumno.apellidoMaterno + "</td>"
                    + "</tr>";
                $("#SelectAlumnoMateria tbody").append(filas);
            });
        },
        error: function (result) {
            alert('Error en la consulta.');
        }
    });
};

function ObtenerMateriasAsignadasAlumno(idAlumno) {
    $.ajax({
        type: 'GET',
        url: 'http://localhost:41245/api/alumnomateria/GetById' + idAlumno,
        success: function (result) { //200 OK
            $('#SelectAlumnoMateria tbody').empty();
            $.each(result, function (i, materia) {
                var filas = '<tr>' + '<td class="text-center"> '
                    + '<a href="#" onclick="GetById(' + materia.alumno.idAlumno + ')">'
                    + '<img  style="height: 25px; width: 25px;" src="../img/edit.ico" />'
                    + '</a> ' + '</td>' + "<td  id='id' class='d-none'>"
                    + materia.alumno.idAlumno + "</td>" + "<td class='text-center'>"
                    + materia.materia.nombre + "</td>" + "<td class='text-center'>"
                    + materia.materia.costo + "</td>"
                    //+ '<td class="text-center">  <a href="#" onclick="return Eliminar(' + subCategoria.IdSubCategoria + ')">' + '<img  style="height: 25px; width: 25px;" src="../img/delete.png" />' + '</a>    </td>'
                    + '<td class="text-center"> <button class="btn btn-danger" onclick="Eliminar(' + materia.alumno.idAlumno + ',' + materia.materia.idMateria +')"><span class="bi bi-trash-fill" style="color:#FFFFFF"></span></button></td>'

                    + "</tr>";
                $("#SelectAlumnoMateria tbody").append(filas);
            });
            $("#btnAdd").attr('onclick', 'ObtenerMateriasNoAsignadasAlumno( ' + idAlumno+')');
            //$('<button>agregar materia</button>').click(function () { alert('hi'); });
            //$('<button>add</button>').click(ObtenerMateriasNoAsignadasAlumno(idAlumno));
            
        },
        error: function (result) {
            alert('Error en la consulta.');
        }
    });
};

function Eliminar(idMateria, idAlumno) {

    if (confirm("¿Estas seguro de eliminar la materia seleccionada?")) {
        $.ajax({
            type: 'GET',
            url: 'http://localhost:41245/api/alumnomateria/Delete' + idMateria + '/' + idAlumno,
            success: function (result) {
                $('#myModal').modal();
                SelectMaterias();
            },
            error: function (result) {
                alert('Error en la consulta.');
            }
        });

    };
};

function ObtenerMateriasNoAsignadasAlumno(idAlumno) {
    $.ajax({
        type: 'GET',
        url: 'http://localhost:41245/api/alumnomateria/ObtenerMateriasNoAsignadasAlumno' + idAlumno,
        success: function (result) { //200 OK
            $('#SelectAlumnoMateria tbody').empty();
            $.each(result, function (i, materia) {
                var filas = '<tr>' + '<td class="text-center"> '
                    + '<label><input type="checkbox" id="cbox1" value="'+ materia.materia.idMateria +'"></label>'
                    + '</a> ' + '</td>' + "<td  id='id' class='d-none'>"
                    + materia.alumno.idAlumno + "</td>" + "<td class='text-center'>"
                    + materia.materia.nombre + "</td>" + "<td class='text-center'>"
                    + materia.materia.costo + "</td>"
                    //+ '<td class="text-center">  <a href="#" onclick="return Eliminar(' + subCategoria.IdSubCategoria + ')">' + '<img  style="height: 25px; width: 25px;" src="../img/delete.png" />' + '</a>    </td>'
                    + '<td class="text-center"> <button class="btn btn-danger" onclick="Eliminar(' + materia.alumno.idAlumno + ',' + materia.materia.idMateria + ')"><span class="bi bi-trash-fill" style="color:#FFFFFF"></span></button></td>'

                    + "</tr>";
                $("#SelectAlumnoMateria tbody").append(filas);
            });
        },
        error: function (result) {
            alert('Error en la consulta.');
        }
    });
};

function AlumnoMateriasNoAsignadas() {

    var materia = {
        idMateria: $('#txtIdMateria').val(''),
        nombre: $('#txtNombre').val(''),
        costo: $('#Costo').val(''),
    }
}

function Modal() {
    var mostrar = $('#ModalUpdate').modal('show');
    AlumnoMateriasNoAsignadas();

}