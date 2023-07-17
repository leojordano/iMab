class UserValidate {
    private static LocalStoragePrefix: string = "imab:"

    //#region Private Methods
    private static getItemFromLocalStorage = (item: string): string | null => {
        if(typeof window !== 'undefined') {
            return window.localStorage.getItem(`${this.LocalStoragePrefix}${item}`)
        }

        return null
    }

    private static setItemFromLocalStorage = <T>(item: string, value: T): void => {
        if(typeof window !== 'undefined') {
            window.localStorage.setItem(`${this.LocalStoragePrefix}${item}`, value as string)
        }
    }
    //#endregion

    //#region Publics Methods
    static validateUserName(userName: string): boolean {
        if(userName) {
            return true
        }
        
        return false
    }

    static validateUserPassword(password: string): boolean {
        if(password) {
            return true
        }
        
        return false
    }

    static checkUserHaveASessionOnLocalStorage = () => {
        return this.getItemFromLocalStorage('userSession') ? true : false
    }

    static setUserSessionOnLocalStorage = () => {
        this.setItemFromLocalStorage<number>('userSession', 1)
    }
    //#endregion
}

export {
    UserValidate
}