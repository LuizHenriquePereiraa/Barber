# README — BarberTech 💈

## Sistema Web para Gerenciamento de Barbearia

O BarberTech é um sistema desenvolvido em ASP.NET Core MVC para gerenciamento de barbearias, permitindo controle de agendamentos, dashboard administrativo e gerenciamento de serviços.

---

# Tecnologias Utilizadas

- ASP.NET Core MVC
- C#
- Entity Framework Core
- SQL Server
- Bootstrap
- Razor Pages

---

# Funcionalidades

✅ Login administrativo  
✅ Cadastro de agendamentos  
✅ Edição de agendamentos  
✅ Exclusão de agendamentos  
✅ Dashboard administrativo  
✅ Integração com SQL Server  
✅ Listagem de próximos atendimentos  
✅ Controle de serviços:

- Corte
- Barba
- Sobrancelha

---

# Estrutura do Projeto

```bash
BarberTech/
│
├── Controllers/
│   ├── AgendamentoController.cs
│   ├── DashboardController.cs
│   ├── LoginController.cs
│
├── Models/
│   ├── Agendamento.cs
│   ├── Cliente.cs
│   ├── Servico.cs
│   ├── Usuario.cs
│
├── Data/
│   └── AppDbContext.cs
│
├── Views/
│   ├── Agendamento/
│   ├── Dashboard/
│   ├── Login/
│
├── wwwroot/
│
├── Program.cs
├── appsettings.json
└── Barber.csproj
```

---

# Configuração do Banco de Dados

## 1. Instalar SQL Server

Baixe:

- SQL Server Developer
- SQL Server Management Studio (SSMS)

---

## 2. Configurar Connection String

Arquivo:

```json
appsettings.json
```

Exemplo:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=LUIZ-PC\\Pichau;Database=BarberTechDB;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}
```

---

# Executando o Projeto

## 1. Restaurar Pacotes

No terminal do Visual Studio:

```bash
dotnet restore
```

---

## 2. Criar Migration

```bash
Add-Migration InitialCreate
```

---

## 3. Atualizar Banco

```bash
Update-Database
```

---

## 4. Executar Projeto

```bash
dotnet run
```

Ou clique em:

```bash
▶ IIS Express
```

---

# Login do Sistema

Usuário padrão:

```txt
admin
```

Senha:

```txt
123
```

---

# Dashboard

O dashboard apresenta:

- Total de agendamentos
- Total de cortes
- Total de barbas
- Total de sobrancelhas
- Lista de próximos clientes agendados

---

# Exemplo de Controller

## DashboardController.cs

```csharp
using Microsoft.AspNetCore.Mvc;
using BarberTech.Data;

namespace BarberTech.Controllers
{
    public class DashboardController : Controller
    {
        private readonly AppDbContext _context;

        public DashboardController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.TotalAgendamentos =
                _context.Agendamentos.Count();

            ViewBag.TotalCortes =
                _context.Agendamentos
                .Count(a => a.Servico == "Corte");

            ViewBag.TotalBarbas =
                _context.Agendamentos
                .Count(a => a.Servico == "Barba");

            ViewBag.TotalSobrancelha =
                _context.Agendamentos
                .Count(a => a.Servico == "Sobrancelha");

            ViewBag.ProximosAgendamentos =
                _context.Agendamentos
                .OrderBy(a => a.DataHora)
                .ToList();

            return View();
        }
    }
}
```

---

# Melhorias Futuras

- Sistema online hospedado
- Integração com WhatsApp
- Autenticação segura
- Área do cliente
- Notificações automáticas
- Pagamento online

---

# Autor

## Luiz Henrique Pereira de Araujo

Projeto acadêmico desenvolvido para o curso de Análise e Desenvolvimento de Sistemas.

---

# Licença

Projeto acadêmico para fins educacionais.
