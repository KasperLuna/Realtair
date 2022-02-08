import logo from './logo.svg';
import './App.css';
import Increment from './Increment';

function App() {
  return (
    <div className="App">
      <header className="App-header">
        <img src={logo} className="App-logo" alt="logo" />
        <Increment/>
        <Increment steps={2}/>
        <Increment steps={5}/>
      </header>
    </div>
  );
}

export default App;
