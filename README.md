# Integrantes: <br>
Alissa Silva Cezero - RM552535 <br> Melissa Barbosa de Souza - RM552535 <br> Nicolas Paiffer do Carmo - RM554145

# ClinicaAPI

Projeto desenvolvido para a disciplina de Desenvolvimento de API com ASP.NET Core, integrando funcionalidades de IA com ML.NET.

## 📚 Descrição

O **ClinicaAPI** é uma aplicação RESTful desenvolvida em **.NET** para gerenciar informações de clínicas odontológicas, incluindo dados de dentistas, pacientes, atendimentos e outros. O objetivo do projeto é centralizar a gestão das informações da clínica, permitindo que dentistas possam registrar e acessar dados sobre pacientes e atendimentos de forma eficiente. Agora com integração ao ML.NET.

## ⚙️ Tecnologias Utilizadas

- ASP.NET Core 8
- Entity Framework Core (Oracle)
- ML.NET
- xUnit (para testes)
- FluentAssertions
- Swagger
- Visual Studio / .NET CLI

## 💡 Funcionalidades

- CRUD de clínicas, atendimentos e usuários.
- Integração com ViaCEP para busca de endereços.
- Integração com API de autenticação externa.
- Treinamento e uso de modelo de **Análise de Sentimento** com ML.NET.
- Testes automatizados com xUnit.

## 📈 Funcionalidade de Análise de Sentimento

A funcionalidade de IA foi implementada usando **ML.NET**, com um modelo treinado para classificar frases como positivas ou negativas. O endpoint disponível é:

```
POST /api/sentiment/analyze
{
  "text": "Eu estou muito feliz com o atendimento!"
}
```

Resposta:
```json
{
  "sentimento": "Positivo"
}
```

## 🧪 Testes Automatizados

Os testes estão localizados no projeto `ClinicaAPI.Tests`, incluindo testes de integração e de controlador da API de sentimento. Exemplo de teste:

```csharp
[Theory]
[InlineData("Isso foi horrível", "Negativo")]
public async Task AnalyzeSentiment_ReturnsExpectedSentiment(string input, string expected)
```

## ⚠️ Erros Pendentes

Apesar do progresso com a aplicação, alguns erros persistem na execução dos testes:

- Erro de carregamento do modelo ML quando executado pelo projeto de testes.
- Testes de integração falhando com erro 500 (Internal Server Error).
- Falta de diretório `ML/` ao rodar em contexto de testes (é criado apenas no projeto principal).
- Dificuldade em realizar testes de integração por causa do acesso ao banco Oracle.

### Motivo

**Infelizmente, o suporte em sala de aula foi limitado por conta de faltas do professor**, o que comprometeu o acompanhamento completo do nosso grupo para este projeto. Muitos dos problemas foram resolvidos com pesquisa e tentativa e erro.

## ▶️ Como Executar

1. Certifique-se de ter o .NET 8 SDK instalado.
2. Configure sua connection string Oracle no `appsettings.json`.
3. Execute os seguintes comandos:

```bash
dotnet build
dotnet run --project ClinicaAPI
```

Acesse a API em: [http://localhost:5194/swagger](http://localhost:5194/swagger)
