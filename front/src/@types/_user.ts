interface IUser {
    user: {
        _id: number
        Name: string
        Email: string
        UserProfile?: string
        Roles: string
    }
    Token?: string
}

export { type IUser }