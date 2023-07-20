import Axios, { AxiosInstance, AxiosResponse, AxiosError } from "axios";
import { IUseUser } from "@/hooks"
import { IUser, StatusCode } from "@/@types"

interface IRequest<T = any> {
    Code: StatusCode
    Data: T
    Message: string
}

class AuthService {

    private static Instance: AxiosInstance = Axios.create({
        baseURL: "http://localhost:5182/api/v1",
        headers: {
            'Content-Type': 'application/json'
        }
    });

    static async Login(email: string, password: string): Promise<IRequest<IUser | null>> {
        try {
            const req = await this.Instance({
                url: "/user/login",
                method: "POST",
                headers: {
                    Authorization: ""
                },
                data: {
                    Email: email,
                    Password: password
                }
            });
            
            const result: IRequest = {
                Code: StatusCode.Success,
                Data: req.data,
                Message: ""
            }

            return result;
        } catch(err) {
            let message: string = "Um erro inesperado ocorreu!";

            if(Axios.isAxiosError(err)) {
                message = err.response?.data;
            }

            const result: IRequest = {
                Code: StatusCode.ClientError,
                Data: null,
                Message: message
            }

            return result;
        }
    }

    private static SetToken(token: string) {
        this.Instance.interceptors.request.use(config => {
            config.headers.post['Authorization'] = `Bearer ${token}`;
            return config;
        })
    }
}

export { AuthService }