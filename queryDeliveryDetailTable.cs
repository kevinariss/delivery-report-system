
namespace Controls
{
    public class queryDeliveryDetailTable
    {
        private string tableName = "Screenshot";
        public string addScreenshot(string screenshotName)
        {
            //return "INSERT INTO " + tableName + "(ID,Name,Data,Delete_Flag) VALUES (NULL,'" + screenshotName + "',@img,'N')";
            return "";
        }
        public string selectScreenshotIDByName(string screenshotName)
        {
            return "SELECT ID FROM " + tableName + " WHERE Name='" + screenshotName + "' AND Delete_Flag='N'";
        }
        public string selectScreenshotDataByID(int imageID)
        {
            return "SELECT Data FROM " + tableName + " WHERE ID=" + imageID + " AND Delete_Flag='N'";
        }
        public string wipeScreenshot(string screenshotName)
        {
            return "DELETE FROM " + tableName + " WHERE Name='" + screenshotName + "'";
        }
        public string insertDeliveryDetail(string dateTime, string driverName, string company, string truck, string invoiceNumber, string traceNumber, string remarks)
        {
            //return "INSERT INTO " + tableName + "(ID,Name,Data,Delete_Flag) VALUES (NULL,'" + screenshotName + "',@img,'N')";
            return "INSERT INTO DeliveryDetail (ID, DateTime, DriverName, CompanyName, TruckPlateNumber, Screenshot, InvoiceNumber, TraceNumber, Remark, Delete_Flag) VALUES (NULL,'" +
                dateTime + "','" + driverName + "','" + company + "','" + truck + "',@img,'" + invoiceNumber + "','" + traceNumber + "','" + remarks + "','N')";
        }
    }
}
