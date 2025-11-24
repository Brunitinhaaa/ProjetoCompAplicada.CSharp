# ProjetoCompAplicada.CSharp

Esta aplicação foi criada como uma API paralela de consulta e apoio, conectada ao mesmo banco de dados utilizado pelo backend Java.
Seu foco está em endpoints de consulta (GET), com:

- Paginação
- Filtros dinâmicos
- Organização de dados
- Health check
- Estatísticas agregadas
- Boas práticas de arquitetura e validação (FluentValidation)

A ideia é demonstrar o uso de .NET como alternativa tecnológica no mesmo domínio do sistema, sem substituir nem replicar o backend original em Java.

---

## Tecnologias

- **Linguagem:** C# (.NET 9)  
- **ORM:** Entity Framework Core (Pomelo MySQL)  
- **Banco de dados:** MySQL  
- **Documentação:** Swagger  
- **FluentValidation**
- **Microsoft Logging**
- **Gerenciamento de ambiente:** `.env` e `appsettings.json`

## Para rodar a API usando PowerShell 

- dotnet build
- $env:ASPNETCORE_ENVIRONMENT = "Development"
- dotnet run
- Após iniciar, acesse: http://localhost:5257/swagger/index.html

## Licença

Projeto desenvolvido para fins acadêmicos, sem fins comerciais.

##  Health

Endpoint responsável por verificar rapidamente se a API está no ar e se o banco de dados está acessível.  
É útil para monitoramento, automação de deploy e testes de infraestrutura.

### Endpoint

| Method | Route        | Descrição                                                                  |
|--------|--------------|-----------------------------------------------------------------------------|
| GET    | `/api/Health`| Verifica a disponibilidade da API e testa a conexão com o banco de dados. |

**Exemplo de resposta bem-sucedida:**

{
  "success": true,
  "data": {
    "status": "OK",
    "database": "OK"
  },
  "message": null,
  "errors": []
}

## Public Services

Conjunto de endpoints responsáveis por **listar**, **detalhar**, **filtrar** e **sumarizar** os serviços cadastrados no sistema.  
Todos seguem o padrão de resposta `ResponseBase<T>`, contendo:

- `success` — indica se a operação foi realizada com sucesso  
- `data` — dados retornados pela consulta  
- `message` — mensagem informativa opcional  
- `errors` — lista de erros (caso existam)

Esses endpoints fornecem dados estruturados e otimizados para aplicações front-end, integrações externas e ferramentas de análise.

### Endpoints

| Method | Route                                   | Description                                                    |
|--------|-----------------------------------------|----------------------------------------------------------------|
| GET    | `/api/public/Servicos`                  | Returns a paginated and filtered list of services.             |
| GET    | `/api/public/Servicos/{id}`             | Returns detailed information about a single service.           |
| GET    | `/api/public/Servicos/filter-options`   | Returns distinct categories, cities and states available.      |
| GET    | `/api/public/Servicos/summary`          | Returns aggregated statistics about active services.           |

**Exemplo de resposta bem-sucedida:**

{
  "success": true,
  "data": {
    "page": 0,
    "size": 10,
    "total": 1,
    "data": [
      {
        "id": 5,
        "nome": "Serviço Elétrico Básico",
        "categoria": "Elétrica",
        "preco": 160,
        "cidade": "São Paulo",
        "uf": "SP",
        "imagemUrl": "https://cdn.exemplo.com/servicos/5/eletrica-1.png"
      }
    ]
  },
  "message": null,
  "errors": []
}
