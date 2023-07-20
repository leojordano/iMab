"use client"

import { redirect, usePathname } from 'next/navigation'
import { useAuth } from '@/hooks' 
import { useEffect } from 'react'

const privatePaths: string[] = [
    "/"
]

const publicPaths: string[] = [
    "/login"
]

const AuthController = () => {
    const auth = useAuth()
    const path = usePathname()
    
    useEffect(() => {
        if(!auth.userIsAuthenticated && privatePaths.includes(path)) {
            redirect('/login')
        }

        if(auth.userIsAuthenticated && publicPaths.includes(path)) {
            redirect('/')
        }
    }, [auth])

    return (<></>)
}

export { AuthController }