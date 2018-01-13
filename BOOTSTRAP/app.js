var express = require('express');
var app = express();
var path = require('path');
var promise = require("bluebird");
var getSqlConnection = require('./server/databaseConnection');

app.use(express.static('.'));

app.get('/', function (req, res) {
	res.sendFile(path.join(__dirname + '/index.html'));
});

app.get('/comanda/:id', function (req, res) {
	var id = req.params.id;
	promise.using(getSqlConnection(), function(connection) {
		return connection.query('SELECT * FROM comanda WHERE id = ' + id).then(function(rows) {
			res.setHeader('Content-Type', 'application/json');
			res.send(rows);
		}).catch(function(error) {
		  console.log(error);
		});
	})
});

app.get('/produto/:id', function (req, res) {
	var id = req.params.id;
	promise.using(getSqlConnection(), function(connection) {
		return connection.query('SELECT * FROM produto WHERE id = ' + id).then(function(rows) {
			res.setHeader('Content-Type', 'application/json');
			res.send(rows);
		}).catch(function(error) {
		  console.log(error);
		});
	})
});

app.get('/comandas', function (req, res) {
	promise.using(getSqlConnection(), function(connection) {
		return connection.query('SELECT * FROM comanda').then(function(rows) {
			res.setHeader('Content-Type', 'application/json');
			res.send(rows);
		}).catch(function(error) {
		  console.log(error);
		});
	})
});

app.get('/produtos', function (req, res) {
	promise.using(getSqlConnection(), function(connection) {
		return connection.query('SELECT * FROM produto').then(function(rows) {
			res.setHeader('Content-Type', 'application/json');
			res.send(rows);
		}).catch(function(error) {
		  console.log(error);
		});
	})
});

app.listen(3000, function () {
	console.log('App listening on port 3000!');
});