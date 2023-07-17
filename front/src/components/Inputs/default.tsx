import { SInput } from './styles'

interface IInput {
    placeholder?: string
    className?: string
    name: string
    value?: string
    onChange?: (e: React.ChangeEvent<HTMLInputElement>) => void
}

const Input = (props: IInput) => {

    return (
        <SInput {...props} />
    )
}

export { Input }