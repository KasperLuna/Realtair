import { useState } from "react";
const Increment = ({ steps }) => {
    let [num, setNum] = useState(0);
    const incrementByStep = () => {
       setNum(num + steps || num + 1)
    }
    return(
        <>
            <p>{num}</p>
            <button onClick={() => incrementByStep()}>Increase</button>
        </>
    );
}

export default Increment;