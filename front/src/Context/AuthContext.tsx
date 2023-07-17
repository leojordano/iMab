"use client"

import { createContext, useState } from "react";
import { UserValidate } from "@/utils/validates"

interface IAuthContext {
    userIsAuthenticated: boolean
    toggleIsAuthenticated: () => void
}

interface IAuthProvider {
    children: React.ReactNode
}

const INITIAL_AUTH_CONTEXT: IAuthContext = {
    userIsAuthenticated: false,
    toggleIsAuthenticated: () => {}
} 

const AuthContext = createContext<IAuthContext>(INITIAL_AUTH_CONTEXT);

const AuthProvider = ({ children }: IAuthProvider) => {
    const [ userIsAuthenticated, setUserIsAuthenticated ] = useState<boolean>(UserValidate.checkUserHaveASessionOnLocalStorage())

    const toggleIsAuthenticated = () => {
        UserValidate.setUserSessionOnLocalStorage()
        setUserIsAuthenticated(v => !v)
    }
    
    const values: IAuthContext = {
        userIsAuthenticated,
        toggleIsAuthenticated
    }

    return (
        <AuthContext.Provider value={values}>
            {children}
        </AuthContext.Provider>
    )
}

export {
    AuthContext,
    AuthProvider
}