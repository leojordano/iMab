import { IVariantType } from "@/@types"
import * as Buttons from './styles'

const variants = {
    Blue: Buttons.ButtonBlue,
    Red: Buttons.ButtonRed
} as const

type ButtonVariant = keyof typeof variants
type ButtonClickType = React.MouseEvent<HTMLButtonElement>

interface IButton {
    Text: string
    Variant: ButtonVariant
    OnClick?: (e?: ButtonClickType) => void
}

const getVariant = (V: ButtonVariant) => {
    return variants[V];
}

const Button = ({ Text, Variant, OnClick }: IButton) => {
    const ButtonVariant = getVariant(Variant);

    const onClickButton = (e: ButtonClickType ) => {
        if(OnClick) {
            e.preventDefault()
            OnClick()
        }
    }

    return (
        <ButtonVariant onClick={onClickButton}>{Text}</ButtonVariant>
    )
}

export { Button }