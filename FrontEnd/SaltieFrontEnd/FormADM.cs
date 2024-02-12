using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Net.Http;

namespace SaltieFrontEnd
{
    public partial class FormADM : Form
    {
        private const string ApiUrl = "http://localhost:5000/";
        Login login;
        List<Vinho> vinhos;
        public FormADM()
        {
            InitializeComponent();
        }
        public FormADM(Login _login)
        {
            login = _login;
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        
        private async void FormADM_Load(object sender, EventArgs e)
        {

            flowLayoutPanel1.Controls.Clear();
            flowLayoutPanel1.AutoScroll = true;

            {
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
                            vinhos = RespostaVinhos;
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
                                textBox3.Text = $"R${vinho.valor}";
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


                                Label lbl = new Label();
                                lbl.Width = flowLayoutPanel1.Width - 10;
                                lbl.Height = 20;

                                flowLayoutPanel1.Controls.Add(textBox4);
                                flowLayoutPanel1.Controls.Add(textBox1);
                                flowLayoutPanel1.Controls.Add(textBox2);
                                flowLayoutPanel1.Controls.Add(textBox3);
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
            
        }

        private async void btnADMcadastro_Click(object sender, EventArgs e)
        {
            FormCadastroCliente cad = new FormCadastroCliente(login);
            cad.ShowDialog();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCadastroVinho_Click(object sender, EventArgs e)
        {
            FormCadastroVinho fcv = new FormCadastroVinho(login);
            fcv.ShowDialog();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnADMpedidos_Click(object sender, EventArgs e)
        {
            ListaPedidosADM lpa = new ListaPedidosADM(login);
            lpa.Show();
        }
    }
}
