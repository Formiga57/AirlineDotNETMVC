import React, {useContext, useEffect} from 'react';
import styled from "styled-components";
import {AuthContext} from "../contexts/AuthProvider";

const Container = styled.div`
  position:absolute;
  width: 100%;
  height: 100%;
  background-color:red;
`

const Olá = styled.p`
  color:white;
  position: absolute;
  font-size: 20pt;
  right:50%;
  top:50%;
  transform(-50%,-50%);
  text-align: center;
`

function MeusVoos() {
    const {usuarioInfo} = useContext(AuthContext);
    return (
        <Container>
            <Olá>Olá {usuarioInfo?.nome}</Olá>
        </Container>
    );
}

export default MeusVoos;