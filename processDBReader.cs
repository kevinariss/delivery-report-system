using System.IO;

namespace Database_Controls
{
    public class processDBReader : miscSQLiteCommands
    {
        private byte[] imageData;
        private queryScreenshotTable tableScreenshot = new queryScreenshotTable();
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
