using Calculation_Tasks.Features.File.Services;
using Calculation_Tasks.Features.Maths.Services;

namespace Calculation_Tasks.Features.FileCalculations.Services;

public class CalculationHandler
{
    public delegate void CalculationCompleted(string maxDistancePointId);

    public event CalculationCompleted? OnCalculationCompleted;

    public void CalculationExecute()
    {
        var pointsDocument = new XmlFileReadService("in.xml");
        var report = new TxtReportService("out.txt");

        if (!pointsDocument.TryReadData(out var data)) return;

        var pointsList = XmlFileToPointsConverter.Parse(data);

        var calculationService = new PointsCalculationService(pointsList);

        var maxDistance = calculationService.GetMaxDistance();
        var countElements = calculationService.GetPointCount();

        report.CreateReport(new List<double>() { countElements, maxDistance });

        var id = calculationService.GetPointIdMaxDistance();

        if (id != null) OnCalculationCompleted?.Invoke(id);
    }
}