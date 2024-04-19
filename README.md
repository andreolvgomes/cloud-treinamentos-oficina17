# Oficina de Projetos Nº 17

<p align="center">
  <a href="#Problema">O problema</a>&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;
  <a href="#Objetivo">O Objetivo</a>&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;
  <a href="#DescricaoTecnica">Descricao tecnica</a>&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;
  <a href="#ItensASeremAvaliados">Itens a serem avaliados</a>&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;
  <a href="#memo-licenca">Licenca</a>
</p>


## 🚀 O PROBLEMA

<p align="justify">TA Upper Trends é uma startup que recebeu um aporte para escalar seu negócio e conforme o contrato com investidores, precisa alcançar a marca de 2 milhões de usuários em 1 ano com uma estimativa de 1 milhão de acessos por dia e as campanhas de marketing começarão em 2 semanas.</p>
<p align="justify">Uma das principais exigências dos investidores é que a aplicação seja rápida e não tenha quedas quando começarem os primeiros acessos. </p>
<p align="justify">Em testes feitos pela equipe técnica, a aplicação apresentou lentidão e analisando o cenário atual constatou-se que a arquitetura não é tolerante a falhas. O seu time de consultoria recebeu uma solicitação de proposta para execução do projeto.</p>

![plot](./diagrams/arquitetura_atual.jpeg)


## O OBJETIVO
<p align="justify">O objetivo é que a aplicação tenha alta disponibilidade e escalabilidade com o menor custo possível, cumprindo os pilares do Well Architect framework da AWS.</p>

## DESCRIÇÃO TÉCNICA
<p align="justify">- Atualmente essa aplicação já está na AWS em uma instância EC2</p> 
<p align="justify">- Aplicação desenvolvida em Dotnet core 7
Banco de dados SQLServer</p>
<p align="justify">- Deve ser executados scripts para popular o Banco </p>
<p align="justify">- Scripts estão na plataforma de Ensino dentro do Projeto /Scripts do projeto </p>
<p align="justify">- A aplicação já está usando como armazenamento de objetos o S3 da AWS. </p>
<p align="justify">- Arquivos para o storage já estão na estrutura de pastas que deve ficar e estão disponíveis na pasta /imagens no projeto </p>
<p align="justify">- Arquivo de configuração da aplicação para conexão com o Banco de dados e storage esta em Source/postcard/appsettings.json</p>

## 📝 ITENS A SEREM AVALIADOS
- Apresentação - visão de negócio
- Apresentação - detalhes técnicos
- Arquitetura
- Painel de monitoramento com Notificação (discord, telegram, whatsapp,email,SMS)
- Documentação
- Testes
- Participação dos integrantes do grupo
- Demonstração
- Deploy


Happy project 😊

##  🔗 LICENCA

 <p align="justify">This project is under an MIT License. See more details in [LICENSE](LICENSE) for more information.</p>

---


