# Projeto CRUD Varejo

Aplicação desktop acadêmica desenvolvida em **C# com Windows Forms** para praticar operações CRUD e persistência em **MySQL**.

O sistema possui módulos para clientes e fornecedores e foi revisado para corrigir problemas funcionais da versão original, melhorar validações e tornar o banco de dados reproduzível.

## Funcionalidades

- cadastro, consulta, edição e exclusão de clientes;
- cadastro, consulta, edição e exclusão de fornecedores;
- seleção de registros através de `DataGridView`;
- navegação entre os módulos pela tela principal;
- persistência em MySQL;
- confirmação antes da exclusão.

## Melhorias aplicadas

- correção das validações que estavam invertidas;
- correção do SQL de atualização que possuía vírgula antes do `WHERE`;
- correção do mapeamento das colunas ao selecionar um cliente;
- comandos `INSERT`, `UPDATE` e `DELETE` parametrizados com `MySqlParameter`;
- gerenciamento de conexões com `using`, garantindo descarte adequado;
- string de conexão centralizada no `App.config`;
- item de menu de fornecedores conectado à tela correspondente;
- mensagens de operação revisadas;
- script SQL incluído para recriar o banco e as tabelas.

## Tecnologias

- C#
- .NET Framework 4.7.2
- Windows Forms
- MySQL
- MySql.Data
- ADO.NET
- NuGet

## Estrutura principal

```text
ProjetoCrudVarejo/
├── App.config
├── Cliente.cs
├── ConexaoCliente.cs
├── ConexaoFornecedor.cs
├── frmCliente.cs
├── frmPrincipal.cs
├── Fornecedor,.cs
├── Program.cs
├── ProjetoCrudVarejo.csproj
└── packages.config

database/
└── schema.sql
```

Alguns arquivos preservam nomes da estrutura original da atividade para evitar quebrar referências geradas pelo Windows Forms Designer.

## Banco de dados

O arquivo `database/schema.sql` cria:

- banco `projetocrudvarejo`;
- tabela `tblCliente`;
- tabela `tblFornecedor`.

Execute o script no MySQL antes de iniciar a aplicação.

```bash
mysql -u root -p < database/schema.sql
```

A string de conexão fica em `ProjetoCrudVarejo/App.config`, no item `ProjetoCrudVarejoDb`. Ajuste usuário, senha, servidor ou banco de acordo com seu ambiente local.

## Como executar

1. Clone o repositório.
2. Execute `database/schema.sql` no MySQL.
3. Abra `ProjetoCrudVarejo.sln` no Visual Studio.
4. Restaure os pacotes NuGet.
5. Revise a connection string em `App.config`.
6. Compile e execute o projeto.

## Contexto

Projeto acadêmico desenvolvido durante minha formação técnica em TI para praticar C#, Windows Forms, CRUD, consultas parametrizadas e acesso a banco de dados.

## Autor

**Álvaro Pires de Souza**

- Portfólio: https://alvaro3105.github.io/Portfolio/
- GitHub: https://github.com/Alvaro3105
- LinkedIn: https://www.linkedin.com/in/alvaro-pires-de-souza/
