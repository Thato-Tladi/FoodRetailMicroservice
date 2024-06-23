import React from 'react';
import '../styles/LoadingBar.css';

const LoadingBar = () => {
  return (
    <div className="loading-bar">
      <span className="food-emoji">🍕</span>
      <span className="food-emoji">🍔</span>
      <span className="food-emoji">🍟</span>
      <span className="food-emoji">🍩</span>
      <span className="food-emoji">🍪</span>
    </div>
  );
}

export default LoadingBar;
