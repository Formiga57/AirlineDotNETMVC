import React, {useContext} from 'react';
import styled from "styled-components";
import {TemaPadrão} from "../styles/temas";
import {AuthContext} from "../contexts/AuthProvider";

const Container = styled.div`
  border-radius:6px;
  background-color: ${TemaPadrão.cores.corBotao};
  height:30px;
  font-size: 15pt;
  font-weight: 500;
  padding:10px;
  box-sizing: content-box;
  color: ${TemaPadrão.cores.corTexto};
  cursor:pointer;
  transition:all 0.2s;
  &:hover{
    background-color: ${TemaPadrão.cores.corBotaoHover};
  }
`

const MinhaConta = () => {
    const {usuarioInfo} = useContext(AuthContext);
    return (
        <Container>
            {(()=>{
                if(usuarioInfo?.nome){
                    return(<>
                        <p>{"Olá " + usuarioInfo?.nome.split(" ")[0]}</p>
                        <p style={{fontSize:"8pt",textAlign:"center",marginTop:"-2px"}}>Suas milhas: {usuarioInfo.milhas}</p>
                        </>
                    )
                }else{
                    return "Minha conta"
                }
            })()}
        </Container>
    );
};


export default MinhaConta;
