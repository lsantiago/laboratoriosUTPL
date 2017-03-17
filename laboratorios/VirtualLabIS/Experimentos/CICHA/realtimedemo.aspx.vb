Imports ChartDirector

Partial Class _Default
    Inherits System.Web.UI.Page

    Private Sub drawChart(ByVal viewer As WebChartViewer)

        '
        ' Data to draw the chart. In this demo, the data buffer will be filled by a random data
        ' generator. In real life, the data is probably stored in a buffer (eg. a database table, a text
        ' file, or some global memory) and updated by other means.
        '

        ' We use a data buffer to emulate the last 240 samples.
        Dim sampleSize As Integer = 240
        Dim dataSeries1(sampleSize - 1) As Double
        Dim dataSeries2(sampleSize - 1) As Double
        Dim dataSeries3(sampleSize - 1) As Double
        Dim timeStamps(sampleSize - 1) As Date

        ' Our pseudo random number generator
        Dim firstDate As Date = DateTime.Now.AddSeconds(-timeStamps.Length)
        Dim i As Integer
        For i = 0 To UBound(timeStamps)
            timeStamps(i) = firstDate.AddSeconds(i)
            Dim p As Double = timeStamps(i).Ticks / 10000000
            dataSeries1(i) = Math.Cos(p * 7 * 18463) * 10 + 1 / (Math.Cos(p) * Math.Cos(p) + 0.01) + 20
            dataSeries2(i) = 100 * Math.Sin(p / 27.7) * Math.Sin(p / 10.1) + 150
            dataSeries3(i) = 100 * Math.Cos(p / 6.7) * Math.Cos(p / 11.9) + 150
        Next

        ' Create an XYChart object 600 x 270 pixels in size, with light grey (f4f4f4) background, black
        ' (000000) border, 1 pixel raised effect, and with a rounded frame.
        Dim c As XYChart = New XYChart(600, 270, &HF4F4F4, &H0, 0)
        c.setRoundedFrame()

        ' Set the plotarea at (55, 62) and of size 520 x 175 pixels. Use white (ffffff) background.
        ' Enable both horizontal and vertical grids by setting their colors to grey (cccccc). Set
        ' clipping mode to clip the data lines to the plot area.
        c.setPlotArea(55, 62, 520, 175, &HFFFFFF, -1, -1, &HCCCCCC, &HCCCCCC)
        c.setClipping()

        ' Add a title to the chart using 15 pts Times New Roman Bold Italic font, with a light grey
        ' (dddddd) background, black (000000) border, and a glass like raised effect.
        c.addTitle("Zooming and Scrolling Demonstration", "Times New Roman Bold Italic", 15 _
            ).setBackground(&HDDDDDD, &H0, Chart.glassEffect())

        ' Add a legend box at the top of the plot area with 9pts Arial Bold font. We set the legend box
        ' to the same width as the plot area and use grid layout (as opposed to flow or top/down
        ' layout). This distributes the 3 legend icons evenly on top of the plot area.
        Dim b As LegendBox = c.addLegend2(55, 33, 3, "Arial Bold", 9)
        b.setBackground(Chart.Transparent, Chart.Transparent)
        b.setWidth(520)

        ' Configure the y-axis with a 10pts Arial Bold axis title
        c.yAxis().setTitle("Price (USD)", "Arial Bold", 10)

        ' Configure the x-axis to auto-scale with at least 75 pixels between major tick and 15 pixels
        ' between minor ticks. This shows more minor grid lines on the chart.
        c.xAxis().setTickDensity(75, 15)

        ' Set the axes width to 2 pixels
        c.xAxis().setWidth(2)
        c.yAxis().setWidth(2)

        ' Set the x-axis label format
        c.xAxis().setLabelFormat("{value|hh:nn:ss}")

        ' Create a line layer to plot the lines
        Dim layer As LineLayer = c.addLineLayer2()

        ' The x-coordinates are the timeStamps.
        layer.setXData(timeStamps)

        ' The 3 data series are used to draw 3 lines. Here we put the latest data values as part of the
        ' data set name, so you can see them updated in the legend box.
        layer.addDataSet(dataSeries1, &HFF0000, c.formatValue(dataSeries1(UBound(dataSeries1)), _
            "Software: <*bgColor=FFCCCC*> {value|2} "))
        layer.addDataSet(dataSeries2, &HCC00, c.formatValue(dataSeries2(UBound(dataSeries2)), _
            "Hardware: <*bgColor=CCFFCC*> {value|2} "))
        layer.addDataSet(dataSeries3, &HFF, c.formatValue(dataSeries3(UBound(dataSeries3)), _
            "Services: <*bgColor=CCCCFF*> {value|2} "))

        ' output the chart
        WebChartViewer1.Image = c.makeWebImage(Chart.PNG)

    End Sub

    '
    ' Page Load event handler
    '
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Load

        ' Draw chart using the most update data
        drawChart(WebChartViewer1)

        ' If is streaming request, output the chart immediately and terminate the page
        If WebChartViewer.IsStreamRequest(Page) Then
            WebChartViewer1.StreamChart()
        End If

    End Sub

End Class


