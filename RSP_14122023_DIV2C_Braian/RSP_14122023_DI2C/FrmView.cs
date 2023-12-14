using Entidades.Interfaces;
using Entidades.Modelos;

namespace RSP_14122023_DIV2C
{
    public partial class FrmView : Form
    {
        CentroDeEmergencia centroDeEmergencia;
        IServidorPublico servidorPublico;
        public FrmView()
        {
            this.centroDeEmergencia = new CentroDeEmergencia("24Hs");
            InitializeComponent();
        }



        private void FrmView_Load(object sender, EventArgs e)
        {
            //Alumno agregar manejadores a los eventos del centro de emergencia

            this.pgbVida.Visible = false;
            this.lblVida.Visible = false;
        }

        //Alumno: Realizar los cambios necesarios sobre ActualizarEmergencia de manera que se refleje
        //en el fomrulario la imagen de la emergencia en curso
        private void ActualizarEmergencia(Emergencia emergencia)
        {

            this.pcbServidorPublico.Image = null;
            this.pcbEmergenciaEnCurso.Image = new Bitmap(emergencia.Imagen);

        }

        //Alumno: Realizar los cambios necesarios sobre ActualizarEstadoEmergencia de manera que se refleje
        //en el fomrulario el porcentaje de avance de la emergencia
        private void ActualizarEstadoEmergencia(double estado)
        {

            this.lblVida.Text = estado.ToString("00.0%");
            this.pgbVida.Value = (int)(estado * 100);


        }

        private void btnAbrirCentro_Click(object sender, EventArgs e)
        {
            this.centroDeEmergencia.HabilitarIngreso();
            this.pgbVida.Visible = true;
            this.lblVida.Visible = true;
        }

        private void btnEnviarBombero_Click(object sender, EventArgs e)
        {
            this.servidorPublico = new Bombero();
            this.EnviarServidorPublico();
        }

        private void btnEnviarMedico_Click(object sender, EventArgs e)
        {
            this.servidorPublico = new Paramedico();
            this.EnviarServidorPublico();
        }

        private void btnEnviarPolicia_Click(object sender, EventArgs e)
        {
            this.servidorPublico = new Policia();
            this.EnviarServidorPublico();
        }

        private void EnviarServidorPublico()
        {
            this.pcbServidorPublico.Image = new Bitmap(this.servidorPublico.Imagen);
            this.centroDeEmergencia.EnviarServidorPublico(this.servidorPublico);
        }


        public void MostrarMensajeDeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Error!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnCerrarCentro_Click(object sender, EventArgs e)
        {
            this.centroDeEmergencia.DeshabilitarIngreso();
            this.pcbServidorPublico.Image = null;
            this.pcbEmergenciaEnCurso.Image = null;
            this.pgbVida.Visible = false;
            this.lblVida.Visible = false;

            //Alumno: Serializar la lista de emergencias del centro de emergencias en un archivo json
            //Alumno: Registrar el trabajo del alumno en la BD
            //Alumno: Controlar las posibles excepciones que puedieran producir

        }
    }
}
