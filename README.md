# Projeto CRUD Varejo

Aplicação desktop acadêmica desenvolvida em **C# com Windows Forms** para praticar operações CRUD e persistência em **MySQL**.

## Funcionalidades

- cadastro, consulta, edição e exclusão de clientes;
- cadastro, consulta, edição e exclusão de fornecedores;
- tela principal para navegação entre os módulos;
- persistência dos dados em banco MySQL.

## Tecnologias

- C#
- .NET Framework 4.7.2
- Windows Forms
- MySQL
- MySql.Data
- NuGet

## Estrutura principal

```text
ProjetoCrudVarejo/
├── Cliente.cs
├── ConexaoCliente.cs
├── ConexaoFornecedor.cs
├── frmCliente.cs
├── frmfornecedor.cs
├── frmPrincipal.cs
├── Program.cs
├── App.config
├── ProjetoCrudVarejo.csproj
└── packages.config
```

Os diretórios gerados pelo Visual Studio e pelo processo de compilação (`.vs`, `bin`, `obj` e `packages`) não fazem parte do código-fonte versionado.

## Banco de dados

O projeto utiliza uma instância local do MySQL com o banco:

```text
projetocrudvarejo
```

A configuração atual do projeto foi criada para ambiente acadêmico/local. Em um ambiente real, credenciais e strings de conexão devem ser movidas para configuração externa e não ficar fixas no código.

## Como executar

1. Clone o repositório.
2. Abra `ProjetoCrudVarejo.sln` no Visual Studio.
3. Restaure os pacotes NuGet.
4. Configure o MySQL local e crie o banco `projetocrudvarejo`.
5. Execute o projeto pelo Visual Studio.

## Contexto

Projeto acadêmico desenvolvido durante a formação técnica em TI para praticar C#, Windows Forms, CRUD e acesso a banco de dados.

## Autor

**Álvaro Pires de Souza**

- Portfólio: https://alvaro3105.github.io/Portfolio/
- GitHub: https://github.com/Alvaro3105
- LinkedIn: https://www.linkedin.com/in/alvaro-pires-de-souza/
