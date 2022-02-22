import axios from 'axios';
const axiosConfig = {
    baseURL:"https://localhost:5000"
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
}
export default Api