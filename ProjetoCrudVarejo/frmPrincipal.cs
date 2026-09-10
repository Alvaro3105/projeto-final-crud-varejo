using System;
using System.Windows.Forms;

namespace ProjetoCrudVarejo
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void cadastroDeClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var telaCliente = new frmCliente())
            {
                telaCliente.ShowDialog(this);
            }
        }

        private void cadastroDeFornecedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var telaFornecedor = new Fornecedor_())
            {
                telaFornecedor.ShowDialog(this);
            }
        }
    }
}
