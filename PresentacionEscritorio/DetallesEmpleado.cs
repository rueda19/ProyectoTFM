using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Syncfusion.Windows.Forms;
using Syncfusion.Windows.Forms.Tools;
using Negocio;
using Modelo;
using System.IO;

namespace PresentacionEscritorio
{
    public partial class DetallesEmpleado : MetroForm
    {
        private string user;
        private string Usuario;
        private Negocio.Negocio negocio = new Negocio.Negocio();

        public DetallesEmpleado(string usu)
        {
            InitializeComponent();
            Usuario = usu;
            user = System.Security.Principal.WindowsIdentity.GetCurrent().Name.Substring(System.Security.Principal.WindowsIdentity.GetCurrent().Name.IndexOf("\\") + 1);
            if (!user.Equals(Usuario, StringComparison.OrdinalIgnoreCase))
            {
                textBoxDepartamento.Enabled = false;
                textBoxNombre.Enabled = false;
                pictureBoxFoto.Enabled = false;
                textBoxTelefono.Enabled = false;
            }
            object[] emp = (object[])negocio.getEmpleadosFoto().Select("Usuario = '" + usu + "'")[0].ItemArray;
            textBoxDepartamento.Text = emp[3].ToString();
            textBoxNombre.Text = emp[2].ToString();
            textBoxUsuario.Text = emp[1].ToString();
            textBoxTelefono.Text = emp[4].ToString();
            //Byte[] foto = negocio.getEmpleadoFoto(Usuario);
            if (emp[0].ToString() != "")
            {
                Byte[] foto = (Byte[])emp[0];
                pictureBoxFoto.Image = ByteToImage(foto);
            }

            /*
            Empleado em = negocio.getEmpleado(Usuario);
            textBoxDepartamento.Text = em.Departamento;
            textBoxNombre.Text = em.NombreCompleto;
            textBoxUsuario.Text = em.Usuario;
            Byte[] foto = negocio.getEmpleadoFoto(Usuario);
            if (foto != null)
                pictureBoxFoto.Image = ByteToImage(foto);
            textBoxTelefono.Text = negocio.getEmpleadosFoto().Select("Usuario = '" + em.Usuario + "'")[0].ItemArray[4].ToString();*/
        }

        private void textBoxNombre_Leave(object sender, EventArgs e)
        {
            negocio.updateEmpleado(Usuario, "NombreCompleto", textBoxNombre.Text, null);
        }

        private void textBoxDepartamento_Leave(object sender, EventArgs e)
        {
            negocio.updateEmpleado(Usuario, "Departamento", textBoxDepartamento.Text, null);
        }

        private void pictureBoxFoto_DoubleClick(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string imagen = openFileDialog1.FileName;
                    pictureBoxFoto.Image = Image.FromFile(imagen);
                    ImageConverter converter = new ImageConverter();
                    negocio.updateEmpleado(Usuario, "Foto", null, (byte[])converter.ConvertTo(pictureBoxFoto.Image, typeof(byte[])));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("El archivo seleccionado no es un tipo de imagen válido");
            }
        }

        private void buttonAceptar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public static Bitmap ByteToImage(byte[] blob)
        {
            MemoryStream mStream = new MemoryStream();
            byte[] pData = blob;
            mStream.Write(pData, 0, Convert.ToInt32(pData.Length));
            Bitmap bm = new Bitmap(mStream, false);
            mStream.Dispose();
            return bm;

        }

        private void textBoxTelefono_Leave(object sender, EventArgs e)
        {
            negocio.updateEmpleado(Usuario, "Telefono", textBoxTelefono.Text, null);
        }
    }
}
