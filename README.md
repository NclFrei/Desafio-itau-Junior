#  Desafio Itaú - API REST em C# com ASP.NET Core

##  Sobre o Projeto
Este projeto foi desenvolvido como parte do **Desafio de Programação do Itaú **. A proposta era criar uma **API REST** que recebe transações financeiras e gera estatísticas em tempo real, **sem utilizar banco de dados**, armazenando tudo em memória.

A implementação original foi sugerida em **Java**, mas desenvolvi a solução em **C# com ASP.NET Core**, pois o intuito principal era treinar e melhorar no C#.


## Tecnologias Utilizadas
- ✅ **C# com ASP.NET Core** – Para criação da API REST.
- ✅ **LINQ** – Para processamento eficiente das estatísticas.
- ✅ **Swagger** – Para documentação e testes interativos.

##  Como Funciona?

A API possui **três endpoints principais**:

### 1️⃣ Criar uma Transação
- **`POST /transacao`**  
- Adiciona uma nova transação financeira.
 **Exemplo de Requisição**
```json
{
    "valor": 123.45,
    "dataHora": "2025-02-06T12:34:56.789-03:00"
}
```
 **Respostas Possíveis**

- 201 Created → Transação aceita.
- 422 Unprocessable Entity → Dados inválidos (valor negativo ou data no futuro).
- 400 Bad Request → JSON mal formatado.
  
---

### 2️⃣ Obter Estatísticas das Últimas Transações
- **`GET /estatistica`**  
- Retorna estatísticas das transações realizadas nos últimos XX segundos.
- Exemplo de Requisição
 ```dash
  GET /estatistica?tempo=120
```
 **Exemplo de Resposta**
```json
{
    "count": 10,
    "sum": 1234.56,
    "avg": 123.456,
    "min": 12.34,
    "max": 123.56
}
```
 **Possíveis Respostas**

- 200 OK → Retorna os valores calculados.
- 400 Bad Request → Se o parâmetro tempo estiver ausente ou for inválido.

---

### 3️⃣ Limpar Transações
- **`DELETE /transacao`**  
- Remove todas as transações armazenadas.
** Respostas**

- 200 OK → Todas as transações foram apagadas.
