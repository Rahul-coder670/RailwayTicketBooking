using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    
    public partial class RailwayReservation : System.Web.UI.Page
    {
         string c = ConfigurationManager.ConnectionStrings["sqlconnection"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string q = "select * from city";
                SqlConnection cn = new SqlConnection(c);
                cn.Open();
                SqlCommand cmd = new SqlCommand(q, cn);
                DropDownList1.DataSource = cmd.ExecuteReader();
                DropDownList1.DataTextField = "ct_name";
                DropDownList1.DataValueField = "ct_id";
                DropDownList1.DataBind();
                DropDownList1.Items.Insert(0, new ListItem("---Select City---", "0"));
                cn.Close();

                string q1 = "select * from city";
                SqlConnection cn1 = new SqlConnection(c);
                cn1.Open();
                SqlCommand cmd1 = new SqlCommand(q1, cn1);
                DropDownList2.DataSource = cmd1.ExecuteReader();
                DropDownList2.DataTextField = "ct_name";
                DropDownList2.DataValueField = "ct_id";
                DropDownList2.DataBind();
                DropDownList2.Items.Insert(0, new ListItem("---Select City---", "0"));
                cn1.Close();
                DropDownList3.Items.Insert(0, new ListItem("---Select SeatType---", "0"));
            }
        }


        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToDateTime(TextBox2.Text) < DateTime.Now)
            {
                Response.Write("<script language='javascript'>alert(' please select correct date ');</script>");
                TextBox2.Text = "";
            }
        }

       
        public string CreatePassword(int length)
        {
            const string valid = "1234567890";
            StringBuilder res = new StringBuilder();
            Random rnd = new Random();
            while (0 < length--)
            {
                res.Append(valid[rnd.Next(valid.Length)]);
            }
            return res.ToString();
        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            TextBox1.ReadOnly = false;
            TextBox2.ReadOnly = false;
            DropDownList1.Enabled = true;
            DropDownList2.Enabled = true;
            TextBox1.Text = CreatePassword(7);
        }


        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {  if (DropDownList1.SelectedItem.Text == DropDownList2.SelectedItem.Text)
                Response.Write("<script language='javascript'>alert(' please select different city ');</script>");
          
            TextBox3.ReadOnly = false;
            TextBox4.ReadOnly = false;
            RadioButtonList1.Enabled = true;
            DropDownList3.Enabled = true;
            Button3.Enabled = true;
        }


        protected void TextBox4_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToDateTime(TextBox4.Text) > DateTime.Now)
            {
                Response.Write("<script language='javascript'>alert(' please select correct dob ');</script>");
                Response.Write("Please select correct dob");
                TextBox4.Text = "";
            }
        }


        private string id;
        static int count = 0;
        protected void Button3_Click(object sender, EventArgs e)
        {
            count = count + 1;
            if (TextBox1.Text != "" && TextBox2.Text != "" && TextBox3.Text != "" && TextBox4.Text != "" 
             && DropDownList1.SelectedValue != "0" && DropDownList2.SelectedValue != "0"
             && DropDownList3.SelectedValue != "0" && RadioButtonList1.SelectedValue != "0" &&
             DropDownList1.SelectedItem.Text != DropDownList2.SelectedItem.Text && count<=5)
            {

                if (count == 1)
                {
                    string q = "insert into details values('" + TextBox1.Text + "', '" + TextBox2.Text + "', '" + DropDownList1.SelectedItem.Text + "','" + DropDownList2.SelectedItem.Text + "')";
                    SqlConnection cn = new SqlConnection(c);
                    cn.Open();
                    SqlCommand cmd = new SqlCommand(q, cn);
                     cmd.ExecuteNonQuery();
                    cn.Close();
                }
                    string q1 = "select * from details where PNR ='" + TextBox1.Text + "'";
                    SqlConnection cn1 = new SqlConnection(c);
                    cn1.Open();
                    SqlCommand cmd1 = new SqlCommand(q1, cn1);
                    SqlDataReader dr = cmd1.ExecuteReader();
                    while (dr.Read())
                    {
                        id = dr["Id"].ToString();
                    }
                    cn1.Close();

                    string q2 = "insert into details1 values('" + TextBox3.Text + "', '" + TextBox4.Text + "','"+ RadioButtonList1.SelectedItem.Text+ "','" + DropDownList3.SelectedItem.Text + "','" + id+"')";
                    SqlConnection cn2 = new SqlConnection(c);
                    cn2.Open();
                    SqlCommand cmd2 = new SqlCommand(q2, cn2);
                    int k2 = cmd2.ExecuteNonQuery();
                    if (k2 > 0)
                    Response.Write("<script language='javascript'>alert('Your ticket has been booked.');</script>");
                    cn2.Close();
            }
            else
            {
                Response.Write("<script language='javascript'>alert('Please fill all fields." +
                    " Destination should be different from boarding station." +
                    " If you have booked 5 tickets on this PNR,please click on new button');</script>");
               
                TextBox2.Text= string.Empty;
                TextBox2.ReadOnly = true;
                DropDownList1.SelectedValue = "0";
                DropDownList1.Enabled = false;
                DropDownList2.SelectedValue = "0";
                DropDownList2.Enabled = false;
                TextBox3.Text = string.Empty;
                TextBox3.ReadOnly = true;
                TextBox4.Text = string.Empty;
                TextBox4.ReadOnly = true;
                RadioButtonList1.Enabled = false;
                DropDownList3.SelectedValue = "0";
                DropDownList3.Enabled = false;
                Button3.Enabled = false;
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string s = "select Details.Id,Details.PNR,Details.DateOfJourney,Details.Boarding,Details.Destination,Details1.Name,Details1.DOB,Details1.Gender,Details1.SeatType from Details inner join Details1 on Details1.Id = details.Id where PNR = '"+TextBox1.Text+"'";
            SqlConnection cn = new SqlConnection(c);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(s, cn);
            da.Fill(ds);
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }


        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            Button2_Click(sender, e);
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            Button2_Click(sender, e);
        }
        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string id = GridView1.Rows[e.RowIndex].Cells[0].Text;
          
            TextBox b = (TextBox)GridView1.Rows[e.RowIndex].Cells[2].Controls[0];
            TextBox j = (TextBox)GridView1.Rows[e.RowIndex].Cells[3].Controls[0];
            TextBox d = (TextBox)GridView1.Rows[e.RowIndex].Cells[4].Controls[0];
            string  f =          GridView1.Rows[e.RowIndex].Cells[5].Text;
            TextBox g = (TextBox)GridView1.Rows[e.RowIndex].Cells[6].Controls[0];
            TextBox h = (TextBox)GridView1.Rows[e.RowIndex].Cells[7].Controls[0];
            TextBox i = (TextBox)GridView1.Rows[e.RowIndex].Cells[8].Controls[0];

            string up = "update details1 set dob='" + g.Text + "',gender='" + h.Text + "',seattype='" + i.Text + "' where name= '" + f + "'" +
                "update details set DateOfJourney='" + b.Text + "',boarding='" + j.Text + "',destination='"+ d.Text +"' where id= '"+ id +"'";
               
            SqlConnection k = new SqlConnection(c);
            k.Open();
            SqlCommand cmd = new SqlCommand(up, k);
            cmd.ExecuteNonQuery();
            GridView1.EditIndex = -1;
            k.Close();
            Button2_Click(sender, e);
         
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string id = GridView1.Rows[e.RowIndex].Cells[0].Text;
            string f =  GridView1.Rows[e.RowIndex].Cells[5].Text;
            string up = "delete from details1  where name='" + f + "'" +
                        "delete from details  where id='" + id + "'";
            SqlConnection k = new SqlConnection(c);
            k.Open();
            SqlCommand cmd = new SqlCommand(up, k);
            cmd.ExecuteNonQuery();
            k.Close();
            Button2_Click(sender, e);
         
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}