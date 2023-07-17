import { StyledComponent } from 'styled-components'

interface IVariantType<T extends StyledComponent<T, any, {}, never>> {
    [key: string]: T
}

export type { IVariantType }