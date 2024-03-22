var globalList = "";

$(document).ready(function () {
    ListarVehiculos();
});

function ListarVehiculos() {
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "/Home/ListarVehiculos",
        data: JSON.stringify({ IDCliente: IDCliente }),
        dataType: "json",
        async: true,
        cache: false,
        success: function (List) {
            if (List.length > 0) {
                globalList = List;
                GenerarVehiculos(List);
            } else {
                $("#divResult").html("<div class='alert alert-info' role='alert'>No se encontraron registros</div>");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("ocurrrio un error");
            return false;
        }
    });
}

function GenerarVehiculos(List) {
    let html = "<table id='tblResult' class='table table-striped border-bottom'>";
    html += "<thead>";
    html += "<tr>";
    html += "<th>Marca</th>";
    html += "<th>Modelo</th>";
    html += "<th>Placa</th>";
    html += "<th>Acción</th>";
    html += "</tr>";
    html += "</thead>";
    html += "<tbody>";
    for (i = 0; i < List.length; i++) {
        html += "<tr>";
        html += "<th>" + List[i].NombreMarca + "</th>";
        html += "<th>" + List[i].DescripcionModelo + "</th>";
        html += "<th>" + List[i].Placa + "</th>";
        html += "<th>";
        html += "<button type='button' class='btn btn-primary btn-sm' style='margin-right:5px;' title='Editar' onclick='Editar(" + List[i].IDVehiculo + ");'><span class='glyphicon glyphicon-edit' aria-hidden='true''></span></button>";
        html += "<button type='button' class='btn btn-danger btn-sm' title='Eliminar' onclick='Eliminar(" + List[i].IDVehiculo + ");'><span class='glyphicon glyphicon-trash' aria-hidden='true''></span></button>";
        html += "</th>";
        html += "</tr>";
    }
    html += "</tbody>";
    html += "</table>";
    $("#divResult").empty();
    $("#divResult").append(html);
}

$("#btnAtras").click(function () {
    window.location.href = "/Home/GestionClientes";
});

$("#btnNuevo").click(function () {
    Entity = "";
    ModalVehiculo();
});

function Editar(IDVehiculo) {
    var object = {
        IDVehiculo: IDVehiculo
    }
    Entity = object;
    ModalVehiculo();
}

function ModalVehiculo() {
    $.ajax({
        type: "GET",
        url: "/Home/NuevoVehiculo",
        cache: false,
        beforeSend: function () {
            $("#divModalVehiculo").empty();
            $("#divModalVehiculo").modal("show");
        },
        success: function (data) {
            $("#divModalVehiculo").html(data);
        }
    });
}

function Eliminar(IDVehiculo) {
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "/Home/EliminarVehiculo",
        data: JSON.stringify({ IDVehiculo: IDVehiculo }),
        dataType: "json",
        async: true,
        cache: false,
        success: function (retval) {
            ListarVehiculos();
            if (retval > 0) {
                alert("El Vehiculo se elimino correctamente");
            } else {
                alert("No fue posible eliminar el Vehiculo");
                return false;
            }
        },
        error: function (xhr, textStatus, exceptionThrown) {
            alert("ocurrrio un error");
            return false;
        }
    });
}