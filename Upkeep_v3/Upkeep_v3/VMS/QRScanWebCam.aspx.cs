using AForge.Video;
using AForge.Video.DirectShow;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ZXing;

namespace Upkeep_v3.VMS
{
    public partial class QRScanWebCam : System.Web.UI.Page
    {

        FilterInfoCollection FilterInfoCollection;
        VideoCaptureDevice captureDevice;

        protected void Page_Load(object sender, EventArgs e)
        {
            FilterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            //foreach (FilterInfo filterInfo in FilterInfoCollection)
                //ddltp.Items.Add(filterInfo.Name);
           // ddltp.SelectedIndex = 0;
        }

        private void CaptureDevice_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
         //   pictureBox1.Image = (Bitmap)eventArgs.Frame.Clone();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //if (pictureBox1.Image != null)
            //{
            //    BarcodeReader barcodeReader = new BarcodeReader();
            //    Result result = barcodeReader.Decode((Bitmap)pictureBox1.Image);
            //    if (result != null)
            //    {
            //        textBox1.Text = result.ToString();
            //        if (captureDevice.IsRunning)
            //            captureDevice.Stop();
            //    }
            //}
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            //captureDevice = new VideoCaptureDevice(FilterInfoCollection[ddltp.SelectedIndex].MonikerString);
            captureDevice.NewFrame += CaptureDevice_NewFrame;
            captureDevice.Start();
        }

        protected void Timer1_Tick1(object sender, EventArgs e)
        {

        }
    }
}