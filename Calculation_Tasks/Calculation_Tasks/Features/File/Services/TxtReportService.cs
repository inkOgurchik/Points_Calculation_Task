using System.Text;

namespace Calculation_Tasks.Features.File.Services
{
    public class TxtReportService
    {
        private readonly FileStream _reportFile;
    
        public TxtReportService(string fileName)
        {
            _reportFile = new FileStream(fileName, FileMode.Append);
        }
        
        public void CreateReport(IEnumerable<double> data)
        {
            byte[] buffer;
            foreach (var record in data)
            {
                buffer = new UTF8Encoding(true).GetBytes(record + " ");
                _reportFile.Write(buffer, 0, buffer.Length);
            }
        }
    }
}

