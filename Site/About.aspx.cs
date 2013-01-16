using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Artem.Google.UI;

public partial class About : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GoogleMap1.EnterpriseKey = "AIzaSyAXe-NlSf2-39t-YM8iqsXoKrZwcHqTe70";
            GoogleMap1.Latitude = 46.06160082;
            GoogleMap1.Longitude = 14.52628776;
            GoogleMap1.Zoom = 14;
            GoogleMap1.MapType = MapType.Roadmap;
        }

        Marker mark = new Marker();
        mark.Position.Latitude = 46.0668122600;
        mark.Position.Longitude = 14.5511734400;
        mark.Title = "IT WORKS ;)";
        mark.Info = "IT ALSO WORKS ;)";
        GoogleMap1.Markers.Add(mark);
    }
    protected void button_Click(object sender, EventArgs e)
    {
        Marker mark = new Marker();
        mark.Position.Latitude = 46.0618122600;
        mark.Position.Longitude = 14.5911734400;
        mark.Title = "NORO ;)";
        mark.Info = "COULD IT BE ;)";
        GoogleMap1.Markers.Add(mark);
    }
}
