import React from 'react';
import '../styles/App.css';
import LoadingBar from '../components/LoadingBar.js';

function App() {
  return (
    <div className="App">
      <header className="App-header">
        <h1>Welcome to Food Retail</h1>
        <p>Feeding the people since '24</p>
        <LoadingBar />
      </header>
    </div>
  );
}

export default App;
