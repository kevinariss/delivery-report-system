using System.IO;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Controls
{
    public class processControl
    {
        private Dictionary<string, string> variableDictionary = new Dictionary<string, string>();
        private processImageSave imageSaver = new processImageSave();
        private processDBWrite dbWriter = new processDBWrite();
        private processCreateReport reportCreator = new processCreateReport();
        public void processData(Dictionary<string, string> reportDictionary, Image screenshot)
        {
            createTempScreenshotCopy(reportDictionary, screenshot);
            saveDataToDB(reportDictionary);
            createWordDocument(reportDictionary);
            deleteTempScreenshotCopy(reportDictionary);
        }
        private void createWordDocument(Dictionary<string, string> reportDictionary)
        {
            variableDictionary.Add("date", reportDictionary["date"]);
            variableDictionary.Add("screenshotLocation", reportDictionary["screenshotLocation"]);
            variableDictionary.Add("screenshotName", reportDictionary["screenshotName"]);
            variableDictionary.Add("companyName", reportDictionary["companyName"]);
            variableDictionary.Add("plateNumber", reportDictionary["plateNumber"]);
            variableDictionary.Add("driverName", reportDictionary["driverName"]);
            variableDictionary.Add("weight", reportDictionary["weight"]);
            variableDictionary.Add("invoiceNumber", reportDictionary["invoiceNumber"]);
            variableDictionary.Add("remarks", reportDictionary["remarks"]);
            reportCreator.createReport(reportDictionary);
            variableDictionary.Clear();
        }
        private void createTempScreenshotCopy(Dictionary<string, string> reportDictionary, Image screenshot)
        {
            variableDictionary.Add("screenshotLocation", reportDictionary["screenshotLocation"]);
            variableDictionary.Add("screenshotName", reportDictionary["screenshotName"]);
            imageSaver.saveScreenshot(screenshot, variableDictionary);
            variableDictionary.Clear();
        }
        private void saveDataToDB(Dictionary<string, string> reportDictionary)
        {
            variableDictionary.Add("driverName", reportDictionary["driverName"]);
            variableDictionary.Add("companyName", reportDictionary["companyName"]);
            variableDictionary.Add("screenshotLocation", reportDictionary["screenshotLocation"]);
            variableDictionary.Add("screenshotName", reportDictionary["screenshotName"]);
            variableDictionary.Add("plateNumber", reportDictionary["plateNumber"]);
            variableDictionary.Add("invoiceNumber", reportDictionary["invoiceNumber"]);
            variableDictionary.Add("traceNumber", reportDictionary["traceNumber"]);
            variableDictionary.Add("remarks", reportDictionary["remarks"]);
            variableDictionary.Add("weight", reportDictionary["weight"]);
            dbWriter.writeDataToDB(variableDictionary);
            variableDictionary.Clear();
        }
        private void deleteTempScreenshotCopy(Dictionary<string, string> reportDictionary)
        {
            File.Delete(reportDictionary["screenshotLocation"] + reportDictionary["screenshotName"]);
        }
    }
}
