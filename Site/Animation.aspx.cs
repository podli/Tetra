using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Artem.Google.UI;

public partial class Animation : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);

        GoogleMarkers GoogleMarker = new GoogleMarkers();

        GoogleMarker.DataLatitudeField = "45.17654";
        GoogleMarker.DataLongitudeField = "14.4967";
        GoogleMarker.TargetControlID = "GoogleMap1";

        GoogleDirections gDirections = new GoogleDirections();
        LatLng gLatLngDestination = new LatLng();
        gLatLngDestination.Latitude = 45.17654;
        gLatLngDestination.Longitude = 14.4967;

        LatLng gLatLngOrigin = new LatLng();
        gLatLngOrigin.Latitude = 46.17654;
        gLatLngOrigin.Longitude = 14.4967;

    }
}