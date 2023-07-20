import styled from 'styled-components'

const SAlert = styled.div`
    width: 100%;
    max-width: 90vw;
    border-radius: 8px;
    padding: 12px 14px;
    text-align: center;
    position: fixed;
    top: 10px;
    z-index: 100;
    border: 2px solid #000;
    cursor: pointer;
`;

const AlertSuccess = styled(SAlert)`
    border-color: #75b798;
    background-color: #d1e7dd;
    color: #75b798;
`;

const AlertDanger = styled(SAlert)`
    border-color: #dc3545;
    background-color: #f8d7da;
    color: #dc3545;
`;

export {
    SAlert,
    AlertSuccess,
    AlertDanger
}