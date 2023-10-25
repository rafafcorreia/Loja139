# Loja139

* Instalação do SpecFlow:
`dotnet add package SpecFlow.NUnit --version 3.9.74 `
`dotnet add package SpecFlow.Plus.LivingDocPlugin --version 3.9.57 `

* Para instalar o LivingDoc.CLI localmente, execute ambos os comandos:
`dotnet new tool-manifest`
`dotnet tool install --local SpecFlow.Plus.LivingDoc.CLI --version 3.9.57 `

* Para executar a feature utilizando o filtro da tag:
`dotnet test --filter TestCategory=simples`

* Para gerar o relatório de execução dos testes, utilize o seguinte comando ajustando os apontamentos:
`dotnet livingdoc feature-folder C:\testspace\Loja139 -t C:\testspace\Loja139\bin\Debug\net7.0\TestExecution.json`