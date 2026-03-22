<h1 align="center"> Design Pattern Singleton </h1>

<p align="center"> 
  <img src="https://github.com/MaysCroft/Design_Pattern_Singleton/blob/master/Imagens/Singleton%20Logo%20Geo.png"/> 
</p>

<h4> Aluno: Maycon Siqueira <br>
Curso: Desenvolvimento de Sistemas <br>
Instrutor: Fred Aguiar <br>
Unidade: SENAI CFP Afonso Greco - Nova Lima MG </h4>

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
2. A Instância é o objeto específico (ex: O meu Uno Vermelho, Placa ABC-1234).

Por que isso é importante? <br>
Uma única Classe pode gerar infinitas instâncias, e cada uma delas pode ter características diferentes, mesmo seguindo o mesmo molde:

- Classe: Cachorro
- Instância 1: Nome: "Eros", Raça: "Vira-lata".
- Instância 2: Nome: "Bela Princesa", Raça: "Pitbull".

<hr>

## 2. Definição do Padrão

<p align="center"> 
  <img src="https://github.com/MaysCroft/Design_Pattern_Singleton/blob/master/Imagens/Singleton.png" height="500" width="700"/> 
</p>

O <b>Singleton</b> (também conhecido como <i>Carta Única</i>) é um padrão de projeto criacional que garante que uma classe tenha apenas uma instância em todo o ciclo de vida da aplicação, fornecendo um ponto global de acesso a essa instância. <br>
Esse padrão é útil em situações onde é necessário ter exatamente um objeto de uma classe para coordenar ações em todo o sistema.

<hr>

## 3. Problema que resolve

Diferente de classes comuns, o Singleton assume um papel duplo: 

1. Ele executa suas tarefas (como salvar um log ou conectar ao banco),
2. E, ao mesmo tempo, gerencia seu próprio ciclo de vida.

Ele decide quando nascer e garante que ninguém mais crie "clones" dele, evitando que o sistema fique sobrecarregado com objetos desnecessários.

### 3.1. Controle de Instanciação e Recursos

Alguns recursos do computador são caros ou limitados. O Singleton impede o caos em dois cenários críticos:

- <b>Conexões de Banco de Dados:</b> Criar uma conexão toda vez que um usuário clica em algo é lento e pode derrubar o servidor. O Singleton garante que todos usem a mesma conexão (ou um pool controlado).
- <b>Acesso a Arquivos (Logs):</b> Se duas partes do programa tentarem escrever no mesmo arquivo de log ao mesmo tempo, o Windows ou Linux vai travar a operação. O Singleton centraliza o acesso, garantindo que apenas um "braço" escreva por vez, evitando erros fatais.

### 3.2. Acesso Global Seguro

Antigamente, usavam-se variáveis globais, mas elas eram perigosas: qualquer parte do código podia apagá-las ou alterá-las sem querer. O Singleton oferece a mesma facilidade (você o acessa de qualquer lugar), mas com uma camada de proteção:

- <b>Encapsulamento:</b> Você pode usar as funções dele, mas não pode deletar a instância ou substituí-la por algo vazio.
- <b>Segurança:</b> A instância física fica escondida e protegida, exposta apenas por um canal de "somente leitura" controlado.

<hr>

## 4. Estrutura

Para que uma classe se torne um Singleton, ela precisa seguir estas regras:

- <b>Construtor Privado (private):</b> Ao tornar o construtor privado, você impede que qualquer outra parte do código use o comando new Singleton(). Só a própria classe pode criar a si mesma.
- <b>Classe Selada (sealed):</b> Isso evita que outras classes herdem dela. Se alguém pudesse herdar do Singleton, poderia acabar criando instâncias extras sem querer, quebrando a regra de "uma única cópia".
- <b>O "Cofre" (Campo Estático):</b> A classe guarda uma variável privada e estática (ex: _instance) que armazena a única cópia do objeto na memória enquanto o programa estiver rodando.
- <b>O Portal de Acesso (Propriedade Instance):</b> Como ninguém pode dar <i>new</i>, a classe oferece uma propriedade pública (geralmente chamada de Instance).
- <b>Lazy Initialization (Inicialização Preguiçosa):</b> A primeira vez que você pede a instância, a classe a cria. Nas vezes seguintes, ela apenas entrega a que já está pronta.

## 5. Participantes

<b>O Participante "Cliente"</b> <br>
O Cliente é qualquer parte do seu código que precise usar o Singleton (um serviço de log, uma configuração de banco de dados, etc.).
- Ele é passivo: não tenta criar o objeto.
- Ele apenas "chama" o Singleton quando precisa, usando algo como: <i>Configuracao.Instance.Salvar()</i>.
  
## 6. Justificativa da Escolha
## 7. Explicação da implementação no projeto
## 8. Análise Crítica
## 9. Comparação com abordagens sem o padrão
## 10. Vantagens
## 11. Desvantagens
## 12. Exemplos reais de uso no mercado
## 13. Refêrencias

<hr>
