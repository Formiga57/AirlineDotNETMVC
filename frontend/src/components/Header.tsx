import React from 'react';
import styled from "styled-components";
import {TemaPadrão} from '../styles/temas';
const Container = styled.div`
  background-color: ${TemaPadrão.cores.headerBg};
  width:100%;
  height:80px;
  display:flex;
  align-items: center;
  justify-content: space-around;
  position: absolute;
  z-index: 15;
  top: 0;
  backdrop-filter: blur(5px);
`

const Header: React.FC = ({children}) => {
    return (
        <Container>
            {children}
        </Container>
    );
};

export default Header;
