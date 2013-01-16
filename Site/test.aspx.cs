using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Artem.Google.UI;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
        {
            AllDefaultDiv.Visible = true;
            AllDefaultDivNotLoggedIn.Visible = false;
        }
        lblLogout.Text = "Prijavite se desno zgoraj.";

        if (!IsPostBack)
        {
            BindPrimaryGrid();
            BindSecondaryGrid();
            CheckBox chkAll = (CheckBox)gvAll.HeaderRow.Cells[0].FindControl("chkAll");
            chkAll.Checked = true;
            CheckBox_CheckChanged(sender, e);
        }
        else
        {
            if (pollSlider.Style["margin-right"] == "300px")
            {
                pollSlider.Style.Add("margin-right", "-300px");
                pollSliderButton.Style.Add("margin-right", "0px");
                pollSliderButton.Style.Add("background-image", "url(images/arrowOpen.png)");
            }
            else
            {
                pollSlider.Style.Add("margin-right", "0px");
                pollSliderButton.Style.Add("margin-right", "300px");
                pollSliderButton.Style.Add("background-image", "url(images/arrowClose.png)");
                
            }
        }
    }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        GoogleMarkers GoogleMarker = new GoogleMarkers();

        GoogleMarker.DataLatitudeField = "45.17654";
        GoogleMarker.DataLongitudeField = "14.4967";
        GoogleMarker.TargetControlID = "GoogleMap1";


        Label1.Text = "Osveženo: " + DateTime.Now.ToLongTimeString();
        /****************        START FOR DEBUG ONLY SET TO TRUE          ****************/

        gridPostajeLast.Visible = false;
        GridPostaje.Visible = false;
        gvDrawOnMap.Visible = false;

        /****************         END FOR DEBUG ONLY  SET TO TRUE          ****************/

        /****************        START IF NEEDED LIST MARKERS           ****************/

        //IEnumerable<Marker> markerArray = new List<Marker>()
        //{ 
        //    new Marker {Title = GridHidden.Rows[i].Cells[0].Text, Position = (GridHidden.Rows[i].Cells[1].Text + "," + GridHidden.Rows[i].Cells[2].Text) ,AutoOpen = false, Info = "Info Markerja"},  
        //};
        //    GoogleMap1.Markers.Add(markerArray);
        /****************        END IF NEEDED LIST MARKERS           ****************/
    }

    protected void Markers_Add_Last_From_gvDrawOnMap()
    {
        for (int i = 0; i < gvDrawOnMap.Rows.Count; i++)
        {
            if (i == (gvDrawOnMap.Rows.Count - 1))
            {
                Marker mark = new Marker();
                mark.Position.Latitude = Convert.ToDouble(gvDrawOnMap.Rows[i].Cells[2].Text);
                mark.Position.Longitude = Convert.ToDouble(gvDrawOnMap.Rows[i].Cells[3].Text);

                string TitleText;
                if (Convert.ToInt16(gvDrawOnMap.Rows[i].Cells[7].Text) < 10)
                    TitleText = "R0" + gvDrawOnMap.Rows[i].Cells[7].Text;
                else
                    TitleText = "R" + gvDrawOnMap.Rows[i].Cells[7].Text;
                mark.Title = TitleText;

                /****************   START VECHILE EQUIPMENT     **************************/
                string InfoText;
                if (Convert.ToInt16(gvDrawOnMap.Rows[i].Cells[7].Text) < 10)
                    InfoText = "<p style='text-align:left'><b>ID vozila: R0" + gvDrawOnMap.Rows[i].Cells[7].Text + "</b></p>" + "<p style='text-align:left'>Oprema vozila:<br>";
                else
                    InfoText = "<p style='text-align:left'><b>ID vozila: R" + gvDrawOnMap.Rows[i].Cells[7].Text + "</b></p>" + "<p style='text-align:left'>Oprema vozila:<br>";

                if (((CheckBox)gvDrawOnMap.Rows[i].Cells[8].Controls[0]).Checked)
                    InfoText = InfoText + "- Jopič<br>";
                if (((CheckBox)gvDrawOnMap.Rows[i].Cells[9].Controls[0]).Checked)
                    InfoText = InfoText + "- Čelada<br>";
                if (((CheckBox)gvDrawOnMap.Rows[i].Cells[10].Controls[0]).Checked)
                    InfoText = InfoText + "- Triopan<br>";
                if (((CheckBox)gvDrawOnMap.Rows[i].Cells[11].Controls[0]).Checked)
                    InfoText = InfoText + "-  Trak<br></p>";
                /****************   END VECHILE EQUIPMENT     **************************/

                

                if (((CheckBox)gvDrawOnMap.Rows[i].Cells[6].Controls[0]).Checked)
                {
                    mark.Icon = "./Images/alarm.gif";
                    InfoText = InfoText + "<h2>SPROŽEN ALARM</h2>";
                }
                else

                    mark.Icon = "./Images/" + gvDrawOnMap.Rows[i].Cells[7].Text + ".png";

                mark.Info = InfoText;
                InfoWindowOptions infoOptions = new InfoWindowOptions();

                GoogleMap1.Markers.Add(mark);
            }
            else
            {
                if (Convert.ToInt32(gvDrawOnMap.Rows[i].Cells[1].Text) != Convert.ToInt32(gvDrawOnMap.Rows[(i + 1)].Cells[1].Text))
                {
                    Marker mark = new Marker();
                    mark.Position.Latitude = Convert.ToDouble(gvDrawOnMap.Rows[i].Cells[2].Text);
                    mark.Position.Longitude = Convert.ToDouble(gvDrawOnMap.Rows[i].Cells[3].Text);

                    string TitleText;
                    if (Convert.ToInt16(gvDrawOnMap.Rows[i].Cells[7].Text) < 10)
                        TitleText = "R0" + gvDrawOnMap.Rows[i].Cells[7].Text;
                    else
                        TitleText = "R" + gvDrawOnMap.Rows[i].Cells[7].Text;
                    mark.Title = TitleText;

                    /****************   START VECHILE EQUIPMENT     **************************/
                    string InfoText;
                    if (Convert.ToInt16(gvDrawOnMap.Rows[i].Cells[7].Text) < 10)
                        InfoText = "<p style='text-align:left'><b>ID vozila: R0" + gvDrawOnMap.Rows[i].Cells[7].Text + "</b></p>" + "<p style='text-align:left'>Oprema vozila:<br>";
                    else
                        InfoText = "<p style='text-align:left'><b>ID vozila: R" + gvDrawOnMap.Rows[i].Cells[7].Text + "</b></p>" + "<p style='text-align:left'>Oprema vozila:<br>";

                    if (((CheckBox)gvDrawOnMap.Rows[i].Cells[8].Controls[0]).Checked)
                        InfoText = InfoText + "- Jopič<br>";
                    if (((CheckBox)gvDrawOnMap.Rows[i].Cells[9].Controls[0]).Checked)
                        InfoText = InfoText + "- Čelada<br>";
                    if (((CheckBox)gvDrawOnMap.Rows[i].Cells[10].Controls[0]).Checked)
                        InfoText = InfoText + "- Triopan<br>";
                    if (((CheckBox)gvDrawOnMap.Rows[i].Cells[11].Controls[0]).Checked)
                        InfoText = InfoText + "-  Trak<br></p>";
                    /****************   END VECHILE EQUIPMENT     **************************/



                    if (((CheckBox)gvDrawOnMap.Rows[i].Cells[6].Controls[0]).Checked)
                    {
                        mark.Icon = "./Images/alarm.gif";
                        InfoText = InfoText + "<h2>SPROŽEN ALARM</h2>";
                    }
                    else

                        mark.Icon = "./Images/" + gvDrawOnMap.Rows[i].Cells[7].Text + ".png";
                    
                    mark.Info = InfoText;

                    GoogleMap1.Markers.Add(mark);
                }
            }
        }
    }

    protected void Markers_Add_From_gvDrawOnMap()
    {
        for (int i = 0; i < gvDrawOnMap.Rows.Count; i++)
        {
            Marker mark = new Marker();
            mark.Position.Latitude = Convert.ToDouble(gvDrawOnMap.Rows[i].Cells[2].Text);
            mark.Position.Longitude = Convert.ToDouble(gvDrawOnMap.Rows[i].Cells[3].Text);

            string TitleText;
            if (Convert.ToInt16(gvDrawOnMap.Rows[i].Cells[7].Text) < 10)
                TitleText = "R0" + gvDrawOnMap.Rows[i].Cells[7].Text;
            else
                TitleText = "R" + gvDrawOnMap.Rows[i].Cells[7].Text;
            mark.Title = TitleText;

            /****************   START VECHILE EQUIPMENT     **************************/
            string InfoText;
            if (Convert.ToInt16(gvDrawOnMap.Rows[i].Cells[7].Text) < 10)
                InfoText = "<p style='text-align:left'><b>ID vozila: R0" + gvDrawOnMap.Rows[i].Cells[7].Text + "</b></p>" + "<p style='text-align:left'>Oprema vozila:<br>";
            else
                InfoText = "<p style='text-align:left'><b>ID vozila: R" + gvDrawOnMap.Rows[i].Cells[7].Text + "</b></p>" + "<p style='text-align:left'>Oprema vozila:<br>";

            if (((CheckBox)gvDrawOnMap.Rows[i].Cells[8].Controls[0]).Checked)
                InfoText = InfoText + "- Jopič<br>";
            if (((CheckBox)gvDrawOnMap.Rows[i].Cells[9].Controls[0]).Checked)
                InfoText = InfoText + "- Čelada<br>";
            if (((CheckBox)gvDrawOnMap.Rows[i].Cells[10].Controls[0]).Checked)
                InfoText = InfoText + "- Triopan<br>";
            if (((CheckBox)gvDrawOnMap.Rows[i].Cells[11].Controls[0]).Checked)
                InfoText = InfoText + "-  Trak<br></p>";
            /****************   END VECHILE EQUIPMENT     **************************/

            mark.Info = InfoText;

            if (((CheckBox)gvDrawOnMap.Rows[i].Cells[6].Controls[0]).Checked)
            {
                mark.Icon = "./Images/alarm.gif";
            }
            else

                mark.Icon = "./Images/" + gvDrawOnMap.Rows[i].Cells[7].Text + ".png";
            GoogleMap1.Markers.Add(mark);
        }
    }

    protected void Polylines_Add_From_gvDrawOnMap()
    {
        Random random = new Random();
        int value = 0;
        GooglePolyline polyline = new GooglePolyline();

        for (int i = 0; i < gvDrawOnMap.Rows.Count; i++)
        {
            if (value != Convert.ToInt16(gvDrawOnMap.Rows[i].Cells[1].Text))
            {
                value = Convert.ToInt16(gvDrawOnMap.Rows[i].Cells[1].Text);
                polyline = new GooglePolyline();
                polyline.StrokeColor = System.Drawing.Color.FromArgb(random.Next(0, 255), random.Next(0, 255), random.Next(0, 255));
                polyline.StrokeWeight = 3;
                LatLng latlong = new LatLng();
                latlong.Latitude = Convert.ToDouble(gvDrawOnMap.Rows[i].Cells[2].Text);
                latlong.Longitude = Convert.ToDouble(gvDrawOnMap.Rows[i].Cells[3].Text);
                polyline.Path.Add(latlong);
            }
            else
            {
                LatLng latlong = new LatLng();
                latlong.Latitude = Convert.ToDouble(gvDrawOnMap.Rows[i].Cells[2].Text);
                latlong.Longitude = Convert.ToDouble(gvDrawOnMap.Rows[i].Cells[3].Text);
                polyline.Path.Add(latlong);
            }

            if (i == (gvDrawOnMap.Rows.Count - 1))
                value = 0;
            else
            {
                if (Convert.ToInt16(gvDrawOnMap.Rows[i].Cells[1].Text) != Convert.ToInt16(gvDrawOnMap.Rows[i + 1].Cells[1].Text))
                    value = 0;
            }

            GoogleMap1.Polylines.Add(polyline);
        }
    }

    protected void Timer1_Tick(object sender, EventArgs e)
    {
        CheckBox_CheckChanged(sender, e);
        Label1.Text = "Osveženo: " + DateTime.Now.ToLongTimeString();       
    }
    
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (Timer1.Enabled == true)
        {
            Timer1.Enabled = false;
            Button1.ImageUrl = "./images/plus.png";
        }
        else
        {
            Timer1.Enabled = true;
            Button1.ImageUrl = "./images/minus.png";
        }
    }
    
    protected void Button2_Click(object sender, EventArgs e)
    {
        Timer1_Tick(sender, e);
    }

    private void BindPrimaryGrid()
    {
        string constr = ConfigurationManager.ConnectionStrings["TetraConnectionStringNew"].ConnectionString;
        string query = "SELECT DISTINCT deviceID, veichleID FROM View_allDevicesWithGearAndVechicleID";
        SqlConnection con = new SqlConnection(constr);
        SqlDataAdapter sda = new SqlDataAdapter(query, con);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        gvAll.DataSource = dt;
        gvAll.DataBind();
    }

    protected void OnPaging(object sender, GridViewPageEventArgs e)
    {
        GetData();
        gvAll.PageIndex = e.NewPageIndex;
        BindPrimaryGrid();
        SetData();
    }

    private void GetData()
    {
        DataTable dt;
        if (ViewState["SelectedRecords"] != null)
            dt = (DataTable)ViewState["SelectedRecords"];
        else
            dt = CreateDataTable();
        CheckBox chkAll = (CheckBox)gvAll.HeaderRow.Cells[0].FindControl("chkAll");
        for (int i = 0; i < gvAll.Rows.Count; i++)
        {
            if (chkAll.Checked)
            {
                dt = AddRow(gvAll.Rows[i], dt);
            }
            else
            {
                CheckBox chk = (CheckBox)gvAll.Rows[i].Cells[0].FindControl("chk");
                if (chk.Checked)
                {
                    dt = AddRow(gvAll.Rows[i], dt);
                }
                else
                {
                    dt = RemoveRow(gvAll.Rows[i], dt);
                }
            }
        }
        ViewState["SelectedRecords"] = dt;
    }

    private void SetData()
    {
        CheckBox chkAll = (CheckBox)gvAll.HeaderRow.Cells[0].FindControl("chkAll");
        chkAll.Checked = true;
        if (ViewState["SelectedRecords"] != null)
        {
            DataTable dt = (DataTable)ViewState["SelectedRecords"];
            for (int i = 0; i < gvAll.Rows.Count; i++)
            {
                CheckBox chk = (CheckBox)gvAll.Rows[i].Cells[0].FindControl("chk");
                if (chk != null)
                {
                    DataRow[] dr = dt.Select("deviceID = '" + gvAll.Rows[i].Cells[1].Text + "'");
                    chk.Checked = dr.Length > 0;
                    if (!chk.Checked)
                    {
                        chkAll.Checked = false;
                    }
                }
            }
        }
    }

    private DataTable CreateDataTable()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("deviceID");
        dt.Columns.Add("veichleID");
        dt.AcceptChanges();
        return dt;
    }

    private DataTable AddRow(GridViewRow gvRow, DataTable dt)
    {
        DataRow[] dr = dt.Select("deviceID = '" + gvRow.Cells[1].Text + "'");
        if (dr.Length <= 0)
        {
            dt.Rows.Add();
            dt.Rows[dt.Rows.Count - 1]["deviceID"] = gvRow.Cells[1].Text;
            dt.AcceptChanges();
        }
        return dt;
    }

    private DataTable RemoveRow(GridViewRow gvRow, DataTable dt)
    {
        DataRow[] dr = dt.Select("deviceID = '" + gvRow.Cells[1].Text + "'");
        if (dr.Length > 0)
        {
            dt.Rows.Remove(dr[0]);
            dt.AcceptChanges();
        }
        return dt;
    }

    protected void CheckBox_CheckChanged(object sender, EventArgs e)
    {
        GetData();
        SetData();
        BindSecondaryGrid();
        BindgvDrawOnMap();
        Markers_Add_Last_From_gvDrawOnMap();
    }

    private void BindSecondaryGrid()
    {
        DataTable dt = (DataTable)ViewState["SelectedRecords"];
        gvSelected.DataSource = dt;
        gvSelected.DataBind();
    }

    // Here we get the deviceIDs from secondaryGrid which is based on selection from the gvAll
    // This is used to drawselected devices on the google map
    private void BindgvDrawOnMap()
    {
        string constr = ConfigurationManager.ConnectionStrings["TetraConnectionStringNew"].ConnectionString;
        string query = "";
        string queryStart = "SELECT * FROM View_allDevicesWithGearAndVechicleID WHERE ";
        string queryAdd = "";
        if (gvSelected.Rows.Count > 0)
        {
            for (int i = 0; i < gvSelected.Rows.Count; i++)
            {
                if (i == 0)
                {
                    queryAdd = queryAdd + " deviceID = '" + gvSelected.Rows[i].Cells[0].Text + "'";
                }
                else
                {
                    queryAdd = queryAdd + " OR deviceID = '" + gvSelected.Rows[i].Cells[0].Text + "'";
                }

            }
        }
        else 
        {
            queryAdd = "deviceID = '0'";
        }
        query = queryStart + queryAdd + " ORDER BY deviceID asc, TimeStamp asc";

        SqlConnection con = new SqlConnection(constr);
        SqlDataAdapter sda = new SqlDataAdapter(query, con);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        gvDrawOnMap.DataSource = dt;
        gvDrawOnMap.DataBind();
    }

    private void BindlvTag()
    {
        int[] ID = new int[gvDrawOnMap.Rows.Count];
        if (gvDrawOnMap.Rows.Count > 0)
        {
            
            TableHeaderRow tblHeadRow = new TableHeaderRow();

            TableHeaderCell tblHeadCellID = new TableHeaderCell();
            tblHeadCellID.Text = "ID";
            tblHeadRow.Cells.Add(tblHeadCellID);

            TableHeaderCell tblHeadCellveichleID = new TableHeaderCell();
            tblHeadCellveichleID.Text = "ID vozila";
            tblHeadRow.Cells.Add(tblHeadCellveichleID);

            TableHeaderCell tblHeadCellAED = new TableHeaderCell();
            tblHeadCellAED.Text = "AED";
            tblHeadRow.Cells.Add(tblHeadCellAED);

            TableHeaderCell tblHeadCellflash = new TableHeaderCell();
            tblHeadCellflash.Text = "Ročna svetilka";
            tblHeadRow.Cells.Add(tblHeadCellflash);

            tblTag.Rows.Add(tblHeadRow);

            for (int i = 0; i < gvDrawOnMap.Rows.Count; i++)
            {
                foreach (int x in ID)
                {
                    if (x != Convert.ToInt32(gvDrawOnMap.Rows[i].Cells[1].Text))
                    {
                        ID[i] = x;
                        TableRow tr = new TableRow();

                        TableCell deviceID = new TableCell();
                        deviceID.Text = gvDrawOnMap.Rows[i].Cells[1].Text;
                        tr.Cells.Add(deviceID);

                        TableCell veichleID = new TableCell();
                        veichleID.Text = gvDrawOnMap.Rows[i].Cells[7].Text;
                        tr.Cells.Add(veichleID);

                        TableCell AED = new TableCell();
                        AED.Text = gvDrawOnMap.Rows[i].Cells[8].Text;
                        tr.Cells.Add(AED);

                        TableCell flash = new TableCell();
                        flash.Text = gvDrawOnMap.Rows[i].Cells[9].Text;
                        tr.Cells.Add(flash);

                        tblTag.Rows.Add(tr);
                    }
                }
            }
        }
        foreach (int x in ID)
        {
            ID[x] = 0;
        }
    }
}
