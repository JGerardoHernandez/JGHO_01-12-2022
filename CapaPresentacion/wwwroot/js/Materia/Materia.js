$(document).ready(function () { //click
    SelectMaterias();
});

function SelectMaterias() {
    $.ajax({
        type: 'GET',
        url: 'http://localhost:41245/api/materia/GetAll',
        success: function (result) { //200 OK
            $('#SelectMaterias tbody').empty();
            $.each(result, function (i, materia) {
                var filas = '<tr>' + '<td class="text-center"> '
                    + '<a href="#" onclick="GetById(' + materia.idMateria + ')">'
                    + '<button class="btn btn-warning bi bi-pen-fill"' 
                    + '</a> ' + '</td>' + "<td  id='id' class='text-center'>"
                    + materia.idMateria + "</td>" + "<td class='text-center'>"
                    + materia.nombre + "</td>" + "<td class='text-center'>"
                    + materia.costo + "</ td>"
                    //+ '<td class="text-center">  <a href="#" onclick="return Eliminar(' + subCategoria.IdSubCategoria + ')">' + '<img  style="height: 25px; width: 25px;" src="../img/delete.png" />' + '</a>    </td>'
                    + '<td class="text-center"> <button class="btn btn-danger" onclick="Eliminar(' + materia.idMateria + ')"><i class="bi bi-trash-fill"></i></button></td>'

                    + "</tr>";
                $("#SelectMaterias tbody").append(filas);
            });
        },
        error: function (result) {
            alert('Error en la consulta.');
        }
    });
};


function GetById(idMateria) {
    $.ajax({
        type: 'GET',
        url: 'http://localhost:41245/api/materia/GetById' + idMateria,
        success: function (result) {
            $('#txtIdMateria').val(result.idMateria);
            $('#txtNombre').val(result.nombre);
            $('#Costo').val(result.costo);

            $('#ModalUpdate').modal('show');
        },
        error: function (result) {
            alert('Error en la consulta.');
        }
    });
}

function Add(materia) {

    $.ajax({
        type: 'POST',
        url: 'http://localhost:41245/api/materia/Add',
        dataType: 'json',
        data: JSON.stringify(materia),
        contentType: 'application/json; charset=utf-8',
        success: function (result) {
            $('#myModal').modal();
            $('#ModalUpdate').modal('hide');
            SelectMaterias();
        }
    });
};

function Update(materia) {

    $.ajax({
        type: 'POST',
        url: 'http://localhost:41245/api/materia/Update',
        datatype: 'json',
        data: JSON.stringify(materia),
        contentType: 'application/json; charset=utf-8',
        success: function (result) {
            $('#myModal').modal();
            $('#ModalUpdate').modal('hide');
            SelectMaterias();
        },
        error: function (result) {
            alert('Error en la consulta.');
        }
    });

};

function Modal() {
    var mostrar = $('#ModalUpdate').modal('show');
    IniciarMateria();

}

function Eliminar(idMateria) {

    if (confirm("¿Estas seguro de eliminar la materia seleccionada?")) {
        $.ajax({
            type: 'GET',
            url: 'http://localhost:41245/api/materia/Delete' + idMateria,
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

function Actualizar() {
    var materia = {
        IdMateria: $('#txtIdMateria').val(),
        Nombre: $('#txtNombre').val(),
        Costo: $('#Costo').val(),
    }

    if (materia.IdMateria == '') {
        materia.IdMateria = 0;
            Add(materia);

    }
    else {
        Update(materia);
    }
}

function IniciarMateria() {

    var materia = {
        idMateria: $('#txtIdMateria').val(''),
        nombre: $('#txtNombre').val(''),
        costo: $('#Costo').val(''),
    }
}