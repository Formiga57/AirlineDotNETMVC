import {createGlobalStyle} from "styled-components";
export const TemaPadrão = {
    cores:{
        principal:'rgb(241,219,75)',
        headerBg:'rgba(241,219,75,0.6)',
        corBotao:'#CEE7E6',
        corBotaoHover:'#76aeda',
        corTexto:'#283044',
    }
}
export const TemaGlobal = createGlobalStyle`
  * {
    margin: 0;
    padding: 0;
    box-sizing: border-box;
    font-family: 'Lato', sans-serif;
    body {
      background-color: #f6f1f1;
    }
  }
`