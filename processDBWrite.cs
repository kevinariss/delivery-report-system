using System.IO;
using System.Collections.Generic;


namespace Controls
{
    public class processDBWrite : miscSQLiteCommands
    {
        private string companyName;
        private string plateNumber;
        private string invoiceNumber;
        private string traceNumber;
        private string driverName;
        private string weight;
        private string remarks;
        private string date;
        private string screenshotLocation;
        private string screenshotName;
        private string dateTime;
        private byte[] imageData;

        private queryDeliveryDetailTable tableDeliveryDetail = new queryDeliveryDetailTable();
        public processDBWrite(Dictionary<string, string> passedReportData)
        {
            screenshotLocation = passedReportData["screenshotLocation"];
            screenshotName = passedReportData["screenshotName"];
            companyName = passedReportData["companyName"];
            plateNumber = passedReportData["plateNumber"];
            driverName = passedReportData["driverName"];
            weight = passedReportData["weight"];
            invoiceNumber = passedReportData["invoiceNumber"];
            traceNumber = passedReportData["traceNumber"];
            remarks = passedReportData["remarks"];
        }
        public void writeDataToDB()
        {
            executeImageWrite(tableDeliveryDetail.insertDeliveryDetail(screenshotName, driverName, companyName, plateNumber, invoiceNumber, traceNumber, remarks), 
                (byte[])File.ReadAllBytes(screenshotLocation + screenshotName));
            //writeImageToDB();
        }
        private void writeImageToDB()
        {
            try
            {
                //imageData = File.ReadAllBytes(fullScreenshotFileName);
                executeImageWrite(tableDeliveryDetail.addScreenshot(screenshotName), (byte[]) File.ReadAllBytes(screenshotLocation)); //imageData);
            }
            catch
            {
                throw;
            }
        }   
    }
}