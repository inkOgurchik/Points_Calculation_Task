using Calculation_Tasks.Features.Maths.Data;
using Calculation_Tasks.Features.Maths.Interfaces;

namespace Calculation_Tasks.Features.Maths.Services
{
    public class PointsCalculationService : CalculationServiceBase, ICalculatable
    {
        private const double Tolerance = double.Epsilon;
        
        public PointsCalculationService(List<PointData> pointData)
            : base(pointData, (data) =>
            {

                return Math.Abs(Math.Abs(data.X * data.Y) - 666) > Tolerance &&
                       Math.Abs(Math.Abs((data.X / data.Y)) - 13) > Tolerance &&
                       Math.Abs(Math.Abs((data.Y / data.X)) - 13) > Tolerance;
            })
        {
        }

        public PointsCalculationService(List<PointData> pointData, Func<PointData, bool> validation)
            : base(pointData, validation)
        { }

        public double GetMaxDistance()
        {
            return PointData.Max(data => Math.Sqrt(data.X * data.X + data.Y * data.Y));
        }

        public string? GetPointIdMaxDistance()
        {
            var maxDistance = GetMaxDistance();
            
            return PointData
                .Where((data) => Math.Abs(Math.Sqrt(data.X * data.X + data.Y * data.Y) - maxDistance) < Tolerance)
                .Select(pointData => pointData.Id)
                .FirstOrDefault();
        }

        public int GetPointCount() => PointData.Count;
    }
}