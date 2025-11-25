
# 📘 **EduPay – API**

API para gerenciamento de alunos, cursos, matrículas e pagamentos utilizando **.NET 8** e **SQLite**.

---

## 📂 **Estrutura do Projeto**

```
EduPay/
│
├── Controllers/          # Endpoints da API
├── Data/                 # DbContext (APIContext)
├── DTO/                  # Objetos de transferência de dados
├── Entitys/              # Entidades do domínio (Aluno, Curso, Pagamento…)
├── Migrations/           # Migrations do Entity Framework
├── Services/             # Regras de negócio
│
├── appsettings.json      # Configurações e connection string
├── identifier.sqlite     # Banco de dados SQLite
├── Program.cs            # Configuração da aplicação
```

---

## 🛠 **Requisitos**

* **.NET SDK 8.0**
* Rider / VSCode / VS 2022
* SQLite (DB Browser opcional)

---

## 🗃 **Migrations e Banco**

Criar migration:

```bash
dotnet ef migrations add Initial
```

Aplicar no banco:

```bash
dotnet ef database update
```

O banco fica em:

```
identifier.sqlite
```

---

## ▶️ **Rodar o Projeto**

```bash
dotnet run
```

A API sobe em:

👉 **[https://localhost:5166](https://localhost:5166)**

Swagger disponível em:

👉 **/swagger**

Exemplo:

```
https://localhost:5001/swagger
```

---

## ✔️ Pronto!

Se quiser, posso gerar uma versão em inglês, adicionar exemplos de endpoints, ou explicar como funciona cada entidade.
