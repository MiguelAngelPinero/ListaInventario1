using System;

using System.Windows.Forms;

namespace Evaluacion4ITS
{
    public partial class Form1 : Form
    {
        Datos dat = new Datos();
        public DatosLista datos { get; set; } = new DatosLista();

        public Form1()
        {
            InitializeComponent();

           

            dgv.DataSource = datos.DT;

        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            try
            {
   
                dat.Nombre = txtNombre.Text;
                dat.Precio = float.Parse(txtPrecio.Text);
                dat.Cantidad = int.Parse(txtCantidad.Text);

                if (!datos.UpdateDatos(dat))
                {
                    txtNombre.Focus();
                    txtNombre.SelectAll();
                    lblError.Text = "Nombre no permitido";
                }

                dat = new Datos();          
            }
            catch (Exception error)
            {
               lblError.Text = error.Message;
            }

            txtCantidad.Text = "";
            txtNombre.Text = "";
            txtPrecio.Text = "";

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
         
            datos.Borrar(dat);
            dat = new Datos();
        }

      


        private void btnLimpiar_Click_1(object sender, EventArgs e)
        {
            
            txtNombre.Clear();
            txtPrecio.Clear();
            txtCantidad.Clear();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
       
            this.Close();
    
        }

        
    }
}
