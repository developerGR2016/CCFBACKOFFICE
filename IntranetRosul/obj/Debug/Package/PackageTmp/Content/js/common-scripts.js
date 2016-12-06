/*---LEFT BAR ACCORDION----*/
$(function () {


    

    //$('#datetimepicker1').datetimepicker({

    //        format: 'MM-DD-YYYY'
    //});
    //$('#datetimepicker2').datetimepicker({

    //    format: 'MM-DD-YYYY'
    //});
//    $('#nav-accordion').dcAccordion({
//        eventType: 'click',
//        autoClose: true,
//        saveState: true,
//        disableLink: true,
//        speed: 'slow',
//        showCount: false,
//        autoExpand: true,
////        cookie: 'dcjq-accordion-1',
//        classExpand: 'dcjq-current-parent'
//    });



    // Insert the sum of a column into the columns footer, for the visible
    // data on each draw

    


    $('#resultados').DataTable({
       
        dom: 'Bfrtip',
        buttons: [
             'excel',
            'print'
        ],
        "scrollY": "300px",
        "scrollX": true,
        "scrollCollapse": false,
        "paging":         false,
        "columnDefs": [
            { "visible": false, "targets": 4 }
        ],
        "order": [[4, 'asc']],
        "displayLength": 25,
        "drawCallback": function (settings) {
            var api = this.api();
            var rows = api.rows({ page: 'current' }).nodes();
            var last = null;

            api.column(4, { page: 'current' }).data().each(function (group, i) {
                if (last !== group) {
                    $(rows).eq(i).before(
                        '<tr class="group"><td colspan="6">' + group + '</td></tr>'
                    );

                    last = group;

                }
                else {

                    $(rows).eq(i).before(
                       '<tr class="group"><td colspan="4">TOTAL</td><td>0.00</td><td>0.00</td></tr>'
                   );
                }

             
               
            });
        },
        "footerCallback": function (row, data, start, end, display) {
            var api = this.api(), data;

            // Remove the formatting to get integer data for summation
            var intVal = function (i) {
                return typeof i === 'string' ?
                    i.replace(/[\$,]/g, '') * 1 :
                    typeof i === 'number' ?
                    i : 0;
            };

            // Total over all pages
            total = api
                .column(5)
                .data()
                .reduce(function (a, b) {
                    return intVal(a) + intVal(b);
                }, 0);
            total2 = api
                .column(6)
                .data()
                .reduce(function (a, b) {
                    return intVal(a) + intVal(b);
                }, 0);

            // Total over this page
            pageTotal = api
                .column(5, { page: 'current' })
                .data()
                .reduce(function (a, b) {
                    return intVal(a) + intVal(b);
                }, 0);

            pageTotal2 = api
               .column(6, { page: 'current' })
               .data()
               .reduce(function (a, b) {
                   return intVal(a) + intVal(b);
               }, 0);

            // Update footer
            $(api.column(5).footer()).html(
                '' + pageTotal.toFixed(2) /* + ' ( $' + total + ' total)'*/
            );

            $(api.column(6).footer()).html(
               '' + pageTotal2.toFixed(2) /*+ ' ( $' + total2 + ' total)'*/
           );
        }
    });
    $(".buttons-print span").html("Imprimir");
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
        var urlApi = "http://localhost:64259/EstadoDeCuenta/ResultadosEC/?codeCard=" + codcliente + "&fechaIni=" + fechaIni + "&fechaFin=" + fechaFin
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
    });
});

var Script = function () {


//    sidebar dropdown menu auto scrolling

    jQuery('#sidebar .sub-menu > a').click(function () {
        var o = ($(this).offset());
        diff = 250 - o.top;
        if(diff>0)
            $("#sidebar").scrollTo("-="+Math.abs(diff),500);
        else
            $("#sidebar").scrollTo("+="+Math.abs(diff),500);
    });



//    sidebar toggle

    $(function() {
        function responsiveView() {
            var wSize = $(window).width();
            if (wSize <= 768) {
                $('#container').addClass('sidebar-close');
                $('#sidebar > ul').hide();
            }

            if (wSize > 768) {
                $('#container').removeClass('sidebar-close');
                $('#sidebar > ul').show();
            }
        }
        $(window).on('load', responsiveView);
        $(window).on('resize', responsiveView);
    });

    $('.fa-bars').click(function () {
        if ($('#sidebar > ul').is(":visible") === true) {
            $('#main-content').css({
                'margin-left': '0px'
            });
            $('#sidebar').css({
                'margin-left': '-210px'
            });
            $('#sidebar > ul').hide();
            $("#container").addClass("sidebar-closed");
        } else {
            $('#main-content').css({
                'margin-left': '210px'
            });
            $('#sidebar > ul').show();
            $('#sidebar').css({
                'margin-left': '0'
            });
            $("#container").removeClass("sidebar-closed");
        }
    });

// custom scrollbar
    //$("#sidebar").niceScroll({styler:"fb",cursorcolor:"#4ECDC4", cursorwidth: '3', cursorborderradius: '10px', background: '#404040', spacebarenabled:false, cursorborder: ''});

    //$("html").niceScroll({styler:"fb",cursorcolor:"#4ECDC4", cursorwidth: '6', cursorborderradius: '10px', background: '#404040', spacebarenabled:false,  cursorborder: '', zindex: '1000'});

// widget tools

    jQuery('.panel .tools .fa-chevron-down').click(function () {
        var el = jQuery(this).parents(".panel").children(".panel-body");
        if (jQuery(this).hasClass("fa-chevron-down")) {
            jQuery(this).removeClass("fa-chevron-down").addClass("fa-chevron-up");
            el.slideUp(200);
        } else {
            jQuery(this).removeClass("fa-chevron-up").addClass("fa-chevron-down");
            el.slideDown(200);
        }
    });

    jQuery('.panel .tools .fa-times').click(function () {
        jQuery(this).parents(".panel").parent().remove();
    });


//    tool tips

    $('.tooltips').tooltip();

//    popovers

    $('.popovers').popover();



// custom bar chart

    if ($(".custom-bar-chart")) {
        $(".bar").each(function () {
            var i = $(this).find(".value").html();
            $(this).find(".value").html("");
            $(this).find(".value").animate({
                height: i
            }, 2000)
        })
    }

   
                            


}();