import React, {useContext, useEffect, useState} from 'react';
import Header from "./Header";
import MinhaConta from "./MinhaConta";
import {AuthContext} from "../contexts/AuthProvider";
import Api from "../services/api";
import PngLogo from "../assets/pnglogo.png";
import {NavLink} from "react-router-dom";
import CarrouselOndas from "./CarrouselOndas";
import SeletorVoos from "./SeletorVoos";

const Index = () => {
    const {setToken,token,setUsuarioInfo} = useContext(AuthContext);
    const [voos, setVoos] = useState<IVoos[]>([]);
    useEffect(() => {
        const api = new Api()
        api.RefreshToken().then(res=>{
            setUsuarioInfo(res.usuário)
            setToken(res.token)
        })
        api.ObterVoos().then(res=>{
            setVoos(res)
        })
        if(token){
            api.VerificarToken(token).then(res=>{
                setUsuarioInfo(res.usuário)
            })
        }
    }, []);
    return(
        <>
            <Header>
                <img src={PngLogo} alt={""} height={"100%"}/>
                <NavLink to={"/meusvoos"} style={{textDecoration:"none"}}>
                <MinhaConta />
                </NavLink>
            </Header>
            <CarrouselOndas />
            <SeletorVoos voos={voos}/>
        </>
    )
};

export default Index;