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
        private string screenshotLocation;
        private string screenshotName;

        private queryDeliveryDetailTable tableDeliveryDetail = new queryDeliveryDetailTable();

        public void writeDataToDB(Dictionary<string, string> reportDictionary)
        {
            retrieveDataFromDictionary(reportDictionary);
            executeImageWrite(tableDeliveryDetail.insertDeliveryDetail(screenshotName.Replace(".jpg",""), driverName, companyName, plateNumber, invoiceNumber, traceNumber, remarks), 
                (byte[])File.ReadAllBytes(screenshotLocation + screenshotName));
        }
        private void retrieveDataFromDictionary(Dictionary<string, string> reportDictionary)
        {
            companyName = reportDictionary["companyName"];
            plateNumber = reportDictionary["plateNumber"];
            invoiceNumber = reportDictionary["invoiceNumber"];
            traceNumber = reportDictionary["traceNumber"];
            driverName = reportDictionary["driverName"];
            weight = reportDictionary["weight"];
            remarks = reportDictionary["remarks"];
            screenshotName = reportDictionary["screenshotName"];
            screenshotLocation = reportDictionary["screenshotLocation"];
        }  
    }
}