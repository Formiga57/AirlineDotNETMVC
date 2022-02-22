/// <reference types="react-scripts" />
interface ILoginForm {
    Email: string,
    Senha: string,
}


interface RetornoVerificarToken{
    verificado:boolean,
    usuário:IUserInfos,
}

interface IUserInfos {

    id:int,
    nome:string,
    email:string,
    milhas:Float32Array
}