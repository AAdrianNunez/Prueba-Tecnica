var globalList = "";

$(document).ready(function () {
    ListarClientes();
});

function ListarClientes() {
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "/Home/ListarClientes",
        dataType: "json",
        async: true,
        cache: false,
        success: function (List) {
            if (List.length > 0) {
                globalList = List;
                GenerarClientes(List);
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

function GenerarClientes(List) {
    let html = "<table id='tblResult' class='table table-striped border-bottom'>";
    html += "<thead>";
    html += "<tr>";
    html += "<th>Nombre</th>";
    html += "<th>Apellidos</th>";
    html += "<th>DNI</th>";
    html += "<th>Teléfono</th>";
    html += "<th>Email</th>";
    html += "<th>Acción</th>";
    html += "</tr>";
    html += "</thead>";
    html += "<tbody>";
    for (i = 0; i < List.length; i++) {
        html += "<tr>";
        html += "<th>" + List[i].Nombre + "</th>";
        html += "<th>" + List[i].Apellidos + "</th>";
        html += "<th>" + List[i].DNI + "</th>";
        html += "<th>" + List[i].Telefono + "</th>";
        html += "<th>" + List[i].Email + "</th>";
        html += "<th>";
        html += "<button type='button' class='btn btn-primary btn-sm' style='margin-right:5px;' title='Editar' onclick='Editar(" + List[i].IDCliente + ");'><span class='glyphicon glyphicon-edit' aria-hidden='true''></span></button>";
        html += "<button type='button' class='btn btn-warning btn-sm' style='margin-right:5px;' title='Ver Vehiculos' onclick='VerVehiculos(" + List[i].IDCliente + ");'><span class='glyphicon glyphicon-plane' aria-hidden='true''></span></button>";
        html += "<button type='button' class='btn btn-danger btn-sm' title='Eliminar' onclick='Eliminar(" + List[i].IDCliente + ");'><span class='glyphicon glyphicon-trash' aria-hidden='true''></span></button>";
        html += "</th>";
        html += "</tr>";
    }
    html += "</tbody>";
    html += "</table>";
    $("#divResult").empty();
    $("#divResult").append(html);    
}

$("#btnNuevo").click(function () {
    Entity = "";
    ModalCliente();
});

function Editar(IDCliente) {
    var object = {
        IDCliente: IDCliente
    }
    Entity = object;
    ModalCliente();
}

function ModalCliente() {
    $.ajax({
        type: "GET",
        url: "/Home/NuevoCliente",
        cache: false,
        beforeSend: function () {
            $("#divModalCliente").empty();
            $("#divModalCliente").modal("show");
        },
        success: function (data) {
            $("#divModalCliente").html(data);
        }
    });
}

function VerVehiculos(IDCliente) {
    window.location.href = "/Home/GestionVehiculos?IDCliente=" + IDCliente;
}

function Eliminar(IDCliente) {
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "/Home/EliminarCliente",
        data: JSON.stringify({ IDCliente: IDCliente}),
        dataType: "json",
        async: true,
        cache: false,
        success: function (retval) {
            ListarClientes();
            if (retval > 0) {
                alert("El cliente se elimino correctamente");
            } else {
                alert("No fue posible eliminar el cliente");
                return false;
            }
        },
        error: function (xhr, textStatus, exceptionThrown) {
            alert("ocurrrio un error");
            return false;
        }
    });    
}