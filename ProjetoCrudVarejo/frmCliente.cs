using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace ProjetoCrudVarejo
{
    public partial class frmCliente : Form
    {
        private readonly ConexaoCliente bd = new ConexaoCliente();
        private const string Tabela = "tblCliente";

        public frmCliente()
        {
            InitializeComponent();
        }

        private void frmCliente_Load(object sender, EventArgs e)
        {
            ExibirDados();
        }

        private bool CamposValidos()
        {
            return !string.IsNullOrWhiteSpace(Txtnome.Text)
                && !string.IsNullOrWhiteSpace(txtelefone.Text)
                && (RbdMasculino.Checked || radioButton2.Checked);
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            if (!CamposValidos())
            {
                MessageBox.Show("Preencha nome, telefone e sexo.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string sql = $"INSERT INTO {Tabela} (nome, sexo, telefone) VALUES (@nome, @sexo, @telefone)";
            string sexo = RbdMasculino.Checked ? "M" : "F";

            bd.ExecutarComandos(sql,
                new MySqlParameter("@nome", Txtnome.Text.Trim()),
                new MySqlParameter("@sexo", sexo),
                new MySqlParameter("@telefone", txtelefone.Text.Trim()));

            ExibirDados();
            LimpaCampos();
            MessageBox.Show("Cliente cadastrado com sucesso!", "Confirmação", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            ExibirDados();
        }

        public void ExibirDados()
        {
            string sql = $"SELECT id, nome, sexo, telefone FROM {Tabela} ORDER BY nome";
            DataTable dt = bd.ExecutarConsulta(sql);
            dtgcliente.DataSource = dt;
        }

        private void dtgcliente_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dtgcliente.Rows.Count)
            {
                return;
            }

            DataGridViewRow row = dtgcliente.Rows[e.RowIndex];
            if (row.IsNewRow)
            {
                return;
            }

            lblID.Text = Convert.ToString(row.Cells[0].Value);
            Txtnome.Text = Convert.ToString(row.Cells[1].Value);

            string sexo = Convert.ToString(row.Cells[2].Value);
            RbdMasculino.Checked = string.Equals(sexo, "M", StringComparison.OrdinalIgnoreCase);
            radioButton2.Checked = string.Equals(sexo, "F", StringComparison.OrdinalIgnoreCase);

            txtelefone.Text = Convert.ToString(row.Cells[3].Value);
        }

        private void dtgcliente_CellToolTipTextNeeded(object sender, DataGridViewCellToolTipTextNeededEventArgs e)
        {
            e.ToolTipText = "Clique em uma linha para editar ou excluir os dados";
        }

        public void LimpaCampos()
        {
            lblID.Text = string.Empty;
            Txtnome.Clear();
            txtelefone.Clear();
            RbdMasculino.Checked = false;
            radioButton2.Checked = false;
            Txtnome.Focus();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(lblID.Text, out int id) || !CamposValidos())
            {
                MessageBox.Show("Selecione um cliente e preencha os campos corretamente.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string sexo = RbdMasculino.Checked ? "M" : "F";
            string sql = $"UPDATE {Tabela} SET nome = @nome, sexo = @sexo, telefone = @telefone WHERE id = @id";

            bd.ExecutarComandos(sql,
                new MySqlParameter("@nome", Txtnome.Text.Trim()),
                new MySqlParameter("@sexo", sexo),
                new MySqlParameter("@telefone", txtelefone.Text.Trim()),
                new MySqlParameter("@id", id));

            ExibirDados();
            LimpaCampos();
            MessageBox.Show("Cliente alterado com sucesso!", "Confirmação", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(lblID.Text, out int id))
            {
                MessageBox.Show("Selecione um cliente para excluir.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirmacao = MessageBox.Show(
                "Deseja realmente excluir este cliente?",
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
            MessageBox.Show("Cliente excluído com sucesso!", "Confirmação", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
