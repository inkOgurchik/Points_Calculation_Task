using System.Xml.Linq;
using Calculation_Tasks.Features.Maths.Data;

namespace Calculation_Tasks.Features.File.Services
{
    public class XmlFileToPointsConverter : XmlFileReadService
    {
        public XmlFileToPointsConverter(string fileName) : base(fileName)
        {
        
        }

        public static List<PointData> Parse(IEnumerable<XElement>? data)
        {
            var points = new List<PointData>();
            try
            {
                foreach(var row in data)
                {
                    points.Add(new PointData(row.Attribute("Id")?.Value,
                        int.Parse(row.Attribute("X")?.Value),
                        int.Parse(row.Attribute("Y")?.Value)));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        
            return points;
        }
    }
}

