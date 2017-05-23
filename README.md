# Teste Backend

Leia primeiro todo o projeto, faça sua estimativa de horas para o desenvolvimento e envie um email com o
título `[Teste Backend] Estimativa` para lagden@textecnologia.com.br

Quando finalizar o teste, publique tudo no seu [Github](https://github.com) e envie um email com o
título `[Teste Backend] Finalizado` para lagden@textecnologia.com.br contendo o link do repositório do projeto


## Missão

- Desenvolver uma **API JSON RESTful** em **Go** ou **Node**
- Faça os testes + coverage


### Especificação

Monte uma base de veículo com a seguinte estrutura:

```
veiculo:   string
marca:     string
vendido:   bool
created:   datetime
updated:   datetime
```

Utilize **MongoDB** ou **MySQL** para armazenar os dados que a **API** irá consumir.


### API endpoints

`GET /veiculos`

Retorna todos os veículos

---

`GET /veiculos/find?q={termo}`

Retorna os veículos onde o `termo` passado via parametro `q` combine com os campos `veiculo` e `descricao`

---

`GET /veiculos/{id}`

Retorna os detalhes do veículo

---

`POST /veiculos`

Adiciona um novo veículo

---

`PUT /veiculos/{id}`

Atualiza os dados de um veículo

---

`PATCH /veiculos/{id}`

Atualiza apenas alguns dados do veículo

---

`DELETE /veiculos/{id}`

Apaga o veículo


## Dúvida

Se tiver qualquer dúvida sobre esse teste, envie um email com o título `[Teste Backend] O assunto que vc deseja` para lagden@textecnologia.com.br
