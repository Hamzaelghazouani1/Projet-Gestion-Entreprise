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
    public partial class Form1 : Form
    {

        public string cin;
        public string nom;
        public string prix;
        public string habbit;
        public string date;
        public string categorie;

        public Form1()
        {
            InitializeComponent();
        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            AjouterEmp add = new AjouterEmp();
            add.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'gestionDataSet.resource_financiare' table. You can move, or remove it, as needed.
            this.resource_financiareTableAdapter.Fill(this.gestionDataSet.resource_financiare);
            // TODO: This line of code loads data into the 'gestionDataSet.rousourceMaterial' table. You can move, or remove it, as needed.
            this.rousourceMaterialTableAdapter.Fill(this.gestionDataSet.rousourceMaterial);
            // TODO: This line of code loads data into the 'gestionDataSet.Stock' table. You can move, or remove it, as needed.
            this.stockTableAdapter.Fill(this.gestionDataSet.Stock);
            // TODO: This line of code loads data into the 'gestionDataSet.avance' table. You can move, or remove it, as needed.
            this.avanceTableAdapter.Fill(this.gestionDataSet.avance);
            // TODO: This line of code loads data into the 'gestionDataSet.travail' table. You can move, or remove it, as needed.
            this.travailTableAdapter.Fill(this.gestionDataSet.travail);
            // TODO: This line of code loads data into the 'gestionDataSet.employer' table. You can move, or remove it, as needed.
            this.employerTableAdapter.Fill(this.gestionDataSet.employer);
            // TODO: This line of code loads data into the 'gestionDataSet.emplacement' table. You can move, or remove it, as needed.
            this.emplacementTableAdapter.Fill(this.gestionDataSet.emplacement);
            DateTextBox.Text = DateTime.Now.ToString();
            guna2TextBoxDate.Text = DateTime.Now.ToString();
            txtDateM.Text = DateTime.Now.ToString();
            txtdater.Text = DateTime.Now.ToString();    

        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            Modification Modif = new Modification();
            Modif.txtcin.Text = cin;
            Modif.txtnom.Text = nom;
            Modif.txtprix.Text = prix;
            Modif.txthabbit.Text = habbit;
            Modif.txtdate.Text = date;
            Modif.txtcategorie.Text = categorie;
            Modif.Show();
            guna2GradientButton1.Enabled = false;
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            cin = guna2DataGridView1.CurrentRow.Cells[0].Value.ToString();
            nom = guna2DataGridView1.CurrentRow.Cells[1].Value.ToString();
            prix = guna2DataGridView1.CurrentRow.Cells[2].Value.ToString();
            habbit = guna2DataGridView1.CurrentRow.Cells[4].Value.ToString();
            date = guna2DataGridView1.CurrentRow.Cells[5].Value.ToString();
            categorie = guna2DataGridView1.CurrentRow.Cells[6].Value.ToString();
            guna2DataGridView1.Enabled = true;
            guna2GradientButton1.Enabled = true;
        }

        private void valider_add_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection("Data Source=DESKTOP-HUNMA03\\SQLSERVER;Initial Catalog=Gestion;Integrated Security=True");
            con.Open();
            if (con.State == ConnectionState.Open)
            {
                //MessageBox.Show("connection");
                //string s = "select dbo.AjouterEmployer(@cin ,@nomEmployer ,@prixTravail ,@habbite ,	@dateEntrer ,@date_arret ,@categorie)";
                SqlCommand cmd = new SqlCommand("AjouterEmplacement", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_emplacement", emptxtid.Text.Trim());
                cmd.Parameters.AddWithValue("@nom_client", emptxtnom.Text.Trim());
                cmd.Parameters.AddWithValue("@ville", emptxtville.Text.Trim());
                cmd.Parameters.AddWithValue("@prixTravail", emptxtprix.Text.Trim());

                //cmd.ExecuteScalar();
                SqlDataReader QueryReader = cmd.ExecuteReader();
                con.Close();

            }
            else
            {
                MessageBox.Show("not connection !!");
            }
            this.emplacementTableAdapter.Fill(this.gestionDataSet.emplacement);
            emptxtid.Text = "";
            emptxtnom.Text = "";
            emptxtprix.Text = "";
            emptxtville.Text = "";
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-HUNMA03\\SQLSERVER;Initial Catalog=Gestion;Integrated Security=True");
            con.Open();
            if (con.State == ConnectionState.Open)
            {
                SqlCommand cmd = new SqlCommand("AjouterTravail", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@cin", CINTextBox.Text.Trim());
                cmd.Parameters.AddWithValue("@id_emplacement", empTextBox.Text.Trim());
                cmd.Parameters.AddWithValue("@date", DateTextBox.Text.Trim());
                SqlDataReader QueryReader = cmd.ExecuteReader();
                con.Close();

            }
            else
            {
                MessageBox.Show("not connection !!");
            }

            this.employerTableAdapter.Fill(this.gestionDataSet.employer);
            CINTextBox.Text = "";
            empTextBox.Text = "";
            DateTextBox.Text = "";
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-HUNMA03\\SQLSERVER;Initial Catalog=Gestion;Integrated Security=True");
            con.Open();
            if (con.State == ConnectionState.Open)
            {
                SqlCommand cmd = new SqlCommand("AjouterAvance", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@cin", guna2TextBoxCIN.Text.Trim());
                cmd.Parameters.AddWithValue("@id_avance", guna2TextBoxID.Text.Trim());
                cmd.Parameters.AddWithValue("@prix_avance", guna2TextBoxPrix.Text.Trim());
                cmd.Parameters.AddWithValue("@date_avance", guna2TextBoxDate.Text.Trim());
                SqlDataReader QueryReader = cmd.ExecuteReader();
                con.Close();

            }
            else
            {
                MessageBox.Show("not connection !!");
            }

            this.employerTableAdapter.Fill(this.gestionDataSet.employer);
            this.avanceTableAdapter.Fill(this.gestionDataSet.avance);
            guna2TextBoxCIN.Text = "";
            guna2TextBoxID.Text = "";
            guna2TextBoxPrix.Text = "";
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-HUNMA03\\SQLSERVER;Initial Catalog=Gestion;Integrated Security=True");
            con.Open();
            if (con.State == ConnectionState.Open)
            {
                //MessageBox.Show("connection");
                //string s = "select dbo.AjouterEmployer(@cin ,@nomEmployer ,@prixTravail ,@habbite ,	@dateEntrer ,@date_arret ,@categorie)";
                SqlCommand cmd = new SqlCommand("AjouterStock", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_produit", txtidp.Text.Trim());
                cmd.Parameters.AddWithValue("@nom_produit", txtnomp.Text.Trim());
                cmd.Parameters.AddWithValue("@qteStock", txtqtep.Text.Trim());
                //cmd.ExecuteScalar();
                SqlDataReader QueryReader = cmd.ExecuteReader();
                con.Close();

            }
            else
            {
                MessageBox.Show("not connection !!");
            }

            this.stockTableAdapter.Fill(this.gestionDataSet.Stock);

            txtidp.Text = "";
            txtnomp.Text = "";
            txtqtep.Text = "";
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-HUNMA03\\SQLSERVER;Initial Catalog=Gestion;Integrated Security=True");
            con.Open();
            if (con.State == ConnectionState.Open)
            {
                //MessageBox.Show("connection");
                //string s = "select dbo.AjouterEmployer(@cin ,@nomEmployer ,@prixTravail ,@habbite ,	@dateEntrer ,@date_arret ,@categorie)";
                SqlCommand cmd = new SqlCommand("AjouterMaterial", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_emplacement", txtidempM.Text.Trim());
                cmd.Parameters.AddWithValue("@id_produit", txtidproM.Text.Trim());
                cmd.Parameters.AddWithValue("@qte_produit", txtqteM.Text.Trim());
                cmd.Parameters.AddWithValue("@date", txtDateM.Text.Trim());
                //cmd.ExecuteScalar();
                SqlDataReader QueryReader = cmd.ExecuteReader();
                con.Close();

            }
            else
            {
                MessageBox.Show("not connection !!");
            }

            this.rousourceMaterialTableAdapter.Fill(this.gestionDataSet.rousourceMaterial);

            txtidempM.Text = "";
            txtidproM.Text = "";
            txtqteM.Text = "";
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-HUNMA03\\SQLSERVER;Initial Catalog=Gestion;Integrated Security=True");
            con.Open();
            if (con.State == ConnectionState.Open)
            {
                //MessageBox.Show("connection");
                //string s = "select dbo.AjouterEmployer(@cin ,@nomEmployer ,@prixTravail ,@habbite ,	@dateEntrer ,@date_arret ,@categorie)";
                SqlCommand cmd = new SqlCommand("AjouterFinance", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_resourceF", txtidr.Text.Trim());
                cmd.Parameters.AddWithValue("@id_emplacement", txtempr.Text.Trim());
                cmd.Parameters.AddWithValue("@avance", txtavr.Text.Trim());
                cmd.Parameters.AddWithValue("@date", txtdater.Text.Trim());
                //cmd.ExecuteScalar();
                SqlDataReader QueryReader = cmd.ExecuteReader();
                con.Close();

            }
            else
            {
                MessageBox.Show("not connection !!");
            }

            this.resource_financiareTableAdapter.Fill(this.gestionDataSet.resource_financiare);

            txtavr.Text = "";
            txtidr.Text = "";
            txtempr.Text = "";
        }
    }
}
