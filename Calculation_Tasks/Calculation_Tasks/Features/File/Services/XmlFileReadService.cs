using System.Xml.Linq;

namespace Calculation_Tasks.Features.File.Services
{
    public class XmlFileReadService
    {
        private readonly XDocument _source;

        public XmlFileReadService(string fileName)
        {
            _source = XDocument.Load(fileName);
        }

        public bool TryReadData(out IEnumerable<XElement>? outElements)
        {
            var root = _source.Root;
            if (root == null)
            {
                outElements = null;
                return false;
            }

            var elements = root.Elements();
            
            outElements = elements;
            return true;
        }
    }
}