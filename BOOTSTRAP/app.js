var express = require('express');
var app = express();
var path = require('path');


app.use(express.static('.'));

app.get('/', function (req, res) {
	res.sendFile(path.join(__dirname + '/index.html'));
});

app.get('/comanda/:id', function (req, res) {
	var id = req.params.id;
	var obj = {
		ID: 1,
		Nome: 'Caixa',
		EmAberto: 0
	};
	res.setHeader('Content-Type', 'application/json');
	res.send(obj);
});

app.get('/produto/:id', function (req, res) {
	var id = req.params.id;
	var obj = {
		ID: 1,
		Nome: 'Meu produto',
		Valor: 4.75
	};
	res.setHeader('Content-Type', 'application/json');
	res.send(obj);
});

app.get('/comandas', function (req, res) {
	var objs = [
		{ ID: 1, Nome: 'Caixa', EmAberto: 0 },
		{ ID: 2, Nome: 'Consumo', EmAberto: 0 },
		{ ID: 3, Nome: 'Preto', EmAberto: 0 },
		{ ID: 4, Nome: 'Luciano', EmAberto: 0 },
		{ ID: 5, Nome: 'Amarildo', EmAberto: 0 },
		{ ID: 6, Nome: 'Deni', EmAberto: 0 },
		{ ID: 7, Nome: 'Marquinhos', EmAberto: 0 },
		{ ID: 8, Nome: 'Edson Capenga', EmAberto: 0 }
	];
	res.setHeader('Content-Type', 'application/json');
	res.send(objs);
});

app.get('/produtos', function (req, res) {
	var objs = [
		{ ID: 1, Nome: 'Heineken', Valor: 4.75 },
		{ ID: 2, Nome: 'brahma 300 ml', Valor: 4.75 },
		{ ID: 3, Nome: 'trindent menta', Valor: 4.75 },
		{ ID: 4, Nome: 'vinho latitude 33', Valor: 4.75 },
		{ ID: 5, Nome: 'jurupinga', Valor: 4.75 },
		{ ID: 6, Nome: 'almaden branco seco', Valor: 4.75 },
		{ ID: 7, Nome: 'maracuja pingo de ouro', Valor: 4.75 },
		{ ID: 8, Nome: 'master gold', Valor: 4.75 },
		{ ID: 9, Nome: 'dreher', Valor: 4.75 },
		{ ID: 10, Nome: 'magnata', Valor: 4.75 },
		{ ID: 11, Nome: 'rayslof tradicional', Valor: 4.75 },
		{ ID: 12, Nome: 'aklov', Valor: 4.75 },
		{ ID: 13, Nome: 'rayslof kiwi', Valor: 4.75 },
		{ ID: 14, Nome: 'rayslof red fruits', Valor: 4.75 },
		{ ID: 15, Nome: 'contini bianco', Valor: 4.75 },
		{ ID: 16, Nome: 'martini bianco', Valor: 4.75 }
	];
	res.setHeader('Content-Type', 'application/json');
	res.send(objs);
});

app.listen(3000, function () {
	console.log('App listening on port 3000!');
});