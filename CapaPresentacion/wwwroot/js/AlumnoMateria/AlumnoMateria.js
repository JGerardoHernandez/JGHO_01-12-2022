﻿$(document).ready(function () { //click
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
                    + '</a> ' + '</td>' + "<td id='id' class='d-none'>"
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
                var filas = '<tr>' + "<td style='display: none;'>"
                    + '<a href="#" onclick="(' + idAlumno + ')">'
                    + '</a> ' + '</td>' + "<td  id='id' style='display:none;'>"
                    + idAlumno + "</td>" + "<td class='text-center'>"
                    + materia.materia.nombre + "</td>" + "<td class='text-center'>"
                    + materia.materia.costo + "</td>"
                    //+ '<td class="text-center">  <a href="#" onclick="return Eliminar(' + subCategoria.IdSubCategoria + ')">' + '<img  style="height: 25px; width: 25px;" src="../img/delete.png" />' + '</a>    </td>'
                    + '<td class="text-center"> <button class="btn btn-danger" onclick="Eliminar(' + idAlumno + ',' + materia.materia.idMateria + ')"><span class="bi bi-trash-fill" style="color:#FFFFFF"></span></button></td>'

                    + "</tr>";
                $("#SelectAlumnoMateria tbody").append(filas);
            });
            $("#btnAdd").attr('onclick', 'ObtenerMateriasNoAsignadasAlumno( ' + idAlumno + ')');
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
                var filas = '<tr>' + '<td class="text-center" id ="find-table">'
                    + '<label><input type="checkbox" name="cbox1" id="cbox1" value="'+ materia.materia.idMateria +'"></label>'
                    + '</a> ' + '</td>' + "<td  id='id' class='d-none'>"
                    + idAlumno + "</td>" + "<td class='text-center'>"
                    + materia.materia.nombre + "</td>" + "<td class='text-center'>"
                    + materia.materia.costo + "</td>"
                    //+ '<td class="text-center">  <a href="#" onclick="return Eliminar(' + subCategoria.IdSubCategoria + ')">' + '<img  style="height: 25px; width: 25px;" src="../img/delete.png" />' + '</a>    </td>'
                    + '<td class="text-center"> <button class="btn btn-danger" onclick="Eliminar(' + idAlumno + ',' + materia.idMateria + ')"><span class="bi bi-trash-fill" style="color:#FFFFFF"></span></button></td>'

                    + "</tr>";
                $("#SelectAlumnoMateria tbody").append(filas);
            });
            $("#btnAdd").attr('onclick', 'ListaMaterias( ' + idAlumno + ')');
        },
        error: function (result) {
            alert('Error en la consulta.');
        }
    });
};

function ListaMaterias(idAlumno) {

    var searchIDs = $("#SelectAlumnoMateria input:checkbox:checked").map(function () {
        return $(this).val();
    });
   // AddMateria(idAlumno, searchIDs);
    /*$.each($("#SelectAlumnoMateria input:checkbox:checked")) {*/
};   
