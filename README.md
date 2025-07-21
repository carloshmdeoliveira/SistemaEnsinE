# 📋 Sistema de Cadastro - EnsinE

Projeto desenvolvido como parte de um desafio técnico da Faculdade EnsinE. O sistema tem como objetivo o **cadastro e gerenciamento de clientes e produtos**, utilizando a tecnologia ASP.NET MVC com SQL Server.

---

## ✅ Funcionalidades

- CRUD completo de **Produtos**:
  - Nome
  - Preço
  - Situação (ativo/inativo)
  - Comissão (%)

- CRUD completo de **Clientes**:
  - Nome
  - Contato
  - E-mail
  - Produto associado

- Associação entre clientes e produtos.
- Interface simples e funcional.
- Dados persistidos em banco de dados SQL Server.

---

## 🛠️ Tecnologias Utilizadas

- ASP.NET MVC 5
- Entity Framework (Code First)
- SQL Server Express 2019
- Bootstrap (layout padrão)
- Visual Studio 2022

---

## ⚙️ Como executar o projeto

### 1. Clone o repositório (caso esteja no GitHub)
```bash
git clone https://github.com/usuario/nome-do-repositorio.git
```

### 2. Abra o projeto no Visual Studio 2022
Vá em Arquivo > Abrir > Projeto/Solução

Selecione o arquivo SistemaEnsinE.sln

### 3. Configure a string de conexão
No arquivo appsettings.json, localize a tag <connectionStrings> e ajuste conforme sua instância do SQL Server:

```bash
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=.\\SQLEXPRESS;Database=SistemaEnsinE;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}
```

4. Aplicar as migrations e criar o banco
No Console do Gerenciador de Pacotes do Visual Studio:

```bash
Update-Database
```

Isso criará automaticamente o banco de dados e suas tabelas.

5. Executar o projeto

Pressione **Ctrl + F5** ou clique em Executar no Visual Studio para abrir a aplicação no navegador.

---

## 📎 Organização das Pastas

* Controllers: Lógica de controle para Clientes e Produtos.

* Models: Classes de domínio (Cliente e Produto).

* Views: Páginas Razor com CRUD e layout.

* Migrations: Controle de versão do banco via Entity Framework.

## 🧾 Considerações Finais

O projeto está estruturado para fácil entendimento e manutenção.

Pode ser estendido para incluir filtros, autenticação, exportação de dados e dashboards.

O código segue boas práticas de arquitetura MVC.

---

Desenvolvido por: Carlos Henrique Mattos

Desafio técnico – Faculdade EnsinE

Julho de 2025
