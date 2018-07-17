import React from 'react';
import ReactDOM from 'react-dom';
import './index.css';
//import { myConfig } from './config.js';
import App from './App';
import registerServiceWorker from './registerServiceWorker';

ReactDOM.render(<App />, document.getElementById('root'));
registerServiceWorker();