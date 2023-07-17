import styled from 'styled-components'

const SButton = styled.button`
    padding: 8px 60px;
    border: none;
    outline: 0px;
    cursor: pointer;
    font-size: 14px;
    border-radius: 4px;
    transition: all .3s;
`;

const ButtonBlue = styled(SButton)`
    background-color: #2f7aa1;
    color: #fff;
    border: 1px solid #2f7aa1;
    
    &:hover {
        background-color: #fff;
        color: #2f7aa1;
    }
`;

const ButtonRed = styled(SButton)`
    background-color: red;
    color: #fff;
    border: 1px solid red;
    
    &:hover {
        background-color: #fff;
        color: red;
    }
`;

export {
    SButton,
    ButtonBlue,
    ButtonRed
}