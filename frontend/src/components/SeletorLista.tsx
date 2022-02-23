import React, {useState} from 'react';
import styled from "styled-components";
import {TemaPadrão} from "../styles/temas"

interface IProps {
    width?: string,
    height?: string,
    placeholder: JSX.Element,
    dados:IDados[],
}
interface IDados {
    key:number,
    nome:string,
}
interface IPropsContainer {
    width?: string,
    height?: string,
}
interface IPropsContainerFechado {
    width?: string,
    height?: string,
    border:boolean,
}
interface ItemDiv {
}

const ContainerGeral = styled.div<IPropsContainer>`
  width:${p=>p.width};
  margin:20px;
  display: flex;
  flex-direction: column;
  position: relative;
`

const ContainerFechado = styled.div<IPropsContainerFechado>`
  border-bottom: ${p=> !p.border ? `solid 2px ${TemaPadrão.cores.principal}` : "none"};
  position: relative;
  border-radius: 6px;
  background-color: white;
  color: white;
  width: 100%;
  height: ${p => p?.height};
  display: flex;
  align-items: center;
  padding: 0 20px;
  justify-content: space-around;
  user-select: none;

  p {
    color: black;
  }
`

const Input = styled.input`
  position: absolute;
  outline: none;
  border: none;
  background-color: transparent;
  height: 100%;
  width: 90%;
  right: 50%;
  transform: translateX(50%);
  font-size: 18pt;
  text-align: center;
`

const DropDownDiv = styled.div<IPropsContainer>`
  padding-top: 20px;
  overflow: hidden;
  max-height: 180px;
  animation: scale-in-ver-top 0.4s ease;
  border-bottom: solid 2px ${TemaPadrão.cores.principal};
  position: absolute;
  z-index: -15;
  top: 40px;
  width: 100%;
  background-color: #3b3b3b;
  border-radius: 0 0 6px 6px;
  @keyframes scale-in-ver-top {
    0% {
      -webkit-transform: scaleY(0);
      transform: scaleY(0);
      -webkit-transform-origin: 100% 0%;
      transform-origin: 100% 0%;
      opacity: 1;
    }
    100% {
      -webkit-transform: scaleY(1);
      transform: scaleY(1);
      -webkit-transform-origin: 100% 0%;
      transform-origin: 100% 0%;
      opacity: 1;
    }
  }
`

const ItemDiv = styled.div<ItemDiv>`
  user-select: none;
  padding: 0 20px;
  display: flex;
  cursor: pointer;
  width: 100%;
  height: 30px;
  color: white;
  font-weight: bold;
  font-size:14pt;
  line-height: 30px;
  &:hover {
    background-color: rgba(73, 72, 72, 0.52);
  }
`

const SeletorLista: React.FC<IProps> = (props) => {
    const [inputFocus, setInputFocus] = useState<boolean>(false);
    const [inputText, setInputText] = useState<string>("");
    const [selected,setSelected] = useState<number>();
    return (
        <ContainerGeral width={props.width} >
        <ContainerFechado height={props.height} border={inputFocus}>
            <Input 
            value={inputText}
            onFocus={() => setInputFocus(true)}
            onChange={((e: React.ChangeEvent<HTMLInputElement>) => setInputText(e.target.value))}
            onBlur={() => {
                if (inputText.length <= 0) {
                    // setInputFocus(false)
                }
            }}/>
            {!inputFocus && inputText.length <= 0 ? props.placeholder : null}
        </ContainerFechado>
        {inputFocus ? (
        <DropDownDiv>
            {props.dados.map((i:IDados,j:number)=>{
                return(<ItemDiv 
                    key={i.key}
                    onClick={(e:React.MouseEvent<HTMLDivElement>)=>{
                        setInputText(i.nome)
                        setInputFocus(false)
                        setSelected(i.key)
                    }}
                >{i.nome}</ItemDiv>)
            })}
        </DropDownDiv>
            ) : null}
        </ContainerGeral>
    );
};

export default SeletorLista;
