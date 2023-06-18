import React, { useEffect, useState } from 'react';
import { useNavigate } from 'react-router-dom';
import axios from 'axios';

const Generate = () => {
    const [amount, setAmount] = useState();

    const generatePeople = async () => {
        window.location.href = `/api/people/generatepeople?amount=${amount}`;
    }

    return (
        <div className="container" style={{ marginTop: 60 }}>
            <div className="d-flex vh-100" style={{ marginTop: "-70px" }}>
                <div className="d-flex w-100 justify-content-center align-self-center">
                    <div className="row">
                        <input type="text" className="form-control-lg" placeholder="Amount" onChange={e => setAmount(e.target.value) } />
                    </div>
                    <div className="row">
                        <div className="col-md-4 offset-md-2">
                            <button onClick={generatePeople} className="btn btn-primary btn-lg">Generate</button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    )
}

export default Generate;