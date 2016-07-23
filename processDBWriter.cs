using System.IO;

namespace Database_Controls
{
    public class processDBWriter : miscSQLiteCommands
    {
        private byte[] imageData;
        private queryScreenshotTable tableScreenshot = new queryScreenshotTable();
        public void writeImageToDB(string screenshotName, string fullInputFilePath)
        {
            try
            {
                imageData = File.ReadAllBytes(fullInputFilePath);
                executeImageWrite(tableScreenshot.addScreenshot(screenshotName), imageData);
            }
            catch
            {
                throw;
            }
        }   
    }
}