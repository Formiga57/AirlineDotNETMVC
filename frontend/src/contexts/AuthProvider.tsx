import {createContext, useState} from "react";

interface IAuthContext{
    token?:string,
    setToken:(token:string)=>void,
    usuarioInfo?:IUserInfos,
    setUsuarioInfo:(usuárioInfo:IUserInfos)=>void,
}

export const AuthContext = createContext<IAuthContext>({
    setUsuarioInfo(token: IUserInfos): void {
    },
    setToken(token: string): void {
    }
});
export const AuthProvider: React.FC  = ({children}) =>{
    const [token, setToken] = useState<string>("");
    const [usuarioInfo, setUsuarioInfo] = useState<IUserInfos>();
    return (
    <AuthContext.Provider value={{token,setToken,usuarioInfo,setUsuarioInfo}}>
        {children}
    </AuthContext.Provider>
    )
}