"use client"

import { createGlobalStyle } from "styled-components";

const GlobalStyles = createGlobalStyle`
    * {
        padding: 0px;
        margin: 0px;
        box-sizing: border-box;
        outline: 0px;
    }

    html, body {
        height: 100vh;
    }
`

export { GlobalStyles }