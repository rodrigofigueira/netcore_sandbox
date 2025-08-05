# 02 - Worker com Refit

Projeto para estudos de Worker Services com Refit, simulando uma fila fifo local na própria aplicação, com um worker que consome uma api externa real e insere um novo objeto na fila, o outro worker consome a fila e remove o objeto. O consumo da api é abstraida pela lib Refit.

## Pacotes instalados

```
Refit Version=8.0.0
Refit.HttpClientFactory" Version=8.0.0
```

## API externa 

```
https://api.chucknorris.io/
```