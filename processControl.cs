using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Controls
{
    public class processControl
    {
        private Dictionary<string, string> reportData;

        public processControl(Dictionary<string, string> passedReportData)
        {
            reportData = passedReportData;
        }
        public void produceOutput()
        {
            //writeDataToDB();
            //createWordReport();


            processDBWrite dbWriter = new processDBWrite(reportData);
            dbWriter.writeDataToDB();

            processCreateReport reportCreator = new processCreateReport(reportData);
            reportCreator.createReport();







        }

        private void createWordReport()
        {
            processCreateReport reportCreator = new processCreateReport(reportData);
            reportCreator.createReport();
            
        }
        private void writeDataToDB()
        {

        }
    }
}
