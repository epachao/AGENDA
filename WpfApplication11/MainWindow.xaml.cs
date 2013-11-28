using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;

namespace WpfApplication11
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void button5_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection cnx = new SqlConnection(@"server=.;database=AGENDA;Integrated Security =True");
            //SqlCommand cmd = new SqlCommand("REPORTE", cnx);
            SqlCommand cmd = new SqlCommand("REPORTE", cnx);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataAdapter DA = new SqlDataAdapter(cmd);
            //DataSet DS = new DataSet();
            DataTable DT = new DataTable();
            cnx.Open();
            //cmd.ExecuteNonQuery();
            DA.Fill(DT);
            dataGrid1.ItemsSource = DT.DefaultView;
            cnx.Close();
            //MessageBox.Show("hey");
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void listBox1_Loaded(object sender, RoutedEventArgs e)
        {
            mostrar_usuarios();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            Window2 ventana = new Window2();
            ventana.Owner = this;
            ventana.ShowDialog();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            mostrar_usuarios();
        }
        void mostrar_usuarios()
        {
            System.Data.SqlClient.SqlConnection cnx = new System.Data.SqlClient.SqlConnection(@"server=.;database=AGENDA;Integrated Security =True");
            cnx.Open();
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("select nombre from dbo.PERSONAS", cnx);
            System.Data.SqlClient.SqlDataReader DR = cmd.ExecuteReader();
            //DR = cmd.ExecuteReader();
            listBox1.Items.Clear();
            while (DR.Read())
            {
                listBox1.Items.Add(DR[0].ToString());
            }
            DR.Close();
            cnx.Close();
        }

        private void listBox1_GotMouseCapture(object sender, MouseEventArgs e)
        {
            SqlConnection cnx = new SqlConnection(@"server=.;database=AGENDA;Integrated Security =True");
            //SqlCommand cmd = new SqlCommand("REPORTE", cnx);
            SqlCommand cmd = new SqlCommand("informacion", cnx);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add("@NOMBRE", System.Data.SqlDbType.Text, 50);
            cmd.Parameters["@NOMBRE"].Value = Convert.ToString(listBox1.SelectedItem);
            //MessageBox.Show(listBox1.AreAnyTouchesCaptured);
            SqlDataAdapter DA = new SqlDataAdapter(cmd);
            //DataSet DS = new DataSet();
            DataTable DT = new DataTable();
            cnx.Open();
            //cmd.ExecuteNonQuery();
            DA.Fill(DT);
            dataGrid1.ItemsSource = DT.DefaultView;
            cnx.Close();
            //MessageBox.Show("hey");
        }
    }
}
