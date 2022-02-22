import {createGlobalStyle} from "styled-components";
export const TemaPadrão = {
    cores:{
        headerBg:'#F1DB4B',
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