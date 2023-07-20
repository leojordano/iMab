import { SInput } from './styles'

interface IInput {
    placeholder?: string
    className?: string
    name: string
    defaultValue?: string
    onChange?: (e: React.ChangeEvent<HTMLInputElement>) => void
}

const Input = (props: IInput) => {

    return (
        <SInput {...props} />
    )
}

export { Input }