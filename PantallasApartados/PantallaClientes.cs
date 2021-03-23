
namespace PantallasApartados
{
    using Negocio;
    using Negocio.Model;
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.IO;
    using System.Windows.Forms;

    public partial class frmApartadosClientes : Form
    {
        private int ContadorImagen, ContadorpagEntregas = 0;
        
        private readonly string directorio = ConfigurationManager.AppSettings["RutaImagenes"].ToString();
        private List<string> listRutasStrings = new List<string>();
        private List<ApartadoPorEntrega> apartadosEntregar = new List<ApartadoPorEntrega>();

        private readonly Apartadoporentregar NegApartadoPorentregar = new Apartadoporentregar();

        public frmApartadosClientes()
        {
            InitializeComponent();
        }

        private void FrmApartadosClientes_Load(object sender, EventArgs e)
        {
            var configuracion = NegApartadoPorentregar.GetConfiguracion();
            VisualizarApartadosEntrega();
            cargaImagenPublicitaria();
            TmImagen.Interval = Convert.ToInt32(configuracion[0].TiempoImagen.ToString()) * (60000 / 2);
            TmEntregas.Interval = Convert.ToInt32(configuracion[0].TiempoPantalla.ToString()) * (60000 / 2);
            TmImagen.Start();
            TmEntregas.Start();

        }

        private void TmImagen_Tick(object sender, EventArgs e)
        {
            cargaImagenPublicitaria();
        }

        private void cargaImagenPublicitaria()
        {
            GetFiles();
            var numimagenmostrar = listRutasStrings.Count;
            int numauximagen = Convert.ToInt32(listRutasStrings.Count / 2);
            if (ContadorImagen < numauximagen)
            {
                ptbImagen1.ImageLocation = listRutasStrings[ContadorImagen];
                ptbImagen2.ImageLocation = (ContadorImagen + numauximagen) < numimagenmostrar ? listRutasStrings[ContadorImagen + numauximagen] : listRutasStrings[ContadorImagen];
                ContadorImagen++;
            }
            else
            {
                ContadorImagen = 0;
            }
        }

        private void TmEntregas_Tick(object sender, EventArgs e)
        {
            VisualizarApartadosEntrega();
        }

        public void VisualizarApartadosEntrega()
        {
            ContadorpagEntregas = 0;
            var parametros = new string[3];

            var configuracion = NegApartadoPorentregar.GetConfiguracion();
            parametros[0] = DateTime.Now.ToString("yyyy/MM/dd");
            parametros[1] = "L";
            parametros[2] = configuracion[0].TiempoTranscurrido.ToString();

            apartadosEntregar = NegApartadoPorentregar.GetApartadosEntregar(parametros);


            TextBox[] atxtNumApartado = { txtNumApartado1, txtNumApartado2, txtNumApartado3, txtNumApartado4, txtNumApartado5,
                                          txtNumApartado6, txtNumApartado7, txtNumApartado8, txtNumApartado9, txtNumApartado10,
                                          txtNumApartado11, txtNumApartado12, txtNumApartado13, txtNumApartado14, txtNumApartado15,
                                          txtNumApartado16, txtNumApartado17, txtNumApartado18, txtNumApartado19, txtNumApartado20,
                                          txtNumApartado21, txtNumApartado22, txtNumApartado23, txtNumApartado24, txtNumApartado25,
                                          txtNumApartado26, txtNumApartado27, txtNumApartado28, txtNumApartado29, txtNumApartado30,
                                          txtNumApartado31, txtNumApartado32};
            TextBox[] atxtNomApartado = { txtNomApartado1, txtNomApartado2, txtNomApartado3, txtNomApartado4, txtNomApartado5,
                                          txtNomApartado6, txtNomApartado7, txtNomApartado8, txtNomApartado9, txtNomApartado10,
                                          txtNomApartado11, txtNomApartado12, txtNomApartado13, txtNomApartado14, txtNomApartado15,
                                          txtNomApartado16, txtNomApartado17, txtNomApartado18, txtNomApartado19, txtNomApartado20,
                                          txtNomApartado21, txtNomApartado22, txtNomApartado23, txtNomApartado24, txtNomApartado25,
                                          txtNomApartado26, txtNomApartado27, txtNomApartado28, txtNomApartado29, txtNomApartado30,
                                          txtNomApartado31, txtNomApartado32};

            if (apartadosEntregar.Count <= 8)
            {
                PanPublicitario.Visible = true;
                PanApartados.Visible = false;
                BtnAnterior.Visible = false;
                BtnSiguiente.Visible = false;
            }
            else if (apartadosEntregar.Count >= 8 && apartadosEntregar.Count <= 16)
            {

                PanPublicitario.Visible = false;
                PanApartados.Visible = true;
                BtnAnterior.Visible = false;
                BtnSiguiente.Visible = false;
            }
            else
            {

                PanPublicitario.Visible = false;
                PanApartados.Visible = true;
                PanApartados2.Visible = false;
                BtnAnterior.Visible = false;
                BtnSiguiente.Visible = true;
            }



            if (apartadosEntregar.Count > 32)
            {
                for (int i = 0; i < 32; i++)
                {
                    atxtNumApartado[i].Text = apartadosEntregar[i].NumApartado;
                    atxtNomApartado[i].Text = apartadosEntregar[i].Nombrecliente;
                }

                for (int x = 16; x < 32; x++)
                {

                    atxtNumApartado[x].Text = string.Empty;
                    atxtNomApartado[x].Text = string.Empty;
                }
            }
            else
            {
                for (int i = 0; i < apartadosEntregar.Count; i++)
                {
                    atxtNumApartado[i].Text = apartadosEntregar[i].NumApartado;
                    atxtNomApartado[i].Text = apartadosEntregar[i].Nombrecliente;
                }

                for (int x = apartadosEntregar.Count; x < 32; x++)
                {

                    atxtNumApartado[x].Text = string.Empty;
                    atxtNomApartado[x].Text = string.Empty;
                }
            }
        }

        private void BtnSiguiente_Click(object sender, EventArgs e)
        {
            ContadorpagEntregas++;
            if (ContadorpagEntregas >= 1)
            {
                TextBox[] atxtNumApartado = { txtNumApartado17, txtNumApartado18, txtNumApartado19, txtNumApartado20,
                                          txtNumApartado21, txtNumApartado22, txtNumApartado23, txtNumApartado24, txtNumApartado25,
                                          txtNumApartado26, txtNumApartado27, txtNumApartado28, txtNumApartado29, txtNumApartado30,
                                          txtNumApartado31, txtNumApartado32};
                TextBox[] atxtNomApartado = { txtNomApartado17, txtNomApartado18, txtNomApartado19, txtNomApartado20,
                                          txtNomApartado21, txtNomApartado22, txtNomApartado23, txtNomApartado24, txtNomApartado25,
                                          txtNomApartado26, txtNomApartado27, txtNomApartado28, txtNomApartado29, txtNomApartado30,
                                          txtNomApartado31, txtNomApartado32};


                if (apartadosEntregar.Count > 16 && (ContadorpagEntregas * 16) < apartadosEntregar.Count)
                {

                    for (int i = 0; i < 16; i++)
                    {
                        var aux = (i + 16) * ContadorpagEntregas;
                        if (aux >= apartadosEntregar.Count)
                        {
                            break;
                        }
                        atxtNumApartado[i].Text = apartadosEntregar[aux].NumApartado;
                        atxtNomApartado[i].Text = apartadosEntregar[aux].Nombrecliente;
                        PanApartados2.Visible = true;
                        PanApartados.Visible = false;
                    }


                    var limpieza = apartadosEntregar.Count - (ContadorpagEntregas * 16);
                    for (int x = 0 + limpieza; x < 16; x++)
                    {

                        atxtNumApartado[x].Text = string.Empty;
                        atxtNomApartado[x].Text = string.Empty;
                        BtnSiguiente.Visible = false;
                    }

                    BtnAnterior.Visible = true;
                }

                if (ContadorpagEntregas < apartadosEntregar.Count / 16)
                {
                    BtnSiguiente.Visible = true;
                    BtnAnterior.Visible = true;
                }
                else
                {
                    BtnSiguiente.Visible = false;
                }
            }
            else
            {

            }
        }

        private void BtnAnterior_Click(object sender, EventArgs e)
        {

            ContadorpagEntregas--;
            if (ContadorpagEntregas > 0)
            {

                TextBox[] atxtNumApartado = { txtNumApartado17, txtNumApartado18, txtNumApartado19, txtNumApartado20,
                                          txtNumApartado21, txtNumApartado22, txtNumApartado23, txtNumApartado24, txtNumApartado25,
                                          txtNumApartado26, txtNumApartado27, txtNumApartado28, txtNumApartado29, txtNumApartado30,
                                          txtNumApartado31, txtNumApartado32};
                TextBox[] atxtNomApartado = { txtNomApartado17, txtNomApartado18, txtNomApartado19, txtNomApartado20,
                                          txtNomApartado21, txtNomApartado22, txtNomApartado23, txtNomApartado24, txtNomApartado25,
                                          txtNomApartado26, txtNomApartado27, txtNomApartado28, txtNomApartado29, txtNomApartado30,
                                          txtNomApartado31, txtNomApartado32};


                if (apartadosEntregar.Count > 16)
                {

                    for (int i = 0; i < 16; i++)
                    {
                        var aux = (i + 16) * ContadorpagEntregas;
                        if (aux >= apartadosEntregar.Count)
                        {
                            break;
                        }
                        atxtNumApartado[i].Text = apartadosEntregar[aux].NumApartado;
                        atxtNomApartado[i].Text = apartadosEntregar[aux].Nombrecliente;
                        PanApartados2.Visible = true;
                        PanApartados.Visible = false;
                    }           


                    var limpieza = apartadosEntregar.Count - (ContadorpagEntregas * 16);
                    for (int x = 0 + limpieza; x < 16; x++)
                    {

                        atxtNumApartado[x].Text = string.Empty;
                        atxtNomApartado[x].Text = string.Empty;
                    }

                    if (ContadorpagEntregas < apartadosEntregar.Count / 16)
                    {
                        BtnSiguiente.Visible = true;
                        BtnAnterior.Visible = true;
                    }
                    else
                    {
                        BtnAnterior.Visible = false;
                    }
                }
            }
            else
            {
                PanApartados.Visible = true;
                PanApartados2.Visible = false;
                BtnAnterior.Visible = false;

            }

        }

        private void GetFiles()
        {
            listRutasStrings = new List<string>();
            var list = Directory.GetFiles(directorio);

            foreach (var item in list)
            {
                listRutasStrings.Add(item);
            }
        }

    }
}
