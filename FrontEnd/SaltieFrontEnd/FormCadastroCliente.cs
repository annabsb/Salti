using Newtonsoft.Json;
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

namespace SaltieFrontEnd
{
    public partial class FormCadastroCliente : Form
    {

        private const string ApiUrl = "http://localhost:5000/";
        List<Usuario> users;
        Login login;

        public FormCadastroCliente()
        {
            InitializeComponent();

        }
        public FormCadastroCliente(Login _login)
        {
            login = _login;

            InitializeComponent();
        }
        private async void FormCadastroCliente_Load(object sender, EventArgs e)
        {

            flowLayoutPanel1.Controls.Clear();
            flowLayoutPanel1.AutoScroll = true;

            {
                using (HttpClient client = new HttpClient())
                {
                    try
                    {
                        string url = ApiUrl + $"usuarios";
                        client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", login.Token);
                        HttpResponseMessage response = await client.GetAsync(url);
                        if (response.IsSuccessStatusCode)
                        {
                            string json = await response.Content.ReadAsStringAsync();
                            List<Usuario> RespostaUsuarios = JsonConvert.DeserializeObject<List<Usuario>>(json);
                            users = RespostaUsuarios;
                            foreach (Usuario user in RespostaUsuarios)
                            {
                                TextBox txtId = new TextBox();
                                txtId.Text = user.id.ToString(); ;
                                txtId.ReadOnly = true;
                                txtId.Width = 40;
                                txtId.Height = 60;
                                txtId.TextAlign = HorizontalAlignment.Center;
                                txtId.BackColor = Color.White;
                                txtId.Font = new Font(txtId.Font.FontFamily, 14, FontStyle.Bold);

                                TextBox txtEmail = new TextBox();

                                txtEmail.Text = $"{user.email}";
                                txtEmail.ReadOnly = true;
                                txtEmail.Width = flowLayoutPanel1.Width - 150;
                                txtEmail.Height = 60;
                                txtEmail.TextAlign = HorizontalAlignment.Center;
                                txtEmail.BackColor = Color.White;
                                txtEmail.Font = new Font(txtEmail.Font.FontFamily, 14, FontStyle.Bold);

                                //Button btnExcluir = new Button();
                                //btnExcluir.Text = "Excluir usuário";
                                //btnExcluir.Width = 52;
                                //btnExcluir.Height = 35;
                                //btnExcluir.ForeColor = Color.Red;
                                //btnExcluir.Tag = user.id;
                                //btnExcluir.Click += BtnExcluir_Click;


                                Label lbl = new Label();
                                lbl.Width = flowLayoutPanel1.Width - 10;
                                lbl.Height = 20;

                                flowLayoutPanel1.Controls.Add(txtId);
                                flowLayoutPanel1.Controls.Add(txtEmail);
                                //flowLayoutPanel1.Controls.Add(btnExcluir);
                                flowLayoutPanel1.Controls.Add(lbl);
                            }
                        }
                        else
                        {
                            string errorResponse = await response.Content.ReadAsStringAsync();
                            MessageBox.Show($"Erro: {response.StatusCode} - {response.ReasonPhrase}\nDetalhes: {errorResponse}");
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Erro interno do servidor!");
                    }
                }
            }

        }
        private async void AtualizarFlowLayoutPanel()
        {
            flowLayoutPanel1.Controls.Clear();
            flowLayoutPanel1.AutoScroll = true;

            {
                using (HttpClient client = new HttpClient())
                {
                    try
                    {
                        string url = ApiUrl + $"usuarios";
                        client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", login.Token);
                        HttpResponseMessage response = await client.GetAsync(url);
                        if (response.IsSuccessStatusCode)
                        {
                            string json = await response.Content.ReadAsStringAsync();
                            List<Usuario> RespostaUsuarios = JsonConvert.DeserializeObject<List<Usuario>>(json);
                            users = RespostaUsuarios;
                            foreach (Usuario user in RespostaUsuarios)
                            {
                                TextBox txtId = new TextBox();
                                txtId.Text = user.id.ToString();
                                txtId.ReadOnly = true;
                                txtId.Width = 40;
                                txtId.Height = 60;
                                txtId.TextAlign = HorizontalAlignment.Center;
                                txtId.BackColor = Color.White;
                                txtId.Font = new Font(txtId.Font.FontFamily, 14, FontStyle.Bold);

                                TextBox txtEmail = new TextBox();

                                txtEmail.Text = $"{user.email}";
                                txtEmail.ReadOnly = true;
                                txtEmail.Width = flowLayoutPanel1.Width - 126;
                                txtEmail.Height = 60;
                                txtEmail.TextAlign = HorizontalAlignment.Center;
                                txtEmail.BackColor = Color.White;
                                txtEmail.Font = new Font(txtEmail.Font.FontFamily, 14, FontStyle.Bold);

                                //Button btnExcluir = new Button();
                                //btnExcluir.Text = "Excluir usuário";
                                //btnExcluir.Width = 52;
                                //btnExcluir.Height = 35;
                                //btnExcluir.ForeColor = Color.Red;
                                //btnExcluir.Tag = user.id;


                                Label lbl = new Label();
                                lbl.Width = flowLayoutPanel1.Width - 10;
                                lbl.Height = 20;

                                flowLayoutPanel1.Controls.Add(txtId);
                                flowLayoutPanel1.Controls.Add(txtEmail);
                                //flowLayoutPanel1.Controls.Add(btnExcluir);
                                flowLayoutPanel1.Controls.Add(lbl);
                            }
                        }
                        else
                        {
                            string errorResponse = await response.Content.ReadAsStringAsync();
                            MessageBox.Show($"Erro: {response.StatusCode} - {response.ReasonPhrase}\nDetalhes: {errorResponse}");
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Erro interno do servidor!");
                    }
                }
            }

        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            Usuario usuarioCad = new Usuario();
            if (!txtEmailCad.Text.Contains("@") || txtEmailCad.Text == "")
            {
                MessageBox.Show("Insira um email válido!");
                return;
            }
            usuarioCad.email = txtEmailCad.Text.ToLower();

            if (txtNomeCad.Text == "" || !txtNomeCad.Text.Contains(" "))
            {
                MessageBox.Show("Favor inserir seu nome completo!");
                return;

            }
            usuarioCad.nome = txtNomeCad.Text;
            if (txtSenhaCad.Text == "" || txtConfirmarCad.Text == "")
            {
                MessageBox.Show("Favor inserer uma senha válida!");
                return;

            }
            if (txtSenhaCad.Text != txtConfirmarCad.Text)
            {
                MessageBox.Show("As senhas devem ser iguais!");
                return;
            }
            string senha = txtSenhaCad.Text;
            usuarioCad.senha = senha;
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string url = ApiUrl + "cadastro";
                    string jsonContent = JsonConvert.SerializeObject(usuarioCad);
                    HttpContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.PostAsync(url, content);

                    if (response.IsSuccessStatusCode)
                    {
                        string json = await response.Content.ReadAsStringAsync();
                        MessageBox.Show("Usuário criado!" + json);
                    }
                    else
                    {
                        MessageBox.Show("Campos email e/ou senha incorretos!");
                    }
                }
                catch
                {
                    MessageBox.Show("Erro interno do servidor!");
                }
            }
            AtualizarFlowLayoutPanel();

        }



        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnRetornoMenuAdm_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private async Task<bool> UsuarioTemPedidos(int userId)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string url = ApiUrl + $"pedidos/{userId}";
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", login.Token);
                    HttpResponseMessage response = await client.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        string json = await response.Content.ReadAsStringAsync();
                        List<Pedido> pedidos = JsonConvert.DeserializeObject<List<Pedido>>(json);
                        if (pedidos == null) return true;
                        else return false;
                    }
                    else
                    {
                        string json = await response.Content.ReadAsStringAsync();
                        MessageBox.Show("Cliente já possui pedidos cadastrados!");
                        return false;
                    }
                }
                catch
                {
                    MessageBox.Show("Erro interno do servidor!");
                    return false;
                }
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (txtIdExcluir.Text.Equals(""))
            {
                MessageBox.Show("Insira o ID corretamente!");
                return;
            }

            int userId = int.Parse(txtIdExcluir.Text);

            // Verificar se o usuário tem pedidos antes de excluí-lo
            if (await UsuarioTemPedidos(userId))
            {
                MessageBox.Show("Usuário possui pedidos cadastrados. Não é possível excluí-lo.");
                return;
            }

            // Se chegou aqui, o usuário pode ser excluído
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string url = ApiUrl + $"usuarios/{userId}";
                    MessageBox.Show(url);
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", login.Token);
                    HttpResponseMessage response = await client.DeleteAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        string json = await response.Content.ReadAsStringAsync();
                        MessageBox.Show("Usuário excluido");

                        // Atualizar o FlowLayoutPanel após a exclusão
                        AtualizarFlowLayoutPanel();
                    }
                    else
                    {
                        string json = await response.Content.ReadAsStringAsync();
                        MessageBox.Show(json);
                    }
                }
                catch
                {
                    MessageBox.Show("Erro interno do servidor!");
                }
            }
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }
    }
}