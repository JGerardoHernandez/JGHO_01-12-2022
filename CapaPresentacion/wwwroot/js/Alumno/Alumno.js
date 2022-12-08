$(document).ready(function () { //click
    SelectAlumnos();
});

function SelectAlumnos() {
    $.ajax({
        type: 'GET',
        url: 'http://localhost:41245/api/alumno/GetAll',
        success: function (result) { //200 OK
            $('#SelectAlumnos tbody').empty();
            $.each(result, function (i, alumno) {
                var filas = '<tr>'
                    + '<td class="text-center">'
                    + '<button onclick="GetById(' + alumno.idAlumno + ')" class="btn btn-warning bi bi-pen-fill"> </button>'
                    + '</td>'
                    + "<td  id='id'  style='display:none;'>"
                    + alumno.idAlumno + "</td>" + "<td class='text-center'>"
                    + alumno.nombre + "</td>" + "<td class='text-center'>"
                    + alumno.apellidoPaterno + "</ td>" + "<td class='text-center'>"
                    + alumno.apellidoMaterno + "</td>" + "<td class='text-center'>"
                    + alumno.imagen + "</td>"
                    //+ '<td class="text-center">  <a href="#" onclick="return Eliminar(' + subCategoria.IdSubCategoria + ')">' + '<img  style="height: 25px; width: 25px;" src="../img/delete.png" />' + '</a>    </td>'
                    + '<td class="text-center"> <button class="btn btn-danger" onclick="Eliminar(' + alumno.idAlumno + ')"><i class="bi bi-trash-fill"></i></button></td>'

                    + "</tr>";
                $("#SelectAlumnos tbody").append(filas);
            });
        },
        error: function (result) {
            alert('Error en la consulta.');
        }
    });
};

function GetById(idAlumno) {
    $.ajax({
        type: 'GET',
        url: 'http://localhost:41245/api/alumno/GetById' + idAlumno,
        success: function (result) {
            $('#txtIdAlumno').val(result.idAlumno);
            $('#txtNombre').val(result.nombre);
            $('#txtApellidoP').val(result.apellidoPaterno);
            $('#txtApellidoM').val(result.apellidoMaterno);
            $('#Imagen').val(result.imagen);

            $('#ModalUpdate').modal('show');
        },
        error: function (result) {
            alert('Error en la consulta.');
        }


    });

}

function Add(alumno) {

    $.ajax({
        type: 'POST',
        url: 'http://localhost:41245/api/alumno/Add',
        dataType: 'json',
        data: JSON.stringify(alumno),
        contentType: 'application/json; charset=utf-8',
        success: function (result) {
            $('#myModal').modal();
            $('#ModalUpdate').modal('hide');
            SelectAlumnos();
        }
    });
};

function Update(alumno) {

    $.ajax({
        type: 'POST',
        url: 'http://localhost:41245/api/alumno/Update',
        datatype: 'json',
        data: JSON.stringify(alumno),
        contentType: 'application/json; charset=utf-8',
        success: function (result) {
            $('#myModal').modal();
            $('#ModalUpdate').modal('hide');
            SelectAlumnos();
        },
        error: function (result) {
            alert('Error en la consulta.');
        }
    });

};

function Modal() {
    var mostrar = $('#ModalUpdate').modal('show');
    IniciarAlumno();

}

function Eliminar(idAlumno) {

    if (confirm("¿Estas seguro de eliminar el empleado seleccionado?")) {
        $.ajax({
            type: 'GET',
            url: 'http://localhost:41245/api/alumno/Delete' + idAlumno,
            success: function (result) {
                $('#myModal').modal();
                SelectAlumnos();
            },
            error: function (result) {
                alert('Error en la consulta.');
            }
        });

    };
};

function Actualizar() {
    var alumno = {
        IdAlumno: $('#txtIdAlumno').val(),
        Nombre: $('#txtNombre').val(),
        ApellidoPaterno: $('#txtApellidoP').val(),
        ApellidoMaterno: $('#txtApellidoM').val(),
        Imagen: $('#Imagen').val(),
    }

    if (alumno.IdAlumno == '') {
        alumno.IdAlumno = 0,
            Add(alumno);

    }
    else {
        Update(alumno);
    }
}

function IniciarAlumno() {

    var alumno = {
        idAlumno: $('#txtIdAlumno').val(''),
        nombre: $('#txtNombre').val(''),
        apellidoPaterno: $('#txtApellidoP').val(''),
        apellidoMaterno: $('#txtApellidoM').val(''),
        imagen: $('#Imagen').val(''),
    }
}

function validateFile() {
    var allowedExtension = ['png', 'jpg'];
    var fileExtension = document.getElementById('Imagen').value.split('.').pop().toLowerCase();
    var isValidFile = false;
    for (var index in allowedExtension) {
        if (fileExtension === allowedExtension[index]) {
            isValidFile = true;
            break;
        }
    }
    if (!isValidFile) {
        alert('Las extensiones permitidas son : *.' + allowedExtension.join(', *.'));
        document.getElementById('Imagen').value = ""
    }
    return isValidFile;
}
function readURL(input) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();
        reader.onload = function (e) {
            $('#ImgPrevia')
                .attr('src', e.target.result);
        };
        reader.readAsDataURL(input.files[0]);
    }
}