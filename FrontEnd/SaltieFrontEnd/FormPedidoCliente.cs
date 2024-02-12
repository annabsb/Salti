using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;



namespace SaltieFrontEnd
{
    public partial class FormPedidoCliente : Form
    {
        private const string ApiUrl = "http://localhost:5000/";
        Login login;
        List<PedidoReceiver> lista;
        public FormPedidoCliente()
        {
            InitializeComponent();
        }
        public FormPedidoCliente(Login _login)
        {
            login = _login;
            InitializeComponent();
        }

        private async void FormPedidoCliente_Load(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            flowLayoutPanel1.AutoScroll = true;
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string url = ApiUrl + $"pedidos/{login.User.id}";
                    HttpResponseMessage response = await client.GetAsync(url);
                    if (response.IsSuccessStatusCode)
                    {
                        string json = await response.Content.ReadAsStringAsync();
                        List<PedidoReceiver> RespostaPedido = JsonConvert.DeserializeObject<List<PedidoReceiver>>(json);
                        lista = RespostaPedido;
                        foreach (PedidoReceiver pedido in RespostaPedido)
                        {
                            TextBox txtIdPedido = new TextBox();
                            txtIdPedido.Text = "Nº do pedido: " + pedido.id.ToString();
                            txtIdPedido.ReadOnly = true;
                            txtIdPedido.Width = (flowLayoutPanel1.Width/2) - 15;
                            txtIdPedido.Height = 60;
                            txtIdPedido.TextAlign = HorizontalAlignment.Center;
                            txtIdPedido.BackColor = Color.White;
                            txtIdPedido.Font = new Font(txtIdPedido.Font.FontFamily, 14, FontStyle.Bold);

                            TextBox txtNomeUsuario = new TextBox();

                            txtNomeUsuario.Text = login.User.nome;
                            txtNomeUsuario.ReadOnly = true;
                            txtNomeUsuario.Width = (flowLayoutPanel1.Width / 2) - 15;
                            txtNomeUsuario.Height = 60;
                            txtNomeUsuario.TextAlign = HorizontalAlignment.Center;
                            txtNomeUsuario.BackColor = Color.White;
                            txtNomeUsuario.Font = new Font(txtNomeUsuario.Font.FontFamily, 14, FontStyle.Bold);

                            TextBox txtItemPedido = new TextBox();

                            if (pedido.item != null && pedido.item.Any())
                            {
                                txtItemPedido.Text = pedido.item[0].produto.nome;
                            }
                            else
                            {
                                txtItemPedido.Text = "Erro!";
                            }
                            txtItemPedido.ReadOnly = true;
                            txtItemPedido.Width = flowLayoutPanel1.Width - 30;
                            txtItemPedido.Height = 60;
                            txtItemPedido.TextAlign = HorizontalAlignment.Center;
                            txtItemPedido.BackColor = Color.White;
                            txtItemPedido.Font = new Font(txtNomeUsuario.Font.FontFamily, 14, FontStyle.Bold);

                            TextBox txtStatus = new TextBox();
                            txtStatus.Text = "Status: " + pedido.Status;
                            txtStatus.Width = flowLayoutPanel1.Width - 30;
                            txtStatus.Height = 60;
                            txtStatus.TextAlign = HorizontalAlignment.Center;
                            txtStatus.BackColor = Color.White;
                            txtStatus.Font = new Font(txtNomeUsuario.Font.FontFamily, 14, FontStyle.Bold);

                            Label lbl = new Label();
                            lbl.Width = flowLayoutPanel1.Width - 30;
                            lbl.Height = 30;



                            flowLayoutPanel1.Controls.Add(txtIdPedido);
                            flowLayoutPanel1.Controls.Add(txtNomeUsuario);
                            flowLayoutPanel1.Controls.Add(txtItemPedido);
                            flowLayoutPanel1.Controls.Add(txtStatus);
                            flowLayoutPanel1.Controls.Add(lbl);


                        }
                    }
                    else
                    {
                        string json = await response.Content.ReadAsStringAsync();

                        MessageBox.Show("Ops... Algo deu errado!" + json);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro: " + ex.Message);
                }
                
            }
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
