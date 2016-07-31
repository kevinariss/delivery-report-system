using System.IO;

namespace Controls
{
    public class processDBRead : miscSQLiteCommands
    {
        private byte[] imageData;
        private queryDeliveryDetailTable tableScreenshot = new queryDeliveryDetailTable();
        public void readImageFromDB(int screenshotID, string fullOutputFilePath)
        {
            try
            {
                imageData = (byte[]) executeScalar(tableScreenshot.selectScreenshotDataByID(screenshotID));
                File.WriteAllBytes(fullOutputFilePath, imageData);
            }
            catch
            {
                throw;
            }
        }
    }
}
