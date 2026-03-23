<h1 align="center"> Design Pattern Singleton </h1>

<p align="center"> 
  <img src="https://github.com/MaysCroft/Design_Pattern_Singleton/blob/master/Imagens/Singleton%20Logo%20Geo.png"/> 
</p>

<h4> Aluno: Maycon Siqueira <br>
Curso: Desenvolvimento de Sistemas <br>
Instrutor: Fred Aguiar <br>
Unidade: SENAI CFP Afonso Greco - Nova Lima MG </h4>

---

## 1. Introdução

A engenharia de software moderna busca criar sistemas fortes e fáceis de manter. Para isso, os desenvolvedores utilizam **Padrões de Projeto (Design Patterns)**, que são soluções comprovadas para problemas que aparecem com frequência no dia a dia. <br>
Essa prática se tornou um padrão na indústria em 1994, graças ao livro "Design Patterns: Elements of Reusable Object-Oriented Software", escrito por quatro autores (Erich Gamma, Richard Helm, Ralph Johnson e John Vlissides) conhecidos como Gang of Four (GoF). <br> <br> 
Eles catalogaram 23 padrões e os dividiram em três grandes grupos:

1. **Criacionais:** Focam em como os objetos são criados.
2. **Estruturais:** Focam em como classes e objetos são montados para formar estruturas maiores.
3. **Comportamentais:** Focam na comunicação entre os objetos.

### 1.1. O que são Padrões Criacionais (Creational Patterns)? 

O foco desses padrões é simplificar a instanciação (a criação) de objetos. Em vez de o sistema criar objetos de forma direta e rígida, os padrões criacionais funcionam como uma "caixa preta":

- **O que eles fazem:** Eles escondem os detalhes de como um objeto é criado e qual classe específica está sendo usada.
- **A vantagem:** Isso torna o sistema mais flexível. Se você precisar mudar a forma como um objeto é montado ou trocar uma peça do sistema, o restante do código não precisa ser alterado, pois ele não conhece os detalhes internos da criação.

### 1.2. O que é uma instância?

É um objeto real e concreto que foi criado na memória do computador a partir de uma Classe. <br>

1. A Classe define o "tipo" (ex: Carro).
2. A Instância é o objeto específico (ex: Uno Vermelho, Placa ABC-1234).

Por que isso é importante? <br>
Uma única Classe pode gerar infinitas instâncias, e cada uma delas pode ter características diferentes, mesmo seguindo o mesmo molde:

- Classe: Cachorro
- Instância 1: Nome: "Eros", Raça: "Vira-lata".
- Instância 2: Nome: "Bela Princesa", Raça: "Pitbull".

---

## 2. Definição do Padrão

<p align="center"> 
  <img src="https://github.com/MaysCroft/Design_Pattern_Singleton/blob/master/Imagens/Singleton%20Ningguang.png" height="700" width="900"/> 
</p>

O **Singleton** (também conhecido como *Carta Única*) é um padrão de projeto criacional que garante que uma classe tenha apenas uma instância em todo o ciclo de vida da aplicação, fornecendo um ponto global de acesso a essa instância. <br>
Esse padrão é útil em situações onde é necessário ter exatamente um objeto de uma classe para coordenar ações em todo o sistema.

---

## 3. Problema que resolve

Diferente de classes comuns, o Singleton assume um papel duplo: 

1. Ele executa suas tarefas (como salvar um log ou conectar ao banco),
2. E, ao mesmo tempo, gerencia seu próprio ciclo de vida.

Ele decide quando nascer e garante que ninguém mais crie "clones" dele, evitando que o sistema fique sobrecarregado com objetos desnecessários.

### 3.1. Controle de Instanciação e Recursos

Alguns recursos do computador são caros ou limitados. O Singleton impede o caos em dois cenários críticos:

- **Conexões de Banco de Dados:** Criar uma conexão toda vez que um usuário clica em algo é lento e pode derrubar o servidor. O Singleton garante que todos usem a mesma conexão (ou um pool controlado).
- **Acesso a Arquivos (Logs):** Se duas partes do programa tentarem escrever no mesmo arquivo de log ao mesmo tempo, o Windows ou Linux vai travar a operação. O Singleton centraliza o acesso, garantindo que apenas um "braço" escreva por vez, evitando erros fatais.

### 3.2. Acesso Global Seguro

Antigamente, usavam-se variáveis globais, mas elas eram perigosas: qualquer parte do código podia apagá-las ou alterá-las sem querer. O Singleton oferece a mesma facilidade (você o acessa de qualquer lugar), mas com uma camada de proteção:

- **Encapsulamento:** Você pode usar as funções dele, mas não pode deletar a instância ou substituí-la por algo vazio.
- **Segurança:** A instância física fica escondida e protegida, exposta apenas por um canal de "somente leitura" controlado.

---

## 4. Estrutura

Para que uma classe se torne um Singleton, ela precisa seguir estas regras:

- **Construtor Privado (private):** Ao tornar o construtor privado, você impede que qualquer outra parte do código use o comando new Singleton(). Só a própria classe pode criar a si mesma.
- **Classe Selada (sealed):** Isso evita que outras classes herdem dela. Se alguém pudesse herdar do Singleton, poderia acabar criando instâncias extras sem querer, quebrando a regra de "uma única cópia".
- **O "Cofre" (Campo Estático):** A classe guarda uma variável privada e estática (ex: _instance) que armazena a única cópia do objeto na memória enquanto o programa estiver rodando.
- **O Portal de Acesso (Propriedade Instance):** Como ninguém pode dar *new*, a classe oferece uma propriedade pública (geralmente chamada de Instance).
- **Lazy Initialization (Inicialização Preguiçosa):** A primeira vez que você pede a instância, a classe a cria. Nas vezes seguintes, ela apenas entrega a que já está pronta.

---

## 5. Participantes

**O Participante "Cliente"** <br>
O Cliente é qualquer parte do seu código que precise usar o Singleton (um serviço de log, uma configuração de banco de dados, etc.).
- Ele é passivo: não tenta criar o objeto.
- Ele apenas "chama" o Singleton quando precisa, usando algo como: *Configuracao.Instance.Salvar()*.

---

## 6. Justificativa da Escolha

Em aplicações modernas, o WPF utiliza uma janela principal (*MainWindow*) que troca dinamicamente seu conteúdo (*View*) conforme a *ViewModel* atual muda. Para isso, utiliza-se um *NavigationStore* (Repositório de Navegação).

### 6.1. Singleton como Sincronização

A aplicação do Singleton no *NavigationStore* resolve o problema de dessincronização de instâncias:

- **O Problema:** Se diferentes partes do sistema criarem novas instâncias do repositório de navegação, o *Data Binding* (vinculação de dados) da Janela Principal pode "quebrar", pois ela estaria ouvindo um objeto, enquanto o comando de navegação altera outro.
- **A Solução:** O Singleton garante uma única instância na memória. Assim, quando qualquer botão altera a *CurrentViewModel*, a *MainWindow* reage instantaneamente, pois ambas referenciam o mesmo objeto.

### 6.2. Gestão de Serviços Globais (Cross-cutting Concerns)

O padrão também é aplicado em serviços que precisam ser acessados por todo o software sem a necessidade de passar referências complexas via construtores:

- **SessionManager:** Centraliza os dados do usuário logado (tokens e perfis) de forma protegida.
- **Logging:** Centraliza a escrita de logs no sistema de arquivos, evitando conflitos de acesso simultâneo (*file locking*) que poderiam travar a aplicação.

**OBS:**
- **File Locking:** Mecanismo que impede que múltiplos usuários ou processos editem um arquivo simultaneamente, garantindo a integridade dos dados e evitando conflitos de versão

---

## 7. Explicação da implementação no projeto

---

## 8. Análise Crítica

A aplicação do padrão Singleton deve ser uma decisão consciente e estratégica, e não um hábito automático do desenvolvedor. <br>
Os pontos principais são:

- **Ponderação de Trade-offs:** O papel do desenvolvedor não é apenas aplicar padrões, mas avaliar se os benefícios de uma solução superam seus custos técnicos e operacionais.
- **Contra a "Programação Orientada a Padrões":** Critica-se a tendência de implementar padrões apenas por formalidade sintática, ignorando o contexto e a real necessidade do projeto.
- **Foco na Manutenibilidade:** O código deve ser escrito pensando na facilidade de manutenção futura. Um Singleton mal aplicado pode se tornar um obstáculo para a evolução do sistema, independentemente de quão "correta" pareça sua implementação inicial.

---

## 9. Comparação com abordagens sem o padrão

A escolha entre essas estruturas não é apenas estética, mas impacta diretamente a manutenção e a performance do software:

- **Classes Estáticas:** São ideais para funções utilitárias sem estado (como cálculos matemáticos). Contudo, são "engessadas": não aceitam herança ou interfaces, dificultam testes unitários e pesam no carregamento inicial da aplicação.
- **Padrão Singleton:** Uma evolução sobre as estáticas. Permite o uso de interfaces e o carregamento sob demanda (*Lazy Loading*), o que economiza memória. No entanto, ainda sofre com o acoplamento forte e a "dependência oculta", dificultando rastrear quem usa o quê.
- **Injeção de Dependência (DI):** É um padrão de projeto que reduz o acoplamento entre classes, transferindo a responsabilidade de criar dependências para um componente externo (*container*), em vez de a própria classe instanciá-las, facilitando a manutenção, reutilização de código e testes unitários.

|Aspecto       |Classe Estática    |Padrão Singleton             |Injeção de Dependência (DI)      |
|--------------|-------------------|-----------------------------|---------------------------------|
|Polimorfismo  |Não permite        |Permite (Interfaces/Herança) |Totalmente baseado em Interfaces |
|Carregamento  |Rígido (Framework) |Flexível (Lazy Loading)      |Gerenciado pelo Container (IoC)  |
|Acoplamento   |Altíssimo (Rígido) |Alto (Dependência oculta)    |Baixo (Loose Coupling)           |
|Testabilidade |Muito Difícil      |Complexa/Instável            |Excelente (Uso de Mocks)         |

Embora o Singleton (especialmente *System.Lazy<-T->*) ainda tenha utilidade em cenários específicos ou sistemas legados, a Injeção de Dependência é a escolha ideal na arquitetura atual de .NET.

Ela resolve o problema da "dependência oculta", transformando o que seria um acesso global opaco em uma necessidade clara e transparente no construtor das classes, promovendo um código mais modular, limpo e testável.

**OBS:**
- **Depêndencia Oculta:**  É quando um componente depende de recursos externos (classes, serviços ou variáveis globais) não explicitos na sua interface ou construtor. Elas dificultam a manutenção e testabilidade, pois o código funciona de forma não óbvia, exigindo análise interna para entender o acoplamento.

---

## 10. Vantagens

- **Eficiência de Recursos:** Evita a criação e destruição constante de instâncias, mantendo a ocupação da memória previsível.
- **Performance Instantânea:** Maximiza o tempo de resposta após a primeira inicialização, garantindo fluidez em fluxos de alta frequência.
- **Inicialização Postergada (Lazy Loading):** Através de *Lazy<-T->*, evita o "choque térmico" no arranque do software (como o *cold start* em interfaces WPF), adiando operações pesadas (como conexões SQL) para o momento exato do uso.
- **Acessibilidade Global Simplificada:** Oferece um ponto de acesso direto em árvores complexas de UI, evitando a necessidade de "comilões de construtores" (injeção manual excessiva de componentes pesados em cada camada).

---

## 11. Desvantagens

- **Insegurança:** A instância única expõe o encapsulamento a modificações incontroláveis. Em ambientes *multithread* (multi-tarefas), isso pode gerar erros "fantasmas" se não houver sincronização rigorosa.
- **Falta de Transparência:** Como o Singleton é chamado diretamente no corpo dos métodos (ex: *Logger.Instance.Execute()*), ele não aparece no construtor da classe. Impedindo o desenvolvedor de identificar as necessidades da classe em uma API pública.
- **Código "Espaguete" Frágil:** A interdependência oculta dificulta a manutenção a longo prazo, transformando o projeto em um campo minado onde mudanças em uma ponta quebram funcionalidades.
- **Dificuldade em Testes Unitários:** O Singleton retém estado entre os testes no ambiente de execução. Isso causa os chamados *Flaky Tests* (testes que falham aleatoriamente), pois um teste pode "envenenar" o resultado do próximo, exigindo recursos técnicos (como *Reflection*) para resetar a instância.

---

## 12. Exemplos reais de uso no mercado

---

## 13. Refêrencias Bibliográficas

WANG, Ligang et al. Report of Design Patterns. <br>
Disponível em: <https://ecs.syr.edu/faculty/fawcett/handouts/cse776/Lecture20/References/Design_patterns_Report.pdf>. <br>
Acesso em: 21 mar. 2026.

Implementing the singleton pattern in C#. <br>
Disponível em: <https://csharpindepth.com/articles/singleton>. <br>
Acesso em: 21 mar. 2026.

KURMI, Vivek. Singleton Design Pattern - Step by step Guide. <br>
Disponível em: <https://dev.to/kurmivivek295/singleton-design-pattern-step-by-step-guide-2bbb>. <br>
Acesso em: 21 mar. 2026.

The Singleton pattern in C# today is not your dad’s one! <br>
Disponível em: <https://blog.postsharp.net/singleton-pattern>. <br>
Acesso em: 21 mar. 2026.

What are the real world applications of the singleton pattern? <br>
Disponível em: <https://stackoverflow.com/questions/733842/what-are-the-real-world-applications-of-the-singleton-pattern>. <br>
Acesso em: 22 mar. 2026.

NARAPAREDDY, Shyamprasad. Singleton pattern: Exploring the Best Use Cases for C# Developers. <br>
Disponível em: <https://nshyamprasad.medium.com/singleton-pattern-exploring-the-best-use-cases-for-c-developers-5e949fc7e4eb>. <br>
Acesso em: 22 mar. 2026.

RAHMAN, Hasinur. Singleton Design Pattern Explained with Real-life examples. <br>
Disponível em: <https://medium.com/@hasinur1997/singleton-design-pattern-explained-with-real-life-examples-d020495c4d82>. <br>
Acesso em: 22 mar. 2026.

MÜLLER, Martin. Singleton Pattern Disadvantages and solutions. <br>
Disponível em: <https://medium.com/@cadothek/singleton-pattern-disadvantages-and-solutions-20b99d9e1986>. <br>
Acesso em: 22 mar. 2026.

JANINDUMALEESHA. The singleton pattern in .NET: A practical guide for developers. <br>
Disponível em: <https://medium.com/@janindumaleesha99/the-singleton-pattern-in-net-a-practical-guide-for-developers-140d3c3464fd>. <br>
Acesso em: 22 mar. 2026. 

BILLWAGNER. Lazy initialization. <br>
Disponível em: <https://learn.microsoft.com/en-us/dotnet/framework/performance/lazy-initialization>. <br>
Acesso em: 22 mar. 2026.

TAYAL, Dhruv. Mastering the Singleton Design Pattern with Lazy Initialization in C#. <br>
Disponível em: <https://dhruv-tayal.medium.com/mastering-the-singleton-design-pattern-with-lazy-initialization-in-c-fa8ae052f5d6>. <br>
Acesso em: 22 mar. 2026.

Why you should prefer singleton pattern over a static class? <br>
Disponível em: <https://volosoft.com/blog/Prefer-Singleton-Pattern-over-Static-Class>. <br>
Acesso em: 22 mar. 2026.

VEIGA, Leandro. Mastering C# design patterns: Practical examples of singleton, factory, and observer. <br>
Disponível em: <https://dev.to/leandroveiga/mastering-c-design-patterns-practical-examples-of-singleton-factory-and-observer-36he>. <br>
Acesso em: 22 mar. 2026.

---
