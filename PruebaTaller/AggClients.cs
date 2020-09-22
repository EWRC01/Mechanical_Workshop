using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace PruebaTaller
{
    public partial class AggClients : Form
    {
        Crud paso = new Crud();
        public AggClients()
        {
            InitializeComponent();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            LimpirarBotones();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string save= "INSERT INTO Client (idClient, name_client, date_client, phone_client, addres_client, city_client, state_client) VALUES ('"+txtidClient.Text+"', '"+txtName.Text+"', '"+txtDate.Text+"', '"+txtPhone.Text+"', '"+txtAddress.Text+"', '"+txtCity.Text+"', '"+txtState.Text+"')";  
            if(paso.Operacion(save))
            {
                MessageBox.Show("Registro almacenado correctamente");
                LimpirarBotones();
            }
            else
            {
                MessageBox.Show("Ocurrio un error al almacenar el registro");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

             string update= "UPDATE  Client set idClient= '"+ txtidClient.Text + "', name_client= '"+txtName.Text+"', date_client='"+txtDate.Text+"', phone_client='"+txtPhone.Text+"', addres_client='"+txtAddress.Text+"', city_client='"+txtCity.Text+"', state_client='"+txtState.Text+"' where idClient='"+txtidClient.Text+"'";
            if (paso.Operacion(update))
            {
                MessageBox.Show("Registro actualizado correctamente");
                LimpirarBotones();
            }
            else
            {
                MessageBox.Show("Error al actualizar el registro");
            }
        }

        private void AggClients_Load(object sender, EventArgs e)
        {

            numerodeRegistro();
        }

        public void numerodeRegistro()
        {
            SqlCommand cmd;

            string query = "SELECT count(*) FROM Client";

            paso.conexion.Open();
            cmd = new SqlCommand(query, paso.conexion);


            Int32 contador = Convert.ToInt32(cmd.ExecuteScalar());
            cmd.Dispose();
            paso.conexion.Close();

            contador = contador + 1;
            lblN.Text = contador.ToString();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string delete= "DELETE FROM Client Where idClient= '"+txtidClient.Text+"'";
          
            if(MessageBox.Show("Esta seguro de que quiere borrar el registro", "Cancelar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)== DialogResult.Yes)
            {
                if (paso.Operacion(delete))
                {
                    MessageBox.Show("Registro eliminado con exito");
                    LimpirarBotones();

                }
                else
                    MessageBox.Show("No se pudo eliminar el registro");

            }
            else
            {
                MessageBox.Show("Redireccionando al registro clientes");
            }

        }
        public void LimpirarBotones()
        {
            txtName.Text = "";
            txtAddress.Text = "";
            txtCity.Text = "";
            txtDate.Text = "";
            txtPhone.Text = "";
            txtState.Text = "";
            txtidClient.Text = "";

            txtName.Focus();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string search = "SELECT * FROM Client WHERE idClient='" + txtidClient.Text + "'";
            paso.ConsultarTextto(search);
            if(paso.dr.Read())
            {
                txtidClient.Text = Convert.ToString(paso.dr[0]);
                txtName.Text = Convert.ToString(paso.dr[1]);
                txtDate.Text = Convert.ToString(paso.dr[2]);
                txtPhone.Text = Convert.ToString(paso.dr[3]);
                txtAddress.Text = Convert.ToString(paso.dr[4]);
                txtCity.Text = Convert.ToString(paso.dr[5]);
                txtState.Text = Convert.ToString(paso.dr[6]);

                paso.dr.Close();
                paso.cerrarConn();

            }
            else
            {
                MessageBox.Show("El Cliente no existe");
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
