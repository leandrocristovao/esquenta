// const connStr = "Server=DESKTOP-55IKUDN;Database=esquenta_02;User Id=sa;Password=$splfiscal10;";
// const sql = require("mssql");

// sql.connect(connStr)
//    .then(conn => console.log("conectou!"))
//    .catch(err => console.log("erro! " + err));

var Request = require('tedious').Request;
var Connection = require('tedious').Connection;  
    var config = {  
        userName: 'sq',  
        password: '$splfiscal10',  
        server: 'localhost',  
        // If you are on Microsoft Azure, you need this:  
        //options: {encrypt: true, database: 'AdventureWorks'}  
    };  
    var connection = new Connection(config);  
    connection.on('connect', function(err) {  
        console.log("Connected"); 
        request = new Request("SELECT * FROM Produto", function(data){
            console.log(data);
        });
        //request = new Request(sql, statementComplete)
        //   request.on('columnMetadata', columnMetadata);
        //     request.on('row', row);
        //     request.on('done', requestDone);
    });  

// var Connection = require('tedious').Connection;
// var Request = require('tedious').Request;
// var fs = require('fs');

//     var config = {  
//         userName: 'sa',  
//         password: '$splfiscal10',  
//         server: 'localhost',  
//         // If you are on Microsoft Azure, you need this:  
//         //options: {encrypt: true, database: 'AdventureWorks'}  
//     };  

// var connection = new Connection(config);

// connection.on('connect', connected);
// connection.on('infoMessage', infoError);
// connection.on('errorMessage', infoError);
// connection.on('end', end);
// connection.on('debug', debug);

// function connected(err) {
//   if (err) {
//     console.log(err);
//     process.exit(1);
//   }

//   //console.log('connected');

//   process.stdin.resume();

//   process.stdin.on('data', function (chunk) {
//     exec(chunk);
//   });

//   process.stdin.on('end', function () {
//     process.exit(0);
//   });
// }

// function exec(sql) {
//   sql = sql.toString();

//   request = new Request(sql, statementComplete)
//   request.on('columnMetadata', columnMetadata);
//     request.on('row', row);
//     request.on('done', requestDone);

//   connection.execSql(request);
// }

// function requestDone(rowCount, more) {
//   //console.log(rowCount + ' rows');
// }

// function statementComplete(err, rowCount) {
//   if (err) {
//     console.log('Statement failed: ' + err);
//   } else {
//     console.log(rowCount + ' rows');
//   }
// }

// function end() {
//   console.log('Connection closed');
//   process.exit(0);
// }

// function infoError(info) {
//   console.log(info.number + ' : ' + info.message);
// }

// function debug(message) {
//   //console.log(message);
// }

// function columnMetadata(columnsMetadata) {
//   columnsMetadata.forEach(function(column) {
//     //console.log(column);
//   });
// }

// function row(columns) {
//   var values = '';

//   columns.forEach(function(column) {
//     if (column.value === null) {
//       value = 'NULL';
//     } else {
//       value = column.value;
//     }

//     values += value + '\t';
//   });

//   console.log(values);
// }