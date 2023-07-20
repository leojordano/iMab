"use client"

import styled from "styled-components";
import * as I from "@/components/Inputs"
import * as L from "@/components/Line"
import * as B from "@/components/Button"
import * as A from "@/components/Alert"

const Container = styled.div`
    width: 100%;
    height: 100vh;
    display: flex;
    justify-content: center;
    align-items: center;
    background-color: #17536d;
`

const FormCard = styled.form`
    padding: 12px;
    background-color: #fff;
    border-radius: 8px;
    width: 40%;
    display: flex;
    justify-content: center;
    align-items: center;
    flex-direction: column;
    gap: 20px;
`;

const Logo = styled.img`
    max-width: 200px;
    width: 100%;
    object-fit: cover;
`

const Input = styled(I.Input)`
`;

const Line = styled(L.LineBlue)`
`;

const Alert = styled(A.Alert)``;

const Button = styled(B.Button)``;

export { Container, Logo, FormCard, Input, Line, Button, Alert }