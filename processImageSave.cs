using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Controls
{
    public class processImageSave
    {
        public void saveScreenshot(Image image, string imagePath, string imageName)
        {
            image.Save(imagePath + imageName, System.Drawing.Imaging.ImageFormat.Jpeg);
            //save to DB?
        }
    }
}
