'use strict';

module.exports = {
  up: (queryInterface, Sequelize) => {
    return queryInterface.bulkInsert('periodoVendas', [
      {
        "id": 1045,
        "dataInicial": "2017-12-01 18:13:20.000",
        "dataFinal": "2017-12-02 01:51:34.000",
        "valorCaixa": 0,
        "valorEmAberto": 0,
        "createdAt": new Date(),
        "updatedAt": new Date()
      },
      {
        "id": 1046,
        "dataInicial": "2017-12-02 18:01:36.000",
        "dataFinal": "2017-12-03 15:43:17.000",
        "valorCaixa": 0,
        "valorEmAberto": 0,
        "createdAt": new Date(),
        "updatedAt": new Date()
      },
      {
        "id": 2046,
        "dataInicial": "2017-12-03 15:43:17.000",
        "dataFinal": "2017-12-04 17:18:48.000",
        "valorCaixa": 0,
        "valorEmAberto": 0,
        "createdAt": new Date(),
        "updatedAt": new Date()
      },
      {
        "id": 2047,
        "dataInicial": "2017-12-04 17:18:48.000",
        "dataFinal": "2017-12-05 20:37:01.000",
        "valorCaixa": 0,
        "valorEmAberto": 0,
        "createdAt": new Date(),
        "updatedAt": new Date()
      },
      {
        "id": 2048,
        "dataInicial": "2017-12-05 20:37:01.000",
        "dataFinal": "2017-12-06 16:28:58.000",
        "valorCaixa": 0,
        "valorEmAberto": 0,
        "createdAt": new Date(),
        "updatedAt": new Date()
      },
      {
        "id": 2049,
        "dataInicial": "2017-12-06 16:28:58.000",
        "dataFinal": "2017-12-07 17:55:28.000",
        "valorCaixa": 0,
        "valorEmAberto": 0,
        "createdAt": new Date(),
        "updatedAt": new Date()
      },
      {
        "id": 2050,
        "dataInicial": "2017-12-07 17:55:28.000",
        "dataFinal": "2017-12-08 18:01:02.000",
        "valorCaixa": 0,
        "valorEmAberto": 0,
        "createdAt": new Date(),
        "updatedAt": new Date()
      },
      {
        "id": 2051,
        "dataInicial": "2017-12-08 18:01:02.000",
        "dataFinal": "2017-12-09 17:39:24.000",
        "valorCaixa": 0,
        "valorEmAberto": 0,
        "createdAt": new Date(),
        "updatedAt": new Date()
      },
      {
        "id": 2052,
        "dataInicial": "2017-12-09 17:39:24.000",
        "dataFinal": "2017-12-10 16:55:57.000",
        "valorCaixa": 0,
        "valorEmAberto": 0,
        "createdAt": new Date(),
        "updatedAt": new Date()
      },
      {
        "id": 2053,
        "dataInicial": "2017-12-10 16:55:57.000",
        "dataFinal": "2017-12-11 17:57:50.000",
        "valorCaixa": 0,
        "valorEmAberto": 0,
        "createdAt": new Date(),
        "updatedAt": new Date()
      },
      {
        "id": 2054,
        "dataInicial": "2017-12-11 17:57:50.000",
        "dataFinal": "2017-12-12 17:43:30.000",
        "valorCaixa": 0,
        "valorEmAberto": 0,
        "createdAt": new Date(),
        "updatedAt": new Date()
      },
      {
        "id": 2055,
        "dataInicial": "2017-12-12 17:43:30.000",
        "dataFinal": "NULL",
        "valorCaixa": 0,
        "valorEmAberto": 0,
        "createdAt": new Date(),
        "updatedAt": new Date()
      }
    ], {});
  },

  down: (queryInterface, Sequelize) => {
    return queryInterface.bulkDelete('periodoVendas', null, {});
  }
};
//2017-12-01 18:13:20.000