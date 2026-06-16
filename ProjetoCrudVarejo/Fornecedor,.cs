using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoCrudVarejo
{
    public partial class Fornecedor_ : Form
    {
        public Fornecedor_()
        {
            InitializeComponent();
        }
        ConexaoFornecedor bd = new ConexaoFornecedor();
        string tabela = "tblFornecedor";

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            string inserir;
            string nome = Txtnomefantasia.Text;
            string cnpj = txtcnpj.Text;
            string razaosocial = txtrazaosocial.Text;

            if (string.IsNullOrEmpty(nome) && !string.IsNullOrEmpty(razaosocial))
            {
                inserir = string.Format($"INSERT INTO {tabela} VALUES(NULL, '{nome}', '{cnpj}', '{razaosocial}' )");
                bd.ExecutarComandos(inserir);
                ExibirDados();
                LimpaCampos();
                MessageBox.Show("Dado inserido com sucesso!", "Confirmação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Informação Inválida!", "Confirmação", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            ExibirDados();
        }
        public void ExibirDados()
        {
            string dados = $"SELECT * FROM {tabela} ORDER BY nome";
            DataTable dt = bd.ExecutarConsulta(dados);
            dtgfornecedor.DataSource = dt.AsDataView();
        }

        private void dtgfornecedor_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
                lblID.Text = dtgfornecedor.Rows[e.RowIndex].Cells[0].Value.ToString();
                Txtnomefantasia.Text = dtgfornecedor.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtcnpj.Text = dtgfornecedor.Rows[e.RowIndex].Cells[2].Value.ToString(); 
                txtrazaosocial.Text =  dtgfornecedor.Rows[e.RowIndex].Cells[3].Value.ToString();
        }
        private void dtgfornecedor_CellToolTipTextNeeded(object sender, DataGridViewCellToolTipTextNeededEventArgs e)
        {
            e.ToolTipText = "Clique em uma célula para editar ou excluir os dados";
        }
        public void LimpaCampos()
        {
            lblID.Text = "";
            Txtnomefantasia.Clear();
            txtcnpj.Clear();
            txtrazaosocial.Clear();
            Txtnomefantasia.Focus();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            string alterar;
            string nome = Txtnomefantasia.Text;
            string cnpj = txtcnpj.Text;
            string razaosocial = txtrazaosocial.Text;

            if (string.IsNullOrEmpty(nome) && !string.IsNullOrEmpty(razaosocial))
            {
                alterar = string.Format($"UPDATE {tabela} SET nome = '{Txtnomefantasia.Text}', cnpj = '{cnpj}', razao social = '{razaosocial}', WHERE id = '{lblID.Text}'");
                bd.ExecutarComandos(alterar);
                ExibirDados();
                LimpaCampos();
                MessageBox.Show("Dado alterar com sucesso!", "Confirmação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Informação Inválida!", "Confirmação", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            string excluir;
            if (!string.IsNullOrEmpty(lblID.Text))
            {
                excluir = $"DELETE FROM {tabela} WHERE id = '{lblID.Text}'";
                bd.ExecutarComandos(excluir);
                ExibirDados();
                LimpaCampos();
                MessageBox.Show("Dado alterar com sucesso!", "Confirmação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Informação Inválida!", "Confirmação", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
