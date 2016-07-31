using System;
using System.Collections.Generic;
using System.Drawing;

namespace Controls
{
    public class processImageSave
    {
        private string imageLocation;
        private string imageName;
        public void saveScreenshot(Image screenshot, Dictionary<string, string> reportDictionary)
        {
            retrieveDataFromDictionary(reportDictionary);
            screenshot.Save(imageLocation + imageName);
        }
        private void retrieveDataFromDictionary(Dictionary<string, string> reportDictionary)
        {
            imageLocation = reportDictionary["screenshotLocation"];
            imageName = reportDictionary["screenshotName"];
        }
    }
}
