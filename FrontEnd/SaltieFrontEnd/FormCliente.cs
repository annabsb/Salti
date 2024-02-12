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
    public partial class FormCliente : Form
    {
        private const string ApiUrl = "http://localhost:5000/";
        Login login;
        List<Pedido> lista;
        List<Vinho> Vinhos;
        char mostra = 'Q';
        public FormCliente()
        {
            InitializeComponent();
        }

        public FormCliente(Login _login)
        {
            login = _login;
            InitializeComponent();
        }

        private async void FormCliente_Load(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            flowLayoutPanel1.AutoScroll = true;
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string url = ApiUrl + $"vinhos";

                    HttpResponseMessage response = await client.GetAsync(url);
                    if (response.IsSuccessStatusCode)
                    {
                        string json = await response.Content.ReadAsStringAsync();
                        List<Vinho> RespostaVinhos = JsonConvert.DeserializeObject<List<Vinho>>(json);
                        Vinhos = RespostaVinhos;
                        foreach (Vinho vinho in RespostaVinhos)
                        {
                            TextBox textBox1 = new TextBox();
                            textBox1.Text = vinho.nome;
                            textBox1.ReadOnly = true;
                            textBox1.Width = flowLayoutPanel1.Width - 70;
                            textBox1.Height = 60;
                            textBox1.TextAlign = HorizontalAlignment.Center;
                            textBox1.BackColor = Color.White;
                            textBox1.Font = new Font(textBox1.Font.FontFamily, 14, FontStyle.Bold);

                            TextBox textBox2 = new TextBox();

                            textBox2.Text = $"Tipo: {vinho.tipo.nome}";
                            textBox2.ReadOnly = true;
                            textBox2.Width = flowLayoutPanel1.Width - 130;
                            textBox2.Height = 60;
                            textBox2.TextAlign = HorizontalAlignment.Center;
                            textBox2.BackColor = Color.White;
                            textBox2.Font = new Font(textBox2.Font.FontFamily, 14, FontStyle.Bold);

                            TextBox textBox3 = new TextBox();
                            textBox3.Text = $"R${vinho.valor}/un";
                            textBox3.ReadOnly = true;
                            textBox3.Width = 90;
                            textBox3.Height = 60;
                            textBox3.TextAlign = HorizontalAlignment.Center;
                            textBox3.BackColor = Color.White;
                            textBox3.Font = new Font(textBox2.Font.FontFamily, 14, FontStyle.Bold);

                            TextBox textBox4 = new TextBox();
                            textBox4.Text = $"{vinho.id}";
                            textBox4.ReadOnly = true;
                            textBox4.Width = 30;
                            textBox4.Height = 60;
                            textBox4.TextAlign = HorizontalAlignment.Center;
                            textBox4.BackColor = Color.White;
                            textBox4.Font = new Font(textBox4.Font.FontFamily, 14, FontStyle.Bold);

                            Button btnReserva = new Button();
                            btnReserva.Text = "Pedir";
                            btnReserva.ForeColor = Color.White;
                            btnReserva.BackColor = Color.DarkRed;
                            btnReserva.FlatStyle = FlatStyle.Popup;
                            btnReserva.FlatAppearance.BorderSize = 0;
                            btnReserva.Tag = vinho.id;
                            btnReserva.Click += BtnReserva_Click;
                            btnReserva.Width = flowLayoutPanel1.Width - 1;

                            Label lbl = new Label();
                            lbl.Width = flowLayoutPanel1.Width - 10;
                            lbl.Height = 20;

                            flowLayoutPanel1.Controls.Add(textBox4);
                            flowLayoutPanel1.Controls.Add(textBox1);
                            flowLayoutPanel1.Controls.Add(textBox2);
                            flowLayoutPanel1.Controls.Add(textBox3);
                            flowLayoutPanel1.Controls.Add(btnReserva);
                            flowLayoutPanel1.Controls.Add(lbl);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ops... Algo deu errado!");
                    }
                }
                catch
                {
                    MessageBox.Show("Erro interno do servidor!");
                }
            }
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private async void BtnReserva_Click(object sender, EventArgs e)
        {
            ItemPedidoSender itemm = new ItemPedidoSender();

            Button btn = (Button)sender;
            int vinhoId = (int)btn.Tag;
            itemm.idVinho = vinhoId;
            itemm.qtd = 1;
            Pedido novoPedido = new Pedido();
            novoPedido.idusuario = login.User.id;
            novoPedido.itens.Add(itemm);
            novoPedido.qtd = 1;
            

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string url = ApiUrl + "pedidos";
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", login.Token);
                    string jsonContent = JsonConvert.SerializeObject(novoPedido);
                    HttpContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.PostAsync(url, content);
                    MessageBox.Show(jsonContent);
                    if (response.IsSuccessStatusCode)
                    {
                        string json = await response.Content.ReadAsStringAsync();
                        MessageBox.Show("Pedido cadastrado" + json);
                    }
                    else
                    {
                        string json = await response.Content.ReadAsStringAsync();
                        MessageBox.Show("Erro ao cadastrar pedido:" + json);
                    }
                }
                catch
                {
                    MessageBox.Show("Erro interno do servidor!");
                }
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClientePedido_Click(object sender, EventArgs e)
        {
            FormPedidoCliente fpc = new FormPedidoCliente(login);
            fpc.Show();
        }
    }
}
