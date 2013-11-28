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
using System.Windows.Shapes;
using System.Data.SqlClient;

namespace WpfApplication11
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection cnx = new SqlConnection("server=.; database=AGENDA; Integrated Security=true");
            SqlCommand cmd = new SqlCommand("NUEVO_PERSONA", cnx);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add("@NOMBRE", System.Data.SqlDbType.Text, 50);
            cmd.Parameters.Add("@APELLIDO", System.Data.SqlDbType.Text, 50);
            cmd.Parameters.Add("@CORREO_ELECTRONICO", System.Data.SqlDbType.Text, 100);
            cmd.Parameters.Add("@FECHA_DE_NACIMIENTO", System.Data.SqlDbType.Date);
            cmd.Parameters.Add("@DNI", System.Data.SqlDbType.Text, 8);
                //@NOMBRE, @APELLIDO, @CORREO_ELECTRONICO, @FECHA_DE_NACIMIENTO, @DNI
            cmd.Parameters["@NOMBRE"].Value = textBox5.Text;
            cmd.Parameters["@APELLIDO"].Value = textBox4.Text;
            cmd.Parameters["@CORREO_ELECTRONICO"].Value = textBox3.Text;
            cmd.Parameters["@FECHA_DE_NACIMIENTO"].Value = Convert.ToDateTime(textBox2.Text);
            cmd.Parameters["@DNI"].Value = textBox1.Text;
            cnx.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show("INGRESO CORRECTO");
            cnx.Close();
            ventana1.Close();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            ventana1.Close();
        }
    }
}
