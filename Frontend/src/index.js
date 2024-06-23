import React from 'react';
import ReactDOM from 'react-dom/client';
import '../src/styles/App.css';
import App from '../src/components/App.js';

const root = ReactDOM.createRoot(document.getElementById('root'));
root.render(
  <React.StrictMode>
    <App />
  </React.StrictMode>
);