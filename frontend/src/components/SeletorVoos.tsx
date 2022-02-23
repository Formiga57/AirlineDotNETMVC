import React from 'react';
import styled from "styled-components";

const Container = styled.div`
  margin:auto;
  height:300px;
  border-radius: 8px;
  z-index: 15;
  width:60%;
  background-color: rgba(255,255,255,0.8);
  margin-top: -180px;
  position: relative;
`

const SeletorVoos = () => {
    return(<Container>
        <label>Origem</label>
        <select placeholder={"Origem"}>
            <option selected disabled>Origem</option>
            <option>Congonhas - SP</option>
            <option>Confins - BH</option>
            <option>Guarulhos - SP</option>
            <option>Santos Dumont - RJ</option>
        </select>
        <br />
        <label>Destino</label>
        <select placeholder={"Destino"}>
            <option selected disabled>Destino</option>
            <option>Congonhas - SP</option>
            <option>Confins - BH</option>
            <option>Guarulhos - SP</option>
            <option>Santos Dumont - RJ</option>
        </select>
        <br />
        <label>Data de Ida</label>
        <input type={"date"}/>
    </Container>)
}

export default SeletorVoos;