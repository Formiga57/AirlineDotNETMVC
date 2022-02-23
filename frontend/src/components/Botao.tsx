import React from 'react';
import styled from 'styled-components';
import {TemaPadrão} from "../styles/temas";

const Container = styled.div<IContainer>`
  margin:30px;
  border-radius: 3px;
  padding: 10px;
  font-size: 18pt;
  box-sizing: content-box;
  height:${p=>p.height};
  background-color: ${TemaPadrão.cores.principal};
  color: white;
  font-weight: bolder;
  cursor:pointer;
  &:hover{
    filter: brightness(1.1);
  }
`

interface IProps{
    height:string,
}
interface IContainer{
    height:string
}

const Botao: React.FC<IProps> = (props) => {
    return (
        <Container height={props.height}>
            {props.children}
        </Container>
    );
}

export default Botao;