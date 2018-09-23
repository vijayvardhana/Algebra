class DashBoard {
    constructor() {

    }


}

class ReferrerChart {
    constructor() {
        this.url = "/api/dashboard/referrer/"
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