<h1 align="center"> Design Pattern Singleton </h1>

<h4> Aluno: Maycon Siqueira <br>
Curso: Desenvolvimento de Sistemas <br>
Instrutor: Fred Aguiar </h4>

<hr>

## 1. Introdução

A engenharia de software moderna busca criar sistemas fortes e fáceis de manter. Para isso, os desenvolvedores utilizam <b> Padrões de Projeto (Design Patterns) </b>, que são soluções comprovadas para problemas que aparecem com frequência no dia a dia. <br>
Essa prática se tornou um padrão na indústria em 1994, graças ao livro "Design Patterns: Elements of Reusable Object-Oriented Software", escrito por quatro autores (Erich Gamma, Richard Helm, Ralph Johnson e John Vlissides) conhecidos como Gang of Four (GoF). <br> <br> 
Eles catalogaram 23 padrões e os dividiram em três grandes grupos:

1. <b> Criacionais: </b> Focam em como os objetos são criados.
2. <b> Estruturais: </b> Focam em como classes e objetos são montados para formar estruturas maiores.
3. <b> Comportamentais: </b> Focam na comunicação entre os objetos.

### 1.1. O que são Padrões Criacionais (Creational Patterns)? 

O foco desses padrões é simplificar a instanciação (a criação) de objetos. Em vez de o sistema criar objetos de forma direta e rígida, os padrões criacionais funcionam como uma "caixa preta":

- <b> O que eles fazem: </b> Eles escondem os detalhes de como um objeto é criado e qual classe específica está sendo usada.
- <b> A vantagem: </b> Isso torna o sistema mais flexível. Se você precisar mudar a forma como um objeto é montado ou trocar uma peça do sistema, o restante do código não precisa ser alterado, pois ele não conhece os detalhes internos da criação.

### 1.2. O que é uma instância?

É um objeto real e concreto que foi criado na memória do computador a partir de uma Classe. <br>

1. A Classe define o "tipo" (ex: Carro).
2. A Instância é o objeto específico (ex: o meu carro azul, placa ABC-1234).

Por que isso é importante? <br>
Uma única Classe pode gerar infinitas instâncias, e cada uma delas pode ter características diferentes, mesmo seguindo o mesmo molde:

- Classe: Cachorro
- Instância 1: Nome: "Eros", Raça: "Vira-lata".
- Instância 2: Nome: "Bela Princesa", Raça: "Pitbull".

## 2. Definição do Padrão

<p align="center"> 
  <img src="" height="500" width="700"/> 
</p>

O <b>Singleton</b> (também conhecido como <i>Carta Única</i>) é um padrão de projeto criacional que garante que uma classe tenha apenas uma instância em todo o ciclo de vida da aplicação, fornecendo um ponto global de acesso a essa instância. <br>
Esse padrão é útil em situações onde é necessário ter exatamente um objeto de uma classe para coordenar ações em todo o sistema.

## 3. Problema que resolve
## 4. Estrutura

<p align="center"> 
  <img src=""/> 
</p>

## 5. Participantes
## 6. Justificativa da Escolha
## 7. Explicação da implementação no projeto
## 8. Análise Crítica
## 9. Comparação com abordagens sem o padrão
## 10. Vantagens
## 11. Desvantagens
## 12. Exemplos reais de uso no mercado
## 13. Refêrencias

<hr>
