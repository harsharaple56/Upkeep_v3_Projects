using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Upkeep_v3
{
    public partial class TestPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string dirtyXml = "<?xml version=\"1.0\"?><ClsStay_Save xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\"><objPlace><PlaceTitle>Taj Palace</PlaceTitle><PlaceType>1</PlaceType><PropertyType>1</PropertyType><CheckinTime>10:00 AM</CheckinTime><CheckoutTime>10:00 AM</CheckoutTime></objPlace></ClsStay_Save>";

            String unescapedString = Regex.Unescape(dirtyXml);

            String unescapedString2 = Regex.Escape(dirtyXml);

            string abd= Regex.Replace(dirtyXml, @"^""|""$|\\n?", "");
        }
    }
}