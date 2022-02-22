import React, {useContext, useState} from 'react';
import styled from "styled-components";
import JanelaAviao from '../assets/janelaAviao.jpg';
import Api from "../services/api";
import {AuthContext} from "../contexts/AuthProvider";
import {useNavigate} from "react-router-dom";


const ContainerDiv = styled.div`
  position: absolute;
  height: 100%;
  width: 100%;
  display: flex;
`

const ImageDiv = styled.div`
  height: 100%;
  background-image: url(${JanelaAviao});
  background-size: cover;
  flex-basis: 50%;
`

const LoginDiv = styled.div`
  height: 100%;
  flex-basis: 50%;
`

const LoginTitle = styled.div`
  color: black;
  padding-left: 30px;
  padding-top: 50px;
  font-weight: bolder;
  font-size: 3rem;
`

const LoginBox = styled.div`
  display: flex;
  flex-direction: column;
  align-items: center;
`

function Login() {
    const navigate = useNavigate()
    const {token, setToken} = useContext(AuthContext);
    const [loginForm, setLoginForm] = useState<ILoginForm>({Email: "", Senha: ""});
    const editarFormLogin = ({target}: React.ChangeEvent<HTMLInputElement>) => {
        setLoginForm({...loginForm, [target.name]: target.value})
    }
    const enviarFormLogin = (e: React.FormEvent) => {
        e.preventDefault()
        const api = new Api()
        api.VerificarLogin(loginForm).then(tokenRecebido => {
            setToken(tokenRecebido)
            navigate('/meusvoos')
        })
    }
    return (
        <ContainerDiv>
            <ImageDiv/>
            <LoginDiv>
                <LoginTitle>
                    Faça seu log-in para acessar sua conta.
                </LoginTitle>
                <LoginBox>
                    <form onSubmit={enviarFormLogin}>
                        <input type={"email"} placeholder={"Email"} value={loginForm.Email} onChange={editarFormLogin}
                               name={"Email"}/>
                        <br/>
                        <input type={"password"} placeholder={"Senha"} value={loginForm.Senha}
                               onChange={editarFormLogin} name={"Senha"}/>
                        <br/>
                        <button type={"submit"}>Enviar</button>
                    </form>
                </LoginBox>
            </LoginDiv>
        </ContainerDiv>
    );
}

export default Login;