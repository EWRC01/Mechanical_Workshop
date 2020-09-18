using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PruebaTaller
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
            customizeDesign();
        }
        private void customizeDesign()
        {
            panelMedia1.Visible = false;
            panelMedia2.Visible = false;
            panelMedia3.Visible = false;
        }
        private void hideSubMenu()
        {
            if (panelMedia1.Visible == true)
                panelMedia1.Visible = false;
            if (panelMedia2.Visible == true)
                panelMedia2.Visible = false;
            if (panelMedia3.Visible == true)
                panelMedia3.Visible = false;
        }
        private void showSubMenus(Panel Media1)
        {
            if(Media1.Visible == false)
            {
                hideSubMenu();
                Media1.Visible = true;
            }
            else
            {
                Media1.Visible = false;
            }
        }

        private void btnRecords_Click(object sender, EventArgs e)
        {
            showSubMenus(panelMedia1);
        }

        private void btnRecordClients_Click(object sender, EventArgs e)
        {
            openChildForm(new AggClients());
            //Poner codigo para el form de la tabla clientes
            hideSubMenu();
        }

        private void btnRecordsVehicles_Click(object sender, EventArgs e)
        {
            //Poner codigo para el form de la tabla clientes
            hideSubMenu();
        }

        private void btnExtraInformation_Click(object sender, EventArgs e)
        {
            //Poner codigo para el form de la tabla clientes
            hideSubMenu();
        }

        private void btnTotals_Click(object sender, EventArgs e)
        {
            //Poner codigo para el form de la tabla clientes
            hideSubMenu();
        }

        private void btnParts_Click(object sender, EventArgs e)
        {
            //Poner codigo para el form de la tabla clientes
            hideSubMenu();
        }

        private void btnLabors_Click(object sender, EventArgs e)
        {
            //Poner codigo para el form de la tabla clientes
            hideSubMenu();
        }

        private void btnAddRecords_Click(object sender, EventArgs e)
        {
            showSubMenus(panelMedia2);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //Poner codigo para el form de la tabla clientes
            hideSubMenu();
        }

        private void btnMaintance_Click(object sender, EventArgs e)
        {
            showSubMenus(panelMedia3);
        }


        private void btnHistories_Click(object sender, EventArgs e)
        {
            //Poner codigo para el form de la tabla clientes
            hideSubMenu();
        }
        private Form activateForm = null;
        private void openChildForm(Form childForm)
        {
            if (activateForm != null)
                activateForm.Close();
            activateForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelChildForm.Controls.Add(childForm);
            panelChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();



        }
    }
}
