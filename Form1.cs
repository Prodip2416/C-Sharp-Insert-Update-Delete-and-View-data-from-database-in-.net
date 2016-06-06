using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace CRUD_APPS
{
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection("Data Source=PRODIP-PC;Initial Catalog=CrudDb;Integrated Security=True;Pooling=False");
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da;
        DataTable dt;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cmd.Connection = con;
        }

        #region Insert Operation
        

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (txtName.Text != "" & txtDept.Text != "" & txtCGPA.Text != "")
            {
                con.Open();
                cmd = new SqlCommand("INSERT INTO info(Name,Dept,CGPA) VALUES('" + txtName.Text + "','" + txtDept.Text + "','" + txtCGPA.Text + "')", con);

                cmd.ExecuteNonQuery();

                con.Close();
                lblMessage.ForeColor = Color.Green;
                lblMessage.Text = "Data Inserted.";
            }
            else
            {
                lblMessage.ForeColor = Color.Red;
                lblMessage.Text = "Please Fill Tha Name,Dept and CGPA colume.";
            }

        }
        #endregion 

        #region Update Operation

        private void btnUpdate_Click(object sender, EventArgs e)
        {
           if(txtId.Text!="")
           {
            con.Open();
            cmd = new SqlCommand("UPDATE info SET Name=@a1,Dept=@a2,CGPA=@a3 WHERE Id=@a4", con);

            cmd.Parameters.Add("a1", txtName.Text);
            cmd.Parameters.Add("a2", txtDept.Text);
            cmd.Parameters.Add("a3", txtCGPA.Text);
            cmd.Parameters.Add("a4", txtId.Text);

            cmd.ExecuteNonQuery();
            con.Close();

            lblMessage.ForeColor = Color.Green;
            lblMessage.Text = "Update Sucessfully";
           }
            else{
               lblMessage.ForeColor=Color.Red;
               lblMessage.Text = "Please fill Id colume.";
           }

        }


        #endregion

        #region Delete Operation
    
        
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtId.Text != "")
            {
                con.Open();
                cmd = new SqlCommand("delete from info where Id='" + this.txtId.Text + "'", con);
                cmd.ExecuteNonQuery();
                con.Close();
                lblMessage.ForeColor = Color.Green;
                lblMessage.Text = "Data Can be Deleted From DataBase.";
            }
            else
            {
                lblMessage.ForeColor = Color.Red;
                lblMessage.Text = "Please Fill the Id Colume whose are deleted from database.";
            }
        }



        #endregion

        #region View DataBase
        

        private void btnView_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("select * from info", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        #endregion

    }
}
