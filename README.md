# ProjetoCrudVarejo 🛒

O **ProjetoCrudVarejo** é uma aplicação desktop desenvolvida em **C#** utilizando o framework **.NET (Windows Forms)**. O sistema foi projetado para gerenciar operações essenciais de um comércio varejista através de funcionalidades completas de CRUD (Create, Read, Update, Delete) para clientes e fornecedores.

---

## 🚀 Funcionalidades

- **Tela Principal (`frmPrincipal`):** Painel de navegação centralizado para acesso aos módulos do sistema.
- **Gestão de Clientes:**
  - Cadastro, consulta, edição e exclusão de clientes (`frmCliente`).
  - Classe de regras/entidade de cliente (`Cliente.cs`).
  - Camada de persistência/conexão dedicada a clientes (`ConexaoCliente.cs`).
- **Gestão de Fornecedores:**
  - Cadastro, consulta, edição e exclusão de fornecedores (`frmfornecedor`).
  - Classe de regras/entidade de fornecedor (`Fornecedor.cs`).
  - Camada de persistência/conexão dedicada a fornecedores (`ConexaoFornecedor.cs`).

---

## 🛠️ Tecnologias e Dependências Utilizadas

- **Linguagem:** C#
- **Interface Gráfica:** Windows Forms (WinForms)
- **Framework Base:** .NET Framework / .NET Core (compatível com Windows)
- **Gerenciamento de Pacotes:** NuGet
- **Bibliotecas Principais:**
  - `BouncyCastle.Cryptography` (v2.6.2): Para suporte a operações seguras de criptografia e assinaturas digitais.
  - `Google.Protobuf` (v3.32.0): Para serialização eficiente de dados estruturados.

---

## 📂 Estrutura do Projeto

Abaixo estão destacados os componentes fundamentais encontrados no código-fonte principal:

```text
ProjetoCrudVarejo/
│
├── Cliente.cs                  # Modelo/Entidade de Clientes
├── ConexaoCliente.cs           # Métodos de banco de dados/conexão para Clientes
├── frmCliente.cs               # Interface visual (Form) para o CRUD de Clientes
│
├── Fornecedor.cs               # Modelo/Entidade de Fornecedores
├── ConexaoFornecedor.cs        # Métodos de banco de dados/conexão para Fornecedores
├── frmfornecedor.cs            # Interface visual (Form) para o CRUD de Fornecedores
│
├── frmPrincipal.cs             # Tela inicial e menu de navegação do sistema
├── Program.cs                  # Ponto de entrada (Main) da aplicação
└── App.config                  # Arquivo de configuração (Ex: Strings de Conexão)
