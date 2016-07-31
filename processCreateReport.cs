using System;
using Microsoft.Office.Interop.Word;
using System.Collections.Generic;

namespace Controls
{
    public class processCreateReport
    {
        private Application msWordApp;
        private Document reportTemplate;
        private InlineShape screenshot;
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

        public void createReport(Dictionary<string, string> reportDictionary)
        {
            retrieveDataFromDictionary(reportDictionary);
            getWordApp();
            openReportTemplate();
            addDetails();
            insertScreenshot();
            resizeScreenshot();
            switchToPrintPreview();
        }
        private void retrieveDataFromDictionary(Dictionary<string, string> reportDictionary)
        {
            date = reportDictionary["date"];
            companyName = reportDictionary["companyName"];
            plateNumber = reportDictionary["plateNumber"];
            invoiceNumber = reportDictionary["invoiceNumber"];
            traceNumber = reportDictionary["traceNumber"];
            driverName = reportDictionary["driverName"];
            weight = reportDictionary["weight"];
            remarks = reportDictionary["remarks"];
            screenshotLocation = reportDictionary["screenshotLocation"];
            screenshotName = reportDictionary["screenshotName"];
        }
        private void getWordApp()
        {
            msWordApp = new Application();
            msWordApp.Visible = true;
        }
        private void openReportTemplate()
        {
            reportTemplate = msWordApp.Documents.Open(@"D:\Projects\Delivery Report System\Report Template\Report Template.docx", ReadOnly: true);
        }
        private void addDetails()
        {
            reportTemplate.Bookmarks["CompanyName"].Range.Text = companyName;
            reportTemplate.Bookmarks["Date"].Range.Text = date;
            reportTemplate.Bookmarks["DriverName"].Range.Text = driverName;
            reportTemplate.Bookmarks["DriverNameAndDate"].Range.Text = driverName + " / " + date;
            reportTemplate.Bookmarks["InvoiceNumber"].Range.Text = invoiceNumber;
            reportTemplate.Bookmarks["PlateNumber"].Range.Text = plateNumber;
            reportTemplate.Bookmarks["Remarks"].Range.Text = remarks;
            reportTemplate.Bookmarks["TraceNumber"].Range.Text = traceNumber;
            reportTemplate.Bookmarks["Weight"].Range.Text = weight;
        }
        private void insertScreenshot()
        {
            screenshot = reportTemplate.Bookmarks["Screenshot"].Range.InlineShapes.AddPicture(screenshotLocation + screenshotName);
        }
        private void resizeScreenshot()
        {
            screenshot.Height = 309;
            screenshot.Width = 449;
        }
        private void switchToPrintPreview()
        {
            msWordApp.PrintPreview = true;
        }
    }
}
