import styled from "styled-components";

const SInput = styled.input`
    border-radius: 4px;
    outline: 0px;
    padding: 12px 18px;
    border: 1px solid #17536d;
    width: 100%;
    outline: 2px solid rgba(23,83,109,0);
    transition: all .2s;
    
    &:hover {
        outline: 2px solid rgba(23,83,109,0.46);
    }

    &:disabled {
        background-color: rgba(0, 0, 0, .1);
    }

    &.error {
        background-color: #fff;
        outline-color: rgba(255, 92, 116, .5);
        border-color: red;
    }
`;

export {
    SInput
}