import styled from "styled-components";

interface IStyledLine {
    maxWidth?: string
}

const SLine = styled.div<IStyledLine>`
    height: 2px;
    width: 100%;
    max-width: ${props => props.maxWidth ?? "100%"};
    background-color: #f5f5f5;
`;

const Line = styled(SLine)``;
const LineBlue = styled(SLine)`
    background-color: #17536d;
`;

export { Line, LineBlue }