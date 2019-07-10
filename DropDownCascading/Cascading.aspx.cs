using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


public partial class Cascading : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //This program use SQL Server and calling Stored Proc and populating data in Drop down list 
        if (!IsPostBack)
        {
            ddlcontinent.DataSource= GetData("spGetContinents", null);
            ddlcontinent.DataTextField = "ContinentName";
            ddlcontinent.DataValueField = "ContinentId";
            ddlcontinent.DataBind();
            ListItem lstContinent = new ListItem();
            lstContinent.Value = "-1";
            lstContinent.Text = "Select Continent";
            ddlcontinent.Items.Insert(0, lstContinent);

            ListItem lstCountry = new ListItem("Select Country", "-1");
            ddlcountry.Items.Insert(0, lstCountry);

            ListItem lstcity = new ListItem("Select City", "-1");
            ddlcity.Items.Insert(0, lstcity);

            ddlcountry.Enabled = false;
            ddlcity.Enabled = false;
        }

    }
    private DataSet GetData(string SP, SqlParameter parameter)
    {
        string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        SqlConnection con = new SqlConnection(CS);
        SqlDataAdapter da = new SqlDataAdapter(SP, con);
        da.SelectCommand.CommandType = CommandType.StoredProcedure;
        DataSet DS = new DataSet();
        if(parameter!=null)
        {
            da.SelectCommand.Parameters.Add(parameter);
        }
        da.Fill(DS);
        return DS;
    }


    protected void ddlcontinent_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlcontinent.SelectedIndex == 0)
        {
            ddlcountry.Enabled = false;
            ddlcity.Enabled = false;
        }
        else
        {
            ddlcountry.Enabled = true;
            SqlParameter parameter = new SqlParameter("@ContinentId", ddlcontinent.SelectedValue);
            ddlcountry.DataSource = GetData("spGetCountriesByContinentId", parameter );
            ddlcountry.DataTextField = "CountryName";
            ddlcountry.DataValueField = "CountryId";
            ddlcountry.DataBind();
            ListItem lstCountry = new ListItem("Select Country", "-1");
            ddlcountry.Items.Insert(0, lstCountry);
            ListItem lstcity = new ListItem("Select City", "-1");
            ddlcity.Items.Insert(0, lstcity);
            ddlcity.SelectedValue = "-1";
        }

    }

    protected void ddlcountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(ddlcountry.SelectedIndex==00)
        {
     
            ddlcity.Enabled = false;
        }
        else
        {
            ddlcity.Enabled = true;
            SqlParameter parameter = new SqlParameter("@CountryId", ddlcountry.SelectedValue);
            ddlcity.DataSource = GetData("spGetCitiesByCountryId", parameter);
            ddlcity.DataTextField = "CityName";
            ddlcity.DataValueField = "CityId";
            ddlcity.DataBind();
            ListItem lstcity = new ListItem("Select City", "-1");
            ddlcity.Items.Insert(0, lstcity);
        }
    }
}