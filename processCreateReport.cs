using System;
using Microsoft.Office.Interop.Word;
using System.Collections.Generic;

namespace Controls
{
    public class processCreateReport
    {

        private Application msWordApp = new Application();
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

        //public processCreateReport(string passedscreenshotLocation, string passedCompanyName, string passedTraceNumber, string passedInvoiceNumber, string passedPlateNumber, string passedDriverName, string passedWeight, string passedRemarks)
        //{
        //    screenshotLocation = passedscreenshotLocation;
        //    companyName = passedCompanyName;
        //    plateNumber = passedPlateNumber;
        //    driverName = passedDriverName;
        //    weight = passedWeight;
        //    invoiceNumber = passedInvoiceNumber;
        //    traceNumber = passedTraceNumber;
        //    remarks = passedRemarks;
        //    date = DateTime.Today.ToString("D");

        //}
        public processCreateReport(Dictionary <string, string> passedReportData)
        {
            screenshotLocation = passedReportData["screenshotLocation"];
            companyName = passedReportData["companyName"];
            plateNumber = passedReportData["plateNumber"];
            driverName = passedReportData["driverName"];
            weight = passedReportData["weight"];
            invoiceNumber = passedReportData["invoiceNumber"];
            traceNumber = passedReportData["traceNumber"];
            remarks = passedReportData["remarks"];
            date = passedReportData["date"]; 
        }

        public void createReport()
        {
            //query
            openReportTemplate();
            addDetails();
            insertScreenshot();
            resizeScreenshot();
            switchToPrintPreview();
            showDocument();
        }
        private void openReportTemplate()
        {
            reportTemplate = msWordApp.Documents.Open(@"D:\Projects\Delivery Report System\Report Template\Report Template.docx", ReadOnly: true, Visible: true);
        }
        private void addDetails()
        {
            //string name = doc.Bookmarks["Name"].Range.Text = "Kevin";
            reportTemplate.Bookmarks["CompanyName"].Range.Text = companyName;
            reportTemplate.Bookmarks["Date"].Range.Text = date;
            reportTemplate.Bookmarks["DriverName"].Range.Text = driverName;
            reportTemplate.Bookmarks["DriverNameAndDate"].Range.Text = driverName + "/" + date;
            reportTemplate.Bookmarks["InvoiceNumber"].Range.Text = invoiceNumber;
            reportTemplate.Bookmarks["PlateNumber"].Range.Text = plateNumber;
            reportTemplate.Bookmarks["Remarks"].Range.Text = remarks;
            reportTemplate.Bookmarks["TraceNumber"].Range.Text = traceNumber;
            reportTemplate.Bookmarks["Weight"].Range.Text = weight;
        }
        private void insertScreenshot()
        {
            screenshot = reportTemplate.Bookmarks["Screenshot"].Range.InlineShapes.AddPicture(screenshotLocation); //@"G:\Personal C# Project\Creating Output\Screenshot\Fist_Bite.JPG"
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
        private void showDocument()
        {
            msWordApp.Visible = true;
        }
    }
}
