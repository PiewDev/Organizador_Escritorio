using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Permissions;
using Logica;
using Microsoft.WindowsAPICodePack.Dialogs;
using System.IO;


namespace OrganizadorForms
{

    public partial class Form1 : Form, IProgramas, IPrincipal 
    {
        public Principal Prin = new Principal();
        private BindingSource b1;
        private BindingSource b2;

        public Form1()
        {
            InitializeComponent();
        }
        
              
      

        private void button1_Click_1(object sender, EventArgs e)
        {                
            if (dataGridView1.CurrentCell != null)
            {
                Prin.AceptarPrograma(dataGridView1.CurrentCell.Value.ToString());

                ActualizarGrillas();

            }
            
           
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            AgregarProgramas(CargarProgramasDesk());

            this.b1 = new BindingSource(Prin.Programs, "ListaProgramas");
            dataGridView1.AutoGenerateColumns = true;           
            dataGridView1.DataSource = this.b1;

            this.b2 = new BindingSource(Prin.Programs, "ProgramasAgregados");
            dataGridView2.AutoGenerateColumns = true;
            dataGridView2.DataSource = this.b2;

            this.textBox1.Text = Prin.GetDirectorySalida();
        }

        public void AgregarProgramas(List<string> programs)
        {
            Prin.AgregarProgramas(programs);
            
        }

       

        public List<Programm> TraerLista()
        {
            return Prin.TraerLista();
        }

        private void listaProgramasBindingSource3_CurrentChanged(object sender, EventArgs e)
        {

        }

    

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog folderBrowser = new OpenFileDialog();
            // Set validate names and check file exists to false otherwise windows will
            // not let you select "Folder Selection."
            folderBrowser.ValidateNames = false;
            folderBrowser.CheckFileExists = false;
            folderBrowser.CheckPathExists = true;
            // Always default to Folder Selection.
            folderBrowser.FileName = "Select directory";
            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                SetDirectorySalida(Path.GetDirectoryName(folderBrowser.FileName));
                this.textBox1.Text = GetDirectorySalida();
            }
        }

        public List<string> CargarProgramasDesk()
        {
            return Prin.CargarProgramasDesk();
        }

        public void SetDirectorySalida(string salida)
        {
            Prin.SetDirectorySalida(salida);
        }

        public string GetDirectorySalida()
        {
           return  Prin.GetDirectorySalida();
        }

        public void AceptarPrograma(string program)
        {
            Prin.AceptarPrograma(program);
        }

        public void DenegarPrograma(string program)
        {
            Prin.DenegarPrograma(program);
        }

        public List<Programm> TraerAceptados()
        {
            return Prin.TraerAceptados();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (dataGridView2.CurrentCell != null)
            {
                DenegarPrograma(dataGridView2.CurrentCell.Value.ToString());
                ActualizarGrillas();
            }
        }

        private void ActualizarGrillas()
        {
            this.dataGridView2.Invalidate(true);
            this.dataGridView1.Invalidate(true);

            b1.ResetBindings(false);
            b2.ResetBindings(false);
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
