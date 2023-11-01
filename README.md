# Loja139

## Requisitos
- .Net 7.0
- Visual Studio Code

## Configuração do Projeto
1. Instalar as seguintes extensões no VSCode: 
    - C#
    - NuGet Package Manager
    - .Net Core Test Explorer

2. Criar um diretório para o projeto.
3. Abrir o diretório com o VSCode.
4. Utilizar o seguinte comando para configurar o projeto NUnit:
`dotnet new nunit`

5. Utilizar o seguinte comando para verificar se há algum erro de compilação: 
`dotnet build`

6. Configurar a extensão .Net Core Test Explorer, indo em Extension Settings -> Test Project Path. Copiar o nome completo do seu arquivo .csproj e colar no campo de configuração

7. Adicionar as seguintes bibliotecas:
  
    1. Via extensão do NuGet (`Ctrl + Shift + P` -> "NuGet Package Manager: Add Package"):
        - WebDriverManager -> 2.17.1
        - Selenium.WebDriver -> 4.12.4
        - SpecFlow.NUnit -> 3.9.74
        - SpecFlow.Plus.LivingDocPlugin -> 3.9.57

    2. Ou via CLI:
 
        `dotnet add package WebDriverManager --version 2.17.1`

        `dotnet add package Selenium.WebDriver --version 4.12.4`

        `dotnet add package SpecFlow.NUnit --version 3.9.74 `

        `dotnet add package SpecFlow.Plus.LivingDocPlugin --version 3.9.57 `

* Para executar a feature utilizando o filtro da tag:
`dotnet test --filter TestCategory=simples`

* Para instalar o LivingDoc.CLI localmente, execute ambos os comandos:
 
    `dotnet new tool-manifest`

    `dotnet tool install --local SpecFlow.Plus.LivingDoc.CLI --version 3.9.57 `

* Para gerar o relatório de execução dos testes, utilize o seguinte comando ajustando os apontamentos:
`dotnet livingdoc feature-folder C:\testspace\Loja139 -t C:\testspace\Loja139\bin\Debug\net7.0\TestExecution.json`
