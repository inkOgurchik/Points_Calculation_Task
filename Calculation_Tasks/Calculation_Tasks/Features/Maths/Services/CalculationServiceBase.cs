using Calculation_Tasks.Features.Maths.Data;

namespace Calculation_Tasks.Features.Maths.Services
{
    public class CalculationServiceBase
    {
        protected readonly List<PointData> PointData;

        private event Func<PointData, bool> ValidationEvent;

        public CalculationServiceBase(IReadOnlyCollection<PointData> pointData)
        {
            try
            {
                if (pointData.Count < 16) throw new Exception("Not enough data in file");

                ValidationEvent = (data) => data.X < 0 || data.Y < 0;
                PointData = pointData.Skip(10).Where(ValidationEvent).SkipLast(5).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        protected CalculationServiceBase(List<PointData> pointData, Func<PointData, bool> validationEvent)
        {
            try
            {
                if (pointData.Count < 16) throw new Exception("Not enough data in file");

                ValidationEvent = (data) => data.X < 0 || data.Y < 0;
                ValidationEvent += validationEvent;

                PointData = pointData.Skip(10).Where(ValidationEvent).SkipLast(5).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public List<PointData> GetData()
        {
            return PointData;
        }
    }
}