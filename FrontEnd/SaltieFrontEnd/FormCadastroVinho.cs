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
    public partial class FormCadastroVinho : Form
    {

        private const string ApiUrl = "http://localhost:5000/";
        Login login;
        List<Vinho> Vinhos;
        string nomeDoArquivo;
        char mostra = 'Q';
        public FormCadastroVinho()
        {
            InitializeComponent();
        }
        private Dictionary<int, string> tiposDeVinho = new Dictionary<int, string>
        {
            { 1, "Tinto suave" },
            { 2, "Tinto seco" },
            { 3, "Branco suave" },
            { 4, "Branco seco" },
            { 5, "Espumante" }
        };
        public FormCadastroVinho(Login _login)
        {
            InitializeComponent();

            cmbTipoVinho.DataSource = new BindingSource(tiposDeVinho, null);
            cmbTipoVinho.DisplayMember = "Value";
            cmbTipoVinho.ValueMember = "Key";
            login = _login;
            cmbTipoVinhoAtt.DataSource = new BindingSource(tiposDeVinho, null);
            cmbTipoVinhoAtt.DisplayMember = "Value";
            cmbTipoVinhoAtt.ValueMember = "Key";
            login = _login;
        }


        private void label7_Click(object sender, EventArgs e)
        {

        }

        private async void btnCadastraNovoVinho_Click(object sender, EventArgs e)
        {
            VinhoSender vinho = new VinhoSender();
            if (txtNomeVinho.Text == "")
            {
                MessageBox.Show("Favor inserir um nome!");
                return;
            }
            if (cmbTipoVinho.SelectedItem == null)
            {
                MessageBox.Show("Favor selecionar um tipo de vinho!");
                return;
            }

            if (txtQtdVinho.Text == "")
            {
                MessageBox.Show("Favor preencher a quantidade!");
            }
            try
            {
                int.Parse(txtQtdVinho.Text);
            }
            catch
            {
                MessageBox.Show("A quantidade deve ser numérico!");
            }
            try
            {
                int.Parse(txtValorVinho.Text);
            }
            catch
            {
                MessageBox.Show("O Valor deve ser numérico!");
            }
            vinho.idTipo = (int)cmbTipoVinho.SelectedValue;
            vinho.nome = txtNomeVinho.Text;
            vinho.qtd = int.Parse(txtQtdVinho.Text);
            vinho.valor = int.Parse(txtValorVinho.Text);

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string url = ApiUrl + "vinhos";
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", login.Token);
                    string jsonContent = JsonConvert.SerializeObject(vinho);
                    HttpContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.PostAsync(url, content);

                    if (response.IsSuccessStatusCode)
                    {
                        string json = await response.Content.ReadAsStringAsync();
                        MessageBox.Show("Vinho cadastrado!" + json);
                        txtQtdVinho.Text = "";
                        txtNomeVinho.Text = "";
                        txtQtdVinho.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Erro!");
                    }
                }
                catch
                {
                    MessageBox.Show("Erro interno do servidor!");
                }
            }
        }

        private void btnRetornoMenuAdm_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void txtNomeVinhoAtt_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbTipoVinhoAtt_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtQtdVinhoAtt_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtValorVinhoAtt_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private async void btnAttVinho_Click(object sender, EventArgs e)
        {
            VinhoUpdater vinho = new VinhoUpdater();
            vinho.nome = txtNomeVinhoAtt.Text;
            vinho.idTipo = (int)cmbTipoVinhoAtt.SelectedValue;
            
            try
            {
                vinho.valor = int.Parse(txtValorVinhoAtt.Text);
            }
            catch
            {
                MessageBox.Show("O valor deve ser um número!");
            }
            using (HttpClient client = new HttpClient())
            {
                try
                {       
                    string url = ApiUrl + $"vinhos/{int.Parse(txtIdVinhoAtt.Text)}";
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", login.Token);
                    string jsonContent = JsonConvert.SerializeObject(vinho);
                    HttpContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.PutAsync(url, content);
                    MessageBox.Show(jsonContent);

                    if (response.IsSuccessStatusCode)
                    {
                        string json = await response.Content.ReadAsStringAsync();
                        MessageBox.Show("Vinho Atualizado!" + json);
                        txtQtdVinho.Text = "";
                        txtNomeVinho.Text = "";
                        txtQtdVinho.Text = "";
                    }
                    else
                    {
                        string json = await response.Content.ReadAsStringAsync();

                        MessageBox.Show("Erro!" + json);
                    }
                }
                catch
                {
                    MessageBox.Show("Erro interno do servidor!");
                }
            }
        }
    }
}
