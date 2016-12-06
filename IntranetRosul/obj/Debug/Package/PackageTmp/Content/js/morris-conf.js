var Script = function () {

    //morris chart

    $(function () {
      // data stolen from http://howmanyleft.co.uk/vehicle/jaguar_'e'_type
      var tax_data = [
           { period: '2016-01', proyeccion: 8, cumplimiento: 14},
           { period: '2016-02', proyeccion: 14, cumplimiento: 9 },
           { period: '2016-03', proyeccion: 12, cumplimiento: 12 },
           { period: '2016-04', proyeccion: 51, cumplimiento: 6 },
           { period: '2016-05', proyeccion: 45, cumplimiento: 0 },
           { period: '2016-06', proyeccion: 59, cumplimiento: 0 },
           { period: '2016-07', proyeccion: 59, cumplimiento: 0 },
           { period: '2016-08', proyeccion: 19, cumplimiento: 0 },
           { period: '2016-09', proyeccion: 31, cumplimiento: 0 },
           { period: '2016-10', proyeccion: 40, cumplimiento: 9 },
           { period: '2016-11', proyeccion: 62, cumplimiento: 4 },
           { period: '2016-12', proyeccion: 35, cumplimiento: 1 }
      ];
      var tax_data2 = [
             { period: '2016-01', proyeccion: 8, cumplimiento: 14, porc: 6.4 },
             { period: '2016-02', proyeccion: 22, cumplimiento: 23, porc: 17.6 },
             { period: '2016-03', proyeccion: 34, cumplimiento: 35, porc: 27.2 },
             { period: '2016-04', proyeccion: 85, cumplimiento: 41, porc: 68 },
             { period: '2016-05', proyeccion: 130, cumplimiento: 0, porc: 0 },
             { period: '2016-06', proyeccion: 189, cumplimiento: 0, porc: 0 },
             { period: '2016-07', proyeccion: 248, cumplimiento: 0, porc: 0 },
             { period: '2016-08', proyeccion: 267, cumplimiento: 0, porc: 0 },
             { period: '2016-09', proyeccion: 298, cumplimiento: 0, porc: 0 },
             { period: '2016-10', proyeccion: 338, cumplimiento: 9, porc: 270.4 },
             { period: '2016-11', proyeccion: 400, cumplimiento: 13, porc: 320 },
             { period: '2016-12', proyeccion: 435, cumplimiento: 14, porc: 348 }
      ];
            
      var months = ["Ene", "Feb", "Mar", "Abr", "May", "Jun", "Jul", "Agu", "Sep", "Oct", "Nov", "Dic"];

      //Morris.Bar({
      //    element: 'bancos',
      //    data: [
      //      { device: 'iPhone', geekbench: 136 },
      //      { device: 'iPhone 3G', geekbench: 137 },
      //      { device: 'iPhone 3GS', geekbench: 275 },
      //      { device: 'iPhone 4', geekbench: 380 },
      //      { device: 'iPhone 4S', geekbench: 655 },
      //      { device: 'iPhone 5', geekbench: 1571 }
      //    ],
      //    xkey: 'device',
      //    ykeys: ['geekbench'],
      //    labels: ['Geekbench'],
      //    barRatio: 0.4,
      //    xLabelAngle: 35,
      //    hideHover: 'auto',
      //    barColors: ['#ac92ec']
      //});
        Morris.Line({
            element: 'hero-graph',
            data: tax_data,
            xkey: 'period',
            ykeys: ['proyeccion', 'cumplimiento'],
            labels: ['Proyeccion', 'Cumplimiento'],
            xLabelFormat: function (x) { // <--- x.getMonth() returns valid index
                var month = months[x.getMonth()];
                return month;
            },
            dateFormat: function (x) {
                var month = months[new Date(x).getMonth()];
                return month;
            },
            lineColors: ['#4ECDC4', '#ed5565']
        });


        Morris.Line({
            element: 'hero-graph2',
            data: tax_data2,
            xkey: 'period',
            ykeys: ['proyeccion', 'cumplimiento','porc'],
            labels: ['Proyeccion', 'Cumplimiento','Porcentaje'],
            xLabelFormat: function (x) { // <--- x.getMonth() returns valid index
                var month = months[x.getMonth()];
                return month;
            },
            dateFormat: function (x) {
                var month = months[new Date(x).getMonth()];
                return month;
            },
            lineColors: ['#58D3F7', '#81F7D8', '#D0A9F5']
        });

      Morris.Donut({
        element: 'hero-donut',
        data: [
          {label: 'Jam', value: 25 },
          {label: 'Frosted', value: 40 },
          {label: 'Custard', value: 25 },
          {label: 'Sugar', value: 10 }
        ],
          colors: ['#3498db', '#2980b9', '#34495e'],
        formatter: function (y) { return y + "%" }
      });

      Morris.Area({
        element: 'hero-area',
        data: [
          {period: '2010 Q1', iphone: 2666, ipad: null, itouch: 2647},
          {period: '2010 Q2', iphone: 2778, ipad: 2294, itouch: 2441},
          {period: '2010 Q3', iphone: 4912, ipad: 1969, itouch: 2501},
          {period: '2010 Q4', iphone: 3767, ipad: 3597, itouch: 5689},
          {period: '2011 Q1', iphone: 6810, ipad: 1914, itouch: 2293},
          {period: '2011 Q2', iphone: 5670, ipad: 4293, itouch: 1881},
          {period: '2011 Q3', iphone: 4820, ipad: 3795, itouch: 1588},
          {period: '2011 Q4', iphone: 15073, ipad: 5967, itouch: 5175},
          {period: '2012 Q1', iphone: 10687, ipad: 4460, itouch: 2028},
          {period: '2012 Q2', iphone: 8432, ipad: 5713, itouch: 1791}
        ],

          xkey: 'period',
          ykeys: ['iphone', 'ipad', 'itouch'],
          labels: ['iPhone', 'iPad', 'iPod Touch'],
          hideHover: 'auto',
          lineWidth: 1,
          pointSize: 5,
          lineColors: ['#4a8bc2', '#ff6c60', '#a9d86e'],
          fillOpacity: 0.5,
          smooth: true
      });

    

      new Morris.Line({
        element: 'examplefirst',
        xkey: 'year',
        ykeys: ['value'],
        labels: ['Value'],
        data: [
          {year: '2008', value: 20},
          {year: '2009', value: 10},
          {year: '2010', value: 5},
          {year: '2011', value: 5},
          {year: '2012', value: 20}
        ]
      });

      $('.code-example').each(function (index, el) {
        eval($(el).text());
      });
    });

}();




