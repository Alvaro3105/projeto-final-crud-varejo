using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoCrudVarejo
{
    internal class frmfornecedor
    {
        private int id;
        private string nomefantasia;
        private string razaosocial;
        private string cnpj;
        public int GetId()
        {
            return id;
        }
        public void SetId(int id)
        {
            this.id = id;
        }
        public string GetNome()
        {
            return nomefantasia;
        }
        public void SetNome(string nome)
        {
            this.nomefantasia = nome;
        }
        public string GetTelefone()
        {
            return razaosocial;
        }
        public void SetTelefone(string telefone)
        {
            this.razaosocial = telefone;
        }
        public string GetSexo()
        {
            return cnpj;
        }
        public void SetSexo(string sexo)
        {
            this.cnpj = sexo;
        }
    }
}
