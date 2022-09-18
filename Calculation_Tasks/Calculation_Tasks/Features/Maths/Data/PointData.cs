namespace Calculation_Tasks.Features.Maths.Data
{
    public struct PointData
    {
        public readonly string Id;
        public readonly double X;
        public readonly double Y;
        
        public PointData(string id, int x, int y)
        {
            Id = id;
            X = x;
            Y = y;
        }
    }
}
