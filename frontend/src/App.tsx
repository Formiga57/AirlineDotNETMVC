import React, {useEffect,useState} from 'react';
import Login from './components/Login';
import {TemaGlobal} from "./styles/temas";
import {
    BrowserRouter as Router,
    Route,
    Routes,
} from 'react-router-dom';
import RotaPrivada from "./components/RotaPrivada";
import MeusVoos from "./components/MeusVoos";
import Index from "./components/Index";
function App() {
  return(
      <>
      <TemaGlobal />
      <Router>
        <Routes>
            <Route path={"/login"} element={<Login />} />
            <Route element={<RotaPrivada />}>
                    <Route path={"/meusvoos"} element={<MeusVoos/>}/>
            </Route>
            <Route path={"/"} element={<Index />}/>
        </Routes>
      </Router>
      </>
  )
}

export default App;
