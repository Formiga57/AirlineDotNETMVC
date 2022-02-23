import axios from 'axios';
const axiosConfig = {
    baseURL:"https://localhost:5000",
    withCredentials:true
}
const api = axios.create(axiosConfig)
class Api {
    async VerificarLogin(loginForm:ILoginForm):Promise<string>{
        return new Promise(async (resolve, reject) => {
            const res = await api.post("/Seguranca/login", loginForm)
            if(res.status === 200){
                resolve(res.data)
            }else{
                reject()
            }
        })
    }
    async VerificarToken(token:string):Promise<RetornoVerificarToken>{
        return new Promise(async (resolve, reject) => {
            const res = await api.post("/Seguranca/verificarToken", {Token:token})
            if(res.status === 200){
                resolve(res.data)
            }else{
                reject()
            }
        })
    }
    async RefreshToken():Promise<RetornoVerificarToken>{
        return new Promise(async (resolve, reject) => {
            const res = await api.get("/Seguranca/refresh")
            if(res.status === 200){
                resolve(res.data)
            }else{
                reject()
            }
        })
    }
    async ObterVoos():Promise<IVoos[]>{
        return new Promise(async (resolve, reject) => {
            const res = await api.get("/Cache/aeroportosDisponiveis")
            if(res.status === 200){
                let Voos:IVoos[] = []
                Object.keys(res.data).forEach(key=>{
                    Voos.push({key:parseInt(key),nome:res.data[key]})
                })
                resolve(Voos)
            }else{
                reject()
            }
        })
    }
}
export default Api