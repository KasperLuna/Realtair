import { useState } from "react";
export default function Increment(props){
    let [num, setNum] = useState(0);
    function incrementByStep() {
       setNum(num + props.steps || num + 1)
    }
    return(
        <>
            <p>{num}</p>
            <button onClick={() => incrementByStep()}>Increase</button>
        </>
    );
}