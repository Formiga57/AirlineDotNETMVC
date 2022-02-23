/// <reference types="react-scripts" />
interface ILoginForm {
    Email: string,
    Senha: string,
}


interface RetornoVerificarToken{
    verificado:boolean,
    usuário:IUserInfos,
    token?:string,
}

interface IUserInfos {

    id:int,
    nome:string,
    email:string,
    milhas:Float32Array
}

interface IVoos {
    key:number,
    nome:string,
}