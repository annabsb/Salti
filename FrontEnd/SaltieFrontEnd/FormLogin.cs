using System;
using System.Text;
using System.Net.Http;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace SaltieFrontEnd
{
    public partial class FormLogin : Form
    {
        private const string ApiUrl = "http://localhost:5000/";
        public FormLogin()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            txtLoginSenha.PasswordChar = '*';
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txtLoginSenha_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtLoginEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void ckADM_CheckedChanged(object sender, EventArgs e)
        {

        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            
                Usuario usuario = new Usuario();
                usuario.email = txtLoginEmail.Text.ToLower();
                usuario.senha = txtLoginSenha.Text;
                if (!txtLoginEmail.Text.Contains("@") || txtLoginEmail.Text.Equals(""))
                {
                    MessageBox.Show("Insira o email corretamente!");
                    return;
                }
                if (txtLoginSenha.Text.Equals(""))
                {
                    MessageBox.Show("Insira a senha corretamente!");
                    return;
                }
                using (HttpClient client = new HttpClient())
                {
                    try
                    {
                        string url = ApiUrl + "login";
                        string jsonContent = JsonConvert.SerializeObject(usuario);
                        HttpContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                        HttpResponseMessage response = await client.PostAsync(url, content);
                       
                    if (response.IsSuccessStatusCode)
                        {
                            string json = await response.Content.ReadAsStringAsync();
                            Login apiSaltie = JsonConvert.DeserializeObject<Login>(json);

                            if (apiSaltie.User.cargo == "adm")
                            {
                                FormADM adm = new FormADM(apiSaltie);
                                adm.ShowDialog();
                            txtLoginEmail.Text = "";
                            txtLoginSenha.Text = "";

                        }
                            else
                            {
                                FormCliente cliente = new FormCliente(apiSaltie);
                                cliente.ShowDialog();
                            txtLoginSenha.Text = "";
                            txtLoginEmail.Text = "";
                        }
                        }
                        else
                        {
                            MessageBox.Show("Campos email e/ou senha incorretos!");
                            txtLoginSenha.Text = "";
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Erro interno do servidor!");
                    }
                }
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
