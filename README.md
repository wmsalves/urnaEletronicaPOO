### SISTEMA DE GERENCIAMENTO DE URNAS ELETRÔNICAS
- Atualmente existem diversos sistemas que promovem votação 
eletrônica como enquetes on-line, via telefone, sms cominando até 
mesmo no sistema de urnas eletrônicas de eleições gerais do nosso 
país. Tendo em vista esses tipos de sistema é papel do seu grupo 
desenvolver uma solução de votação eletrônica levando em 
consideração as regras de funcionamento das eleições no Brasil tanto 
para o poder executivo, quanto para o legislativo.

### Regras de Negócio
- O sistema deverá conter os requisitos básicos: 
Um sistema de urna eletrônica para eleições diversas, tendo como 
foco inicial, eleições para Prefeito e Vereadores, levando em 
consideração a legislação eleitoral do Brasil para eleições.
- O sistema deverá ser divido em dois módulos, eleições do executivo 
(Presidente, Governador de Estado e Prefeito Municipal) e Legislativo: 
deputados estaduais, federais e vereadores municipais.
- Na primeira “Release” o escopo engloba apenas as eleições 
municipais isto é: Eleições para Prefeito e Vereadores.

### Eleições do Executivo
- As eleições do executivo se dão pelo sistema de maioria simples, também 
conhecido como maioria relativa, onde a vitória se da pela proporção matemática 
em que o total de votos é maior que a metade do total de votos dos presentes. 
De forma básica, superioridade em número simples de votos dos presentes à 
votação.
- Caso nenhum dos candidatos consiga a maioria simples, é decidido o pleito por 
meio de Segundo Turno. Onde todos os candidatos, com exceção dos dois mais 
votados no primeiro turno, são eliminados e o pleito se dá entre os dois restantes 
mais bem votados. O candidato eleito é aquele que obtiver mais votos que o 
outro em contagem simples de votos.
- Se mesmo depois do segundo turno, persistir o empate, a eleição leva em 
consideração a idade dos candidatos, onde o mais velho deles é eleito. Isso se 
aplica para cidades que não possuem segundo turno, onde o número de eleitores 
é menor que 200 mil, no caso do Brasil

### Eleições do Legislativo
- As eleições do legislativo usa o sistema de lista aberta através da 
representação proporcional por partidos com uso do Quociente 
Eleitoral e Quociente Partidário. O sistema de lista aberta configura 
uma representação proporcional onde os eleitores votam em partidos 
políticos na ordem dos candidatos em listas definidas pelos partidos. 
O quociente eleitoral define a quantidade de cadeiras um 
determinado partido ou coligação terá direito no pleito:
- “Determina-se o quociente eleitoral dividindo-se o número de votos 
válidos apurados pelo de lugares a preencher em cada circunscrição 
eleitoral, desprezada a fração se igual ou inferior a meio, equivalente a um, 
se superior”—(Código Eleitoral, art. 106).[1]
- “Determina-se para cada partido ou coligação o quociente partidário, 
dividindo- se pelo quociente eleitoral o número de votos válidos dados sob 
a mesma legenda ou coligação de legendas, desprezada a fração” —
(Código Eleitoral, art. 107).[2]
- O número de cadeiras obtidas para cada partido corresponde a parte 
inteira do quociente partidário. Caso a soma das cadeiras obtidas pelos 
partidos não seja igual ao total de cadeiras, as cadeiras restantes são 
divididas de acordo com o sistema de médias, também conhecido como 
distribuição das sobras (Wikipedia, 2017).

### MODELAGEM E DESENVOLVIMENTO
1) Modelar e criar as classes para resolver o problema proposto;
2) Criar um programa para cadastrar eleições, partidos, candidatos 
conforme especificado;
3) Gravar em um arquivo texto e recuperar informações sobre 
resultado de eleições;
4) Exibir relatório completo da eleição, informando:
- Total de votos - Total de votos válidos, nulos e brancos
- Resultado da eleição no módulo executivo e legislativo
5) Deverá ser capaz de fazer a entrada de votos em Lote de forma 
genérica, através de um arquivo que, terá a quantidade de votos 
recebidos pelos candidatos e ser capaz de mostrar o resultado da 
eleição para o cenário
