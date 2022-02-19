import React, {useEffect,useState} from 'react';
import Api from './services/api';

function App() {
  const [welcomeMessage, setWelcomeMessage] = useState<string>("");
  useEffect(()=>{
    const apiInstance = new Api()
    setWelcomeMessage(apiInstance.getWelcomeMessages()[0])
  },[])
  return (
    <div>Teste hahaha! {welcomeMessage}</div>
  );
}

export default App;
