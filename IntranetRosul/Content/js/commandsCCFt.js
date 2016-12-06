
$(function () {

$('#datetimepicker1').datetimepicker({

        format: 'MM-DD-YYYY'
});
$('#datetimepicker2').datetimepicker({

    format: 'MM-DD-YYYY'
});
    $('#nav-accordion').dcAccordion({
        eventType: 'click',
        autoClose: true,
        saveState: true,
        disableLink: true,
        speed: 'slow',
        showCount: false,
        autoExpand: true,
//        cookie: 'dcjq-accordion-1',
        classExpand: 'dcjq-current-parent'
    });

    $("#btn_buscar").on("click", function () {
        var codEmpleado = $("#codColaborador").val().substring(0, $("#codColaborador").val().length - 2);
        var fechaIni = $("#fechaIni").val();
        var fechaFin = $("#fechaFin").val();
        var urlApi = "http://192.168.16.13:8093/api-gps/api/Query/get_colaborador_entrada/?colaboradorId=" + codEmpleado + "&fechaIni=" + fechaIni + "&fechaFin=" + fechaFin
        $.ajax({

            type: "GET",
            url: urlApi,
            success: function (data, codEmplado) {

                var html = "";
                html = html + "<table class='table table-bordered table-striped table-condensed'> " +
                       " <thead>" +
                        "    <tr>" +

                        "        <th>PROYECTO</th>" +
                        "        <th>FECHA</th>" +
                        "        <th>HORA ENTRADA</th>" +
                        "        <th>HORA SALIDA</th>" +
                        "    </tr>" +
                        "</thead>" +
                        "<tbody>";
                $.each(data, function (i) {

                    html = html + "</tr>";

                    html = html + "<td>" + data[i].proyecto + "</td>";
                    html = html + "<td>" + data[i].fecha + "</td>";
                    html = html + "<td>" + data[i].entrada + "</td>";
                    html = html + "<td>" + data[i].salida + " </td>";
                    html = html + "</tr>";
                });

                html = html + "</tbody></table>" +



                $(".tablaResultados").html(html);
            },
            error: function (objXMLHttpRequest) {
                console.log("error", objXMLHttpRequest);
            }
        });
    });

    $("#btnConsulta").on("click", function () {
        var codcliente = $("#codeCard").val();
        var fechaIni = $(".fechaIni").val();
        var fechaFin = $(".fechaFin").val();
        var urlApiD = "http://192.168.16.13:8099/consultas/DiasVencidos/?CodeCard=" + codcliente;
        var urlApi = "http://192.168.16.13:8094/EstadoDeCuenta/ResultadosEC/?codeCard=" + codcliente + "&fechaIni=" + fechaIni + "&fechaFin=" + fechaFin
        $.ajax({

            type: "GET",
            url: urlApi,
            success: function (data) {
              
       
                $(".resultadosEC").html(data);
            },
            error: function (objXMLHttpRequest) {
                console.log("error", objXMLHttpRequest);
            }
        });
        $.ajax({

            type: "GET",
            url: urlApiD,
            success: function (data1) {


                $(".bg-dangerCC").html(data1);
            },
            error: function (objXMLHttpRequest) {
                console.log("error", objXMLHttpRequest);
            }
        });
    });

    $("#codfacturas").change(function () {
        var valor = $("#codfacturas").val();
        var factura = valor.split("(");
        var url = "http://192.168.16.13:8099/consultas/facturaDetalle";
        jQuery.ajax({
            async: false,
            type: "GET",
            url: url,
            data: { factura: factura[0] },
            dataType: "json",
            crossDomain: true, 
            context: document.body,
            contentType: 'application/json; charset=utf-8'
        }).success(function (data) {
          
           
            if ($("#montoSaldo").length > 0) {
                $("#montoSaldo").val("");
                $("#montoSaldo").val(data[0].DocCur + " " + data[0].monto);
                $("#montoSaldo").attr('disabled', 'disabled');
            }
            if ($("#montoF").length > 0) {
                $("#montoF").val("");
                $("#montoF").val(data[0].DocCur + " " + data[0].monto);
                $("#montoF").attr('disabled', 'disabled');
            }
            
           

        }
                   );

    });
    $("#crear").on('click', function () {
        var data = new FormData();
        var files = $("#fileUpload").get(0).files;
        $("#path").val($("#fileUpload").val());
        // Add the uploaded image content to the form data collection 
        if (files.length > 0) {
            data.append("UploadedImage", files[0]);
        }
        // Make Ajax request with the contentType = false, and procesDate = false 
        var ajaxRequest = $.ajax({
            type: "POST",
            url: "/notificacionRetencions/Index?codigo=" + $("#codigo").val(),
            contentType: false,
            processData: false,
            data: data
        });
        ajaxRequest.done(function (xhr, textStatus) {
            // Do other operation 
        });
    });
    $("#btnUploadFile").on('click', function () {
        var data = new FormData(); 
        var files = $("#fileUpload").get(0).files;
        $("#path").val($("#fileUpload").val());
        // Add the uploaded image content to the form data collection 
        if (files.length > 0) { 
            data.append("UploadedImage", files[0]); 
        } 
        // Make Ajax request with the contentType = false, and procesDate = false 
        var ajaxRequest = $.ajax({ 
            type: "POST", 
            url: "/notificacionRetencions/Index?codigo="+$("#codigo").val(), 
            contentType: false, 
            processData: false, 
            data: data 
        }); 
        ajaxRequest.done(function (xhr, textStatus) { 
            // Do other operation 
        }); 
    }); 
});

