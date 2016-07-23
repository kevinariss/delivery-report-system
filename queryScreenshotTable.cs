
namespace Database_Controls
{
    public class queryScreenshotTable
    {
        private string tableName = "Screenshot";
        public string addScreenshot(string screenshotName)
        {
            return "INSERT INTO " + tableName + "(ID,Name,Data,Delete_Flag) VALUES (NULL,'" + screenshotName + "',@img,'N')";
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
    }
}
