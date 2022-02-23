import React from 'react';
import styled from "styled-components";
import carrouselimg from "../assets/imagemAviao.jpg";
const Container = styled.div`
  width:100%;
  height:500px;
  display: inline-block;
  overflow: hidden;
  position: relative;
  background-image: url(${carrouselimg});
  background-size: cover;
`

const CarrouselOndas = () => {
    return(
        <Container>
        </Container>
    )
}

export default CarrouselOndas;