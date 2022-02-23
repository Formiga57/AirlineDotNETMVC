import React from 'react';
import styled from "styled-components";
import SeletorLista from "./SeletorLista";
import {FaPlaneDeparture,FaPlaneArrival} from "react-icons/fa";
import Botao from "./Botao";

interface IDados {
    key:number,
    nome:string,
}

const dados:IDados[] = [
    {key:1,nome:"CNF - Confins"},
    {key:2,nome:"CGH - Congonhas"},
]

const Container = styled.div`
  height: 300px;
  border-radius: 8px;
  z-index: 15;
  width: 60%;
  background-color: rgba(255, 255, 255, 0.8);
  margin: -180px auto auto;
  position: relative;
  display: flex;
  justify-content: center;
  align-items: center;
`

const SeletorVoos = () => {
    return(<Container>
        <SeletorLista dados={dados} width={"270px"} height={"50px"} placeholder={
            <>
            <FaPlaneDeparture color={"black"} fontSize={"22pt"}/>
            <p style={{fontSize:"18pt"}}>Digite a Origem</p>
            </>
        }/>
        <SeletorLista dados={dados} width={"270px"} height={"50px"} placeholder={
            <>
                <FaPlaneArrival color={"black"} fontSize={"22pt"}/>
                <p style={{fontSize:"18pt"}}>Digite o Destino</p>
            </>
        }/>
        <Botao height={"30px"}>
            Buscar
        </Botao>
    </Container>)
}

export default SeletorVoos;