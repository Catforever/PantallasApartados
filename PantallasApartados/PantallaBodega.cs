namespace PantallasApartados
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Windows.Forms;
    using Negocio;
    using Negocio.Model;

    public partial class frmApartadosBodega : Form
    {
        //private readonly int ContadorImagen;
        private int ContadorpagEntregas = 0;
        private List<ApartadoPorEntrega> apartadosEntregar = new List<ApartadoPorEntrega>();

        private readonly Apartadoporentregar NegApartadoPorentregar = new Apartadoporentregar();
        public frmApartadosBodega()
        {
            InitializeComponent();
        }

        private void PantallaBodega_Load(object sender, EventArgs e)
        {
            var configuracion = NegApartadoPorentregar.GetConfiguracion();
            VisualizarApartadosEntrega();
            TmEntregas.Interval = Convert.ToInt32(configuracion[0].TiempoPantalla.ToString()) * (60000 / 2);
            TmEntregas.Start();
        }

        

        private void TmEntregas_Tick(object sender, EventArgs e)
        {
            VisualizarApartadosEntrega();
        }

        public void VisualizarApartadosEntrega()
        {
            ContadorpagEntregas = 0;
            var parametros = new string[3];
            var criterioscolor = NegApartadoPorentregar.getcriteriosColor();
            var configuracion = NegApartadoPorentregar.GetConfiguracion();
            parametros[0] = DateTime.Now.ToString("yyyy/MM/dd"); 
            parametros[1] = "L";
            parametros[2] = configuracion[0].TiempoTranscurrido.ToString();

            apartadosEntregar = NegApartadoPorentregar.GetApartadosEntregar(parametros);
            TextBox[] atxtNumApartado = { txtNumApartado1, txtNumApartado2, txtNumApartado3, txtNumApartado4, txtNumApartado5,
                                          txtNumApartado6, txtNumApartado7, txtNumApartado8, txtNumApartado9, txtNumApartado10,
                                          txtNumApartado11, txtNumApartado12 };

            TextBox[] atxtNomApartado = { txtNomApartado1, txtNomApartado2, txtNomApartado3, txtNomApartado4, txtNomApartado5,
                                          txtNomApartado6, txtNomApartado7, txtNomApartado8, txtNomApartado9, txtNomApartado10,
                                          txtNomApartado11, txtNomApartado12 };

            TextBox[] atxtTiemDemo = { txtTiemDemo1, txtTiemDemo2, txtTiemDemo3,txtTiemDemo4, txtTiemDemo5,
                                       txtTiemDemo6, txtTiemDemo7, txtTiemDemo8, txtTiemDemo9, txtTiemDemo10,
                                       txtTiemDemo11, txtTiemDemo12 };

            TextBox[] atxtNumOpe = { txtNumOpe1, txtNumOpe2, txtNumOpe3,txtNumOpe4, txtNumOpe5,
                                       txtNumOpe6, txtNumOpe7, txtNumOpe8, txtNumOpe9, txtNumOpe10,
                                       txtNumOpe11, txtNumOpe12};

            if (apartadosEntregar.Count < 12)
            {
                for (int i = 0; i < apartadosEntregar.Count; i++)
                {
                    atxtNumApartado[i].Text = apartadosEntregar[i].NumApartado;
                    atxtNomApartado[i].Text = apartadosEntregar[i].Nombrecliente;
                    atxtTiemDemo[i].Text = apartadosEntregar[i].MinTranscurrido + " min.";
                    atxtNumOpe[i].Text = apartadosEntregar[i].NumOperador;

                    Coloreacontroles(atxtNomApartado[i], atxtNumApartado[i], atxtTiemDemo[i], atxtNumOpe[i], Convert.ToInt32(apartadosEntregar[i].MinTranscurrido), criterioscolor);
                }

                for (int x = apartadosEntregar.Count; x < 12; x++)
                {

                    atxtNumApartado[x].Text = string.Empty;
                    atxtNomApartado[x].Text = string.Empty;
                    atxtTiemDemo[x].Text = string.Empty;
                    atxtNumOpe[x].Text = string.Empty;
                    Coloreacontroles(atxtNomApartado[x], atxtNumApartado[x], atxtTiemDemo[x], atxtNumOpe[x], 0, criterioscolor);
                }
            }
            else
            {
                for (int i = 0; i < 12; i++)
                {
                    atxtNumApartado[i].Text = apartadosEntregar[i].NumApartado;
                    atxtNomApartado[i].Text = apartadosEntregar[i].Nombrecliente;
                    atxtTiemDemo[i].Text = apartadosEntregar[i].MinTranscurrido + " min.";
                    atxtNumOpe[i].Text = apartadosEntregar[i].NumOperador;
                    Coloreacontroles(atxtNomApartado[i], atxtNumApartado[i], atxtTiemDemo[i], atxtNumOpe[i], Convert.ToInt32(apartadosEntregar[i].MinTranscurrido), criterioscolor);
                }
            }

            var indicadores= NegApartadoPorentregar.GetIndicadores(parametros);
            if (indicadores.Count > 0)
            {
                txtTiempoPromEnt.Text = indicadores[0].TiemPromEnt.ToString();
                txtApartEntre.Text = indicadores[0].AparLiqEntr.ToString();
                txtOperaActi.Text = indicadores[0].OperadoresActivos.ToString();
                txtAparta_Opera.Text = indicadores[0].Aparta_Oper.ToString();
            }
        }

        private void Coloreacontroles(TextBox txtNomApartado, TextBox txtNumApartado, TextBox txtTiemDemo, TextBox txtNumOpe, int minTranscurrido, List<CriterioColores> criterioColores)
        {
            if (minTranscurrido == 0)
            {
                var colorFondo = Color.FromArgb(255, 173, 29);
                var colorLetra = Color.FromArgb(30, 30, 30);

                Pintacontrol(txtNumApartado, colorFondo, colorLetra);
                Pintacontrol(txtNomApartado, colorFondo, colorLetra);
                Pintacontrol(txtTiemDemo, colorFondo, colorLetra);
                Pintacontrol(txtNumOpe, colorFondo, colorLetra);
            }
            else
            {
                foreach (var item in criterioColores)
                {

                    if (minTranscurrido > Convert.ToInt32(item.ValMinimo) && minTranscurrido <= Convert.ToInt32(item.ValMax))
                    {

                        var colorFondo = Color.FromName(item.ColorFondo);
                        var colorLetra = Color.FromName(item.ColorLetra);
                        Pintacontrol(txtNumApartado, colorFondo, colorLetra);
                        Pintacontrol(txtNomApartado, colorFondo, colorLetra);
                        Pintacontrol(txtTiemDemo, colorFondo, colorLetra);
                        Pintacontrol(txtNumOpe, colorFondo, colorLetra);
                    }
                }
            }


        }

        private void Pintacontrol(TextBox control, Color colorFondo, Color colorLetra)
        {
            control.BackColor = colorFondo;
            control.ForeColor = colorLetra;
        }
    }

}
