import React, {useContext, useEffect, useState} from 'react';
import {Outlet,Navigate} from "react-router-dom";
import {AuthContext} from "../contexts/AuthProvider";
import Api from "../services/api";

const RotaPrivada = () => {
    const [verificado, setVerificado] = useState(false);
    const [acesso, setAcesso] = useState(false);
    const {token,setUsuarioInfo} = useContext(AuthContext);
    useEffect(() => {
        setVerificado(false)
        setAcesso(false)
        const api = new Api()
        if(token){
            api.VerificarToken(token).then(res=>{
                setUsuarioInfo(res.usuário)
                setAcesso(true)
                setVerificado(true)
            })
        }else{
            setAcesso(false)
            setVerificado(true)
        }
    }, []);
    if(verificado){
        return acesso ? <Outlet /> :  <Navigate to={"/"} replace />
    }else{
        return <div>Carregando...</div>
    }
   
};

export default RotaPrivada;
