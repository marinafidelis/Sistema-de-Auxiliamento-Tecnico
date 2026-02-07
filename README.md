# SISTEMA DE AUXILIAMENTO TECNICO
 
Este sistema tem como objetivo gerenciar chamados de suporte técnico.
Ele permite o cadastro de clientes e técnicos, a abertura de chamados pelos clientes e o atendimento desses chamados pelos técnicos, incluindo atribuição, acompanhamento de status e encerramento.

# Funcionalidades principais:

•Cadastro de clientes e técnicos

•Abertura de chamados com descrição, nível e categoria

•Atribuição de técnico a um chamado

•Atualização do status do chamado (Aberto, Em andamento, Encerrado)

•Registro de histórico de atendimentos

•Listagem de chamados por status ou por técnico

# Diagrama de Classes UML

Obs: O diagrama foi criado antes da implementação do código, conforme solicitado.

🔗 [Acessar Diagrama de Classes UML (Canva)](https://www.canva.com/design/DAG_m1uBbhA/DwkLOjneC6CyhYnfqOJwsw/view)


# Classes principais:

•Usuario (classe abstrata)

•Cliente

•Tecnico

•Chamado

•Categoria

•HistoricoChamado

# Interfaces:

•IAtribuivel

•IEncerravel

# Conceitos de Orientação a Objetos Utilizados

Classe e Objeto

Encapsulamento

Herança

Polimorfismo

Abstração

Interfaces

Classes abstratas

Construtores

Métodos sobrescritos (override)

# Aplicação dos Princípios SOLID

• S — Single Responsibility Principle (Responsabilidade Única)

Cada classe possui uma responsabilidade bem definida.
Exemplo:

Chamado é responsável apenas por representar os dados e comportamentos do chamado.

ChamadoService concentra as regras de negócio relacionadas aos chamados (abrir, listar, atribuir, encerrar).

• O — Open/Closed Principle (Aberto para extensão, fechado para modificação)

O sistema permite a criação de novos tipos de usuários ou categorias sem a necessidade de alterar classes existentes, utilizando herança e abstração.

• L — Liskov Substitution Principle (Substituição de Liskov)

As classes Cliente e Tecnico herdam de Usuario e podem substituí-la sem quebrar o funcionamento do sistema, respeitando o contrato da classe base.

• I — Interface Segregation Principle (Segregação de Interfaces)

Foram criadas interfaces pequenas e específicas:

- IAtribuivel para atribuição de técnico

- IEncerravel para encerramento de chamados
Assim, as classes implementam apenas os comportamentos que realmente utilizam.

• D — Dependency Inversion Principle (Inversão de Dependência)

As regras de negócio foram concentradas em serviços, e o sistema foi estruturado para depender de abstrações (interfaces), reduzindo o acoplamento entre as classes.

# Tecnologias Utilizadas

• Linguagem: C#

• Plataforma: .NET

• Controle de versão: Git

• Repositório: GitHub

# Aluno (a)s:

•Marina Fidelis
•Karollayne Correia
