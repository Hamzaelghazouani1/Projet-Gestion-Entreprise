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
    public partial class Modification : Form
    {
        public Modification()
        {
            InitializeComponent();
        }

        private void valider_add_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-HUNMA03\\SQLSERVER;Initial Catalog = Gestion ;Integrated Security=True");
            con.Open();

            //MessageBox.Show("connection");
            //string s = "select dbo.AjouterEmployer(@cin ,@nomEmployer ,@prixTravail ,@habbite ,	@dateEntrer ,@date_arret ,@categorie)";
            SqlCommand command = new SqlCommand("UPDATE employer SET Cin =@cin ,nom_prenom =@nom ,prix_travail =@prix ,habbite = @habit , date_entrer =@date , categorie =@cat WHERE cin = @cin", con);
            //command.CommandText = "UPDATE employer SET Cin =@cin ,nom_prenom =@nom ,prix_travail =@prix ,habbite = @habit , date_entrer =@date , categorie =@cat WHERE cin = @cin";
            command.Parameters.AddWithValue("@cin", txtcin.Text.Trim());
            command.Parameters.AddWithValue("@nom", txtnom.Text.Trim());
            command.Parameters.AddWithValue("@prix", txtprix.Text.Trim());
            command.Parameters.AddWithValue("@habit", txthabbit.Text.Trim());
            command.Parameters.AddWithValue("@date", txtdate.Text.Trim());
            command.Parameters.AddWithValue("@cat", txtcategorie.Text.Trim());
            SqlDataReader QueryReader = command.ExecuteReader();
            con.Close();
            this.Close();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
