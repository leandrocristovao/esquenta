const express = require('express')
const logger = require('morgan')
const bodyParser = require('body-parser')

const app = express()
app.use(logger('dev'))
app.use(bodyParser.json())
app.use(bodyParser.urlencoded({ extended: false }))
app.use(function(req, res, next) {
  res.header("Access-Control-Allow-Origin", "*");
  res.header("Access-Control-Allow-Headers", "Origin, X-Requested-With, Content-Type, Accept");
  next();
});

// Require our routes into the application.
require('./server/routes')(app)

var options = {
  index: 'index.html'
}
app.use(express.static('public', options))

// app.get('*', (req, res) => res.status(200).send({
//   message: 'Welcome to the beginning of nothingness.'
// }))

module.exports = app
