'use client'

import { useRef, useState } from "react"
import * as S from "@/@styles/login"
import Logo from "@/utils/img/mab-logo1.png"
import { UserValidate } from "@/utils/validates"
import { AuthService } from "@/service/Auth"
import { useAuth } from "@/hooks"
import { StatusCode } from "@/@types"
import { AlertVariantType } from "@/components/Alert"

const INPUT_NAME_USER = "user";
const INPUT_NAME_PASSWORD = "password";

const Login = () => {
    const formRef = useRef<HTMLFormElement>(null)
    const auth = useAuth()

    const [ alertData, setAlertData ] = useState<{ type: AlertVariantType, message: string, isOpen: boolean }>({
        type: "Danger",
        message: "",
        isOpen: false
    });

    const validateInput = (input: HTMLInputElement, validate: (s: string) => boolean): boolean => {
        const isValidate = validate(input.value)

        if(!isValidate) {
            input.classList.add('error')
        }

        if(isValidate) {
            input.classList.remove('error')
        }

        return isValidate
    }

    const handleFormSubmit = async (e: React.FormEvent<HTMLFormElement>) => {
        e.preventDefault()

        if(formRef.current) {
            const form = formRef.current;
            const user: HTMLInputElement | null = formRef.current.querySelector(`input[name="${INPUT_NAME_USER}"]`);
            const password: HTMLInputElement | null = formRef.current?.querySelector(`input[name="${INPUT_NAME_PASSWORD}"]`);
            const buttom: HTMLButtonElement | null = formRef.current?.querySelector("button");

            if(user && password && buttom && form) {
                buttom.setAttribute('disabled', 'true')
                
                const inputValidates: boolean[] = [
                    validateInput(user, UserValidate.validateUserName),
                    validateInput(password, UserValidate.validateUserPassword)
                ]

                if(inputValidates.every(v => v === true)) {
                    const req = await AuthService.Login(user.value, password.value);
                    
                    console.log(req);

                    
                    if(req.Code === StatusCode.Success) {
                        // auth.toggleIsAuthenticated()
                        setAlertData({
                            isOpen: true,
                            message: req.Message,
                            type: "Success"
                        });
                    } else {
                        setAlertData({
                            isOpen: true,
                            message: req.Message,
                            type: "Danger"
                        });
                    }

                }

                buttom.removeAttribute('disabled')
            }
        }
    }

    return (
        <S.Container>
            <S.Alert Variant={alertData.type} IsOpen={alertData.isOpen}>{alertData.message}</S.Alert>
            <S.FormCard onSubmit={handleFormSubmit} ref={formRef}>
                <S.Logo src={Logo.src} alt="Acampamento Mab" />
                <S.Line />
                <S.Input placeholder="Name" name={INPUT_NAME_USER} />
                <S.Input placeholder="Senha" name={INPUT_NAME_PASSWORD} />
                <S.Button Variant="Blue" Text="Entrar" />
            </S.FormCard>
        </S.Container>
    )
}

export default Login