class DashBoard {
    constructor() {
        var pichart = new ReferrerChart();
        var areachart = new AreaChart();
        var columnChart = new ColumnChart();
        var donutChart = new DonutChart();
        var lineChart = new LineChart();
        var barChart = new BarChart();
    }
}

class ReferrerChart {
    constructor() {
        this.loadChart();
    }

    loadChart() {
        google.charts.setOnLoadCallback(this.drawChart);
    }

    drawChart() {

        var jsonData = GetJSONData(Chart.PIE);

        var data = new google.visualization.DataTable();
        data.addColumn('string', 'Name');
        data.addColumn('number', 'Count');

        $.each(jsonData, function (i, chart) {
                console.log(chart);
            data.addRow([chart[0], parseInt(chart[1])]);
        });

        var options = {
            title: 'Members added by Referrers',
            is3D: true
            };

            var chart = new google.visualization.PieChart(document.getElementById('piechart'));

        chart.draw(data, options);
    }
}

class AreaChart {
    constructor() {
        this.loadChart();
    }

    loadChart() {
        google.charts.setOnLoadCallback(this.drawChart);
    }

    drawChart() {
        var data = google.visualization.arrayToDataTable([
            ['Year', 'New', 'Renewal'],
            ['2015', 1000, 400],
            ['2016', 1170, 460],
            ['2017', 660, 1120],
            ['2018', 1030, 540]
        ]);

        var options = {
            title: 'Member Add/Renew Performance',
            hAxis: { title: 'Year', titleTextStyle: { color: '#333' } },
            vAxis: { minValue: 0 }
        };

        var chart = new google.visualization.AreaChart(document.getElementById('areachart'));
        chart.draw(data, options);
    }
}

class ColumnChart {
    constructor() {
        this.loadChart();
    }
    loadChart() {
        google.charts.setOnLoadCallback(this.drawChart);
    }
    drawChart() {
        var jsonData = GetJSONData(Chart.COL);
        var data = new google.visualization.DataTable();
        data.addColumn('string', 'Payment Mode');
        data.addColumn('number', 'Count');

        $.each(jsonData, function (i, chart) {
            console.log(chart);
            data.addRow([chart[0], parseInt(chart[1])]);
        });

        var options = {
            title: 'Payment mode for membership',
            colors: ['#9575cd', '#33ac71'],
            legend: { position: 'top' }
        };

        var chart = new google.visualization.ColumnChart(document.getElementById('columnchart'));

        chart.draw(data, options);
    }
}

class DonutChart {
    constructor() {
        this.loadChart();
    }

    loadChart() {
        google.charts.setOnLoadCallback(this.drawChart);
    }

    drawChart() {

        var data = google.visualization.arrayToDataTable([
            ['Location', 'Members'],
            ['Bangalore', 110],
            ['Goa', 25],
            ['Chennai', 50],
            ['Delhi', 150],
            ['Gurgaon', 200]
        ]);

        var options = {
            title: 'Members by location',
            pieHole: 0.4,
        };

        var chart = new google.visualization.PieChart(document.getElementById('donutchart'));

        chart.draw(data, options);
    }
}

class LineChart {
    constructor() {
        this.loadChart();
    }

    loadChart() {
        google.charts.setOnLoadCallback(this.drawChart);
    }

    drawChart() {

        var data = google.visualization.arrayToDataTable([
            ['Month', 'New', 'Renew'],
            ['JUN', 100, 36],
            ['JUL', 150, 46],
            ['AUG', 66, 112],
            ['SEP', 103, 54]
        ]);

        var options = {
            title: 'Add/Renew members monthly',
            curveType: 'function',
            legend: { position: 'bottom' }
        };

        var chart = new google.visualization.LineChart(document.getElementById('curvelinechart'));

        chart.draw(data, options);
    }
}

class BarChart {
    constructor() {
        this.loadChart();
    }
    loadChart() {
        google.charts.setOnLoadCallback(this.drawChart);
    }
    drawChart() {
        var jsonData = GetJSONData(Chart.BAR);
        var data = new google.visualization.DataTable();
        data.addColumn('string', 'Membership Type');
        data.addColumn('number', 'Count');

        $.each(jsonData, function (i, chart) {
            console.log(chart);
            data.addRow([chart[0], parseInt(chart[1])]);
        });

        var options = {
            title: 'Members by category',
            colors: ['#880E4F'],
            legend: { position: 'none' }
        };

        var chart = new google.visualization.BarChart(document.getElementById('barchart'));

        chart.draw(data, options);
    }
}