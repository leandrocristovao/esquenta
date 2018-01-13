var mysql = require('promise-mysql');

pool = mysql.createPool({
  host: 'localhost',
  user: 'root',
  password: '$splfiscal10',
  database: 'esquenta',
  connectionLimit: 10
});

function getSqlConnection() {
  return pool.getConnection().disposer(function(connection) {
    pool.releaseConnection(connection);
  });
}

module.exports = getSqlConnection;