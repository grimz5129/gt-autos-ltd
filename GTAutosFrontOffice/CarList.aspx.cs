using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GTAutosClasses;

public partial class CarList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack == false)
        {
            DisplayAddress();
        }
    }

    void DisplayAddress()
    {
        GTAutosClasses.ClsCarCollection AllCars = new GTAutosClasses.ClsCarCollection();
        lstCarList.DataSource = AllCars.CarList;
        lstCarList.DataValueField = "CarID";
        lstCarList.DataTextField = "Make";
        lstCarList.DataBind();
    }


    //event handeler for button
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        //store -1 into the session object to indicate that this is a new reocord
        Session["CarID"] = -1;
        //redirect to the data entry page 
        Response.Redirect("ACar.aspx");
    }

    protected void BtnDelete_Click(object sender, EventArgs e)
    {
        //var to store the priamry key value of the record to be deleated
        int CarID;
        //if the record has been selected from the list
        if (lstCarList.SelectedIndex != -1)
        {
            //get the primary key value of the record to delete
            CarID = Convert.ToInt32(lstCarList.SelectedValue);
            //store the data in the session object 
            Session["CarID"] = CarID;
            //redirect to the delete page 
            Response.Redirect("DeleteCar.aspx");
        }
        else //if no record has been selected
        {
            //display an error
            lblError.Text = "Please select a record to delete from the list";
        }
    }

    protected void BtnEdit_Click(object sender, EventArgs e)
    {
        //var to store the priamry key value of the record to be deleated
        int CarID;
        //if the record has been selected form the list
        if (lstCarList.SelectedIndex != -1)
        {
            //get the primary key value of the record to delete
            CarID = Convert.ToInt32(lstCarList.SelectedValue);
            //store the data in the session object 
            Session["CarID"] = CarID;
            //redirect to the delete page 
            Response.Redirect("ACar.aspx");
        }
        else //if no record has been selected
        {
            //display an error
            lblError.Text = "Please select a record to edit from the list";
        }
    }

    protected void btnApply_Click(object sender, EventArgs e)
    {
        //create an instacne of the car collection
        ClsCarCollection AllCars = new ClsCarCollection();
        AllCars.ReportByMake(txtFilter.Text);
        lstCarList.DataSource = AllCars.CarList;
        //set the name of th epriamry key 
        lstCarList.DataValueField = "CarID";
        //set the name of the field to display 
        lstCarList.DataTextField = "Make";
        //bind the data to the list 
        lstCarList.DataBind();
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        //create an instanc eof the car collection
        ClsCarCollection AllCars = new ClsCarCollection();
        AllCars.ReportByMake("");
        //clear an y exsitin gfilter to tidy up the interface 
        txtFilter.Text = "";
        lstCarList.DataSource = AllCars.CarList;
        //set the name of th epriamry key 
        lstCarList.DataValueField = "CarID";
        //set the name of the field to display 
        lstCarList.DataTextField = "Make";
        //bind the data to the list 
        lstCarList.DataBind();
    }
}