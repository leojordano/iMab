import { AuthProvider } from "@/Context"

interface IProvider {
    children: React.ReactNode
}

const Providers = ({ children }: IProvider) => {
    return (
        <AuthProvider>
            {children}
        </AuthProvider>
    )
}

export {
    Providers
}