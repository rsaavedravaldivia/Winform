using Main.Code;
using Main.Libraries;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Main
{
    public partial class ClientForm : Form
    {

        SQLiteHandler sqliteHandler;
        DataTable dataTable;
        public ClientForm()
        {

            this.DoubleBuffered = true;

            InitializeComponent();
            StablishSQLiteConnection();
            DesignDatagridview();


        }


        private void DesignDatagridview()
        {

            // style

            clientDatagrid.BorderStyle = BorderStyle.None;
            clientDatagrid.CellBorderStyle = DataGridViewCellBorderStyle.SingleVertical;
            clientDatagrid.EnableHeadersVisualStyles = false;

            clientDatagrid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            clientDatagrid.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            clientDatagrid.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;





            // hiding row header

            clientDatagrid.RowHeadersVisible = false;


            // alternating row color
            clientDatagrid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(200, 239, 249);


            // header
            clientDatagrid.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 70);
            clientDatagrid.ColumnHeadersDefaultCellStyle.ForeColor = Color.WhiteSmoke;

            // selection color
            clientDatagrid.DefaultCellStyle.SelectionBackColor = Color.DarkBlue;



        }






        private void StablishSQLiteConnection()
        {
            // creating database handler object
            sqliteHandler = new SQLiteHandler();
            // getting the data from sql and putting it into a datatable
            dataTable = sqliteHandler.GetDatatableFromSQLite("clients");
            // adding the datatable to the datagridview
            clientDatagrid.DataSource = dataTable;

        }



        private void btnAddClient_Click(object sender, System.EventArgs e)
        {
            if (tbFirstName.Text == "" || tbLastName.Text == "" ||
                tbPhone.Text == "" || tbEmail.Text == "" || tbAddress.Text == "")
            {
                MessageBox.Show("Field should contain text.");
                return;
            }
            else
            {
                Client client = new Client(tbFirstName.Text, tbLastName.Text, tbPhone.Text,
                tbEmail.Text, tbAddress.Text);
                ClientTableHandler.InsertClientToClients(sqliteHandler, client);
                dataTable = sqliteHandler.GetDatatableFromSQLite("clients");
                clientDatagrid.DataSource = dataTable;
            }

        }
        private void buttonUpdateClient_Click(object sender, EventArgs e)
        {
            if (tbFirstName.Text == "" || tbLastName.Text == "" ||
                tbPhone.Text == "" || tbEmail.Text == "" || tbAddress.Text == "")
            {
                MessageBox.Show("Field should contain text.");
                return;
            }
            else
            {
                if (selectedRow != null)
                {
                    Client newClient = new Client(tbFirstName.Text, tbLastName.Text, tbPhone.Text,
                    tbEmail.Text, tbAddress.Text);
                    newClient.id = int.Parse(selectedRow.Cells[0].Value.ToString());
                    ClientTableHandler.UpdateClientFromClients(sqliteHandler, newClient);
                    dataTable = sqliteHandler.GetDatatableFromSQLite("clients");
                    clientDatagrid.DataSource = dataTable;
                }
            }
        }
        private void btnDeleteClient_Click(object sender, EventArgs e)
        {

            try
            {
                if (selectedRow != null)
                {
                    ClientTableHandler.DeleteClientFromClients(sqliteHandler, int.Parse(selectedRow.Cells[0].Value.ToString()));
                    dataTable = sqliteHandler.GetDatatableFromSQLite("clients"); ;
                    clientDatagrid.DataSource = dataTable;
                    clientDatagrid.CurrentRow.Selected = false;
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Please select a client first");
                return;
            }


        }

        private DataGridViewRow selectedRow;
        private void clientDatagrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var current = clientDatagrid.CurrentRow;
            if (current != null)
            {
                selectedRow = clientDatagrid.CurrentRow;

                clientDatagrid.CurrentRow.Selected = true;

                tbFirstName.Text = selectedRow.Cells[1].Value.ToString();
                tbLastName.Text = selectedRow.Cells[2].Value.ToString();
                tbPhone.Text = selectedRow.Cells[3].Value.ToString();
                tbEmail.Text = selectedRow.Cells[4].Value.ToString();
                tbAddress.Text = selectedRow.Cells[5].Value.ToString();
            }
        }

        private void ClientForm_Load(object sender, EventArgs e)
        {
            clientDatagrid.RowHeadersVisible = false;
            clientDatagrid.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            clientDatagrid.Rows[0].Selected = true;





        }
    }
}
