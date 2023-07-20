import React, { useState } from "react";
import { IVariantType } from "@/@types"
import * as Alerts from './styles'

const variants = {
    Success: Alerts.AlertSuccess,
    Danger: Alerts.AlertDanger,
} as const

type AlertVariant = keyof typeof variants;

interface IAlert {
    Variant: AlertVariant
    children: React.ReactNode
    IsOpen: boolean
    AutoClose?: boolean
}

const getVariant = (V: AlertVariant) => {
    return variants[V];
}

const Alert = ({ Variant, children, IsOpen, AutoClose = true }: IAlert) => {
    const AlertVariant = getVariant(Variant);

    if(!IsOpen) {
        return
    }

    return (
        <AlertVariant>
            {children}
        </AlertVariant>
    )
}

export { Alert, type AlertVariant as AlertVariantType }