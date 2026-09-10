using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace ProjetoCrudVarejo
{
    public partial class Fornecedor_ : Form
    {
        private readonly ConexaoFornecedor bd = new ConexaoFornecedor();
        private const string Tabela = "tblFornecedor";

        public Fornecedor_()
        {
            InitializeComponent();
        }

        private bool CamposValidos()
        {
            return !string.IsNullOrWhiteSpace(Txtnomefantasia.Text)
                && !string.IsNullOrWhiteSpace(txtcnpj.Text)
                && !string.IsNullOrWhiteSpace(txtrazaosocial.Text);
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            if (!CamposValidos())
            {
                MessageBox.Show("Preencha nome fantasia, CNPJ e razão social.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string sql = $"INSERT INTO {Tabela} (nome, cnpj, razao_social) VALUES (@nome, @cnpj, @razao_social)";

            bd.ExecutarComandos(sql,
                new MySqlParameter("@nome", Txtnomefantasia.Text.Trim()),
                new MySqlParameter("@cnpj", txtcnpj.Text.Trim()),
                new MySqlParameter("@razao_social", txtrazaosocial.Text.Trim()));

            ExibirDados();
            LimpaCampos();
            MessageBox.Show("Fornecedor cadastrado com sucesso!", "Confirmação", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            ExibirDados();
        }

        public void ExibirDados()
        {
            string sql = $"SELECT id, nome, cnpj, razao_social FROM {Tabela} ORDER BY nome";
            DataTable dt = bd.ExecutarConsulta(sql);
            dtgfornecedor.DataSource = dt;
        }

        private void dtgfornecedor_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dtgfornecedor.Rows.Count)
            {
                return;
            }

            DataGridViewRow row = dtgfornecedor.Rows[e.RowIndex];
            if (row.IsNewRow)
            {
                return;
            }

            lblID.Text = Convert.ToString(row.Cells[0].Value);
            Txtnomefantasia.Text = Convert.ToString(row.Cells[1].Value);
            txtcnpj.Text = Convert.ToString(row.Cells[2].Value);
            txtrazaosocial.Text = Convert.ToString(row.Cells[3].Value);
        }

        private void dtgfornecedor_CellToolTipTextNeeded(object sender, DataGridViewCellToolTipTextNeededEventArgs e)
        {
            e.ToolTipText = "Clique em uma linha para editar ou excluir os dados";
        }

        public void LimpaCampos()
        {
            lblID.Text = string.Empty;
            Txtnomefantasia.Clear();
            txtcnpj.Clear();
            txtrazaosocial.Clear();
            Txtnomefantasia.Focus();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(lblID.Text, out int id) || !CamposValidos())
            {
                MessageBox.Show("Selecione um fornecedor e preencha os campos corretamente.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string sql = $"UPDATE {Tabela} SET nome = @nome, cnpj = @cnpj, razao_social = @razao_social WHERE id = @id";

            bd.ExecutarComandos(sql,
                new MySqlParameter("@nome", Txtnomefantasia.Text.Trim()),
                new MySqlParameter("@cnpj", txtcnpj.Text.Trim()),
                new MySqlParameter("@razao_social", txtrazaosocial.Text.Trim()),
                new MySqlParameter("@id", id));

            ExibirDados();
            LimpaCampos();
            MessageBox.Show("Fornecedor alterado com sucesso!", "Confirmação", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(lblID.Text, out int id))
            {
                MessageBox.Show("Selecione um fornecedor para excluir.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirmacao = MessageBox.Show(
                "Deseja realmente excluir este fornecedor?",
                "Confirmar exclusão",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmacao != DialogResult.Yes)
            {
                return;
            }

            string sql = $"DELETE FROM {Tabela} WHERE id = @id";
            bd.ExecutarComandos(sql, new MySqlParameter("@id", id));

            ExibirDados();
            LimpaCampos();
            MessageBox.Show("Fornecedor excluído com sucesso!", "Confirmação", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
