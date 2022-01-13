using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projet_Gestion
{
    public partial class AjouterEmp : Form
    {
        public AjouterEmp()
        {
            InitializeComponent();
        }

        private void guna2TextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void valider_add_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection("Data Source=DESKTOP-HUNMA03\\SQLSERVER;Initial Catalog=Gestion;Integrated Security=True");
            con.Open();
            if (con.State == ConnectionState.Open)
            {
                //MessageBox.Show("connection");
                //string s = "select dbo.AjouterEmployer(@cin ,@nomEmployer ,@prixTravail ,@habbite ,	@dateEntrer ,@date_arret ,@categorie)";
                SqlCommand cmd = new SqlCommand("AjouterEmployer", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@cin", txtcin.Text.Trim());
                cmd.Parameters.AddWithValue("@nomEmployer", txtnom.Text.Trim());
                cmd.Parameters.AddWithValue("@prixTravail", txtprix.Text.Trim());
                cmd.Parameters.AddWithValue("@habbite", txthabbit.Text.Trim());
                cmd.Parameters.AddWithValue("@dateEntrer", txtdate.Text.Trim());
                cmd.Parameters.AddWithValue("@date_arret", "");
                cmd.Parameters.AddWithValue("@categorie", txtcategorie.Text.Trim());

                //cmd.ExecuteScalar();
                SqlDataReader QueryReader = cmd.ExecuteReader();
                con.Close();

            }
            else
            {
                MessageBox.Show("not connection !!");
            }

            this.Close();

        }

        private void AjouterEmp_Load(object sender, EventArgs e)
        {
            txtdate.Text = DateTime.Now.ToString();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
