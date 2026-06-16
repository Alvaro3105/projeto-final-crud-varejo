using Org.BouncyCastle.Asn1.Ocsp;
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
    public partial class frmCliente : Form
    {
        public frmCliente()
        {
            InitializeComponent();
        }
        ConexaoCliente bd = new ConexaoCliente();
        string tabela = "tblCliente";

        private void frmCliente_Load(object sender, EventArgs e)
        {

        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            string inserir;
            string nome = Txtnome.Text;
            string sexo = RbdMasculino.Checked ? "M" : "F";
            string telefone = txtelefone.Text;

            if (string.IsNullOrEmpty(nome) && !string.IsNullOrEmpty(telefone))
            {
                inserir = string.Format($"INSERT INTO {tabela} VALUES(NULL, '{nome}', '{sexo}', '{telefone}' )");
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
            dtgcliente.DataSource = dt.AsDataView();
        }

        private void dtgcliente_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            lblID.Text = dtgcliente.Rows[e.RowIndex].Cells[0].Value.ToString();
            Txtnome.Text = dtgcliente.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtelefone.Text = dtgcliente.Rows[e.RowIndex].Cells[2].Value.ToString();
        }

        private void dtgcliente_CellToolTipTextNeeded(object sender, DataGridViewCellToolTipTextNeededEventArgs e)
        {
            e.ToolTipText = "Clique em uma célula para editar ou excluir os dados";
        }

        public void LimpaCampos()
        {
            lblID.Text = "";
            Txtnome.Clear();
            txtelefone.Clear();
            Txtnome.Focus();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            string alterar;
            string nome = Txtnome.Text;
            string sexo = RbdMasculino.Checked ? "M" : "F";
            string telefone = txtelefone.Text;

            if (string.IsNullOrEmpty(nome) && !string.IsNullOrEmpty(telefone))
            {
                alterar = string.Format($"UPDATE {tabela} SET nome = '{Txtnome.Text}', sexo = '{sexo}', telefone = '{telefone}', WHERE id = '{lblID.Text}'");
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
