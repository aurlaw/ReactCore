import React, {useState, useEffect} from 'react';
import PropTypes from 'prop-types';
import ReactCountdownClock from "react-countdown-clock";

import Users from '../data/users';

import worker from '../utilities/Worker';
import WebWorkerSetup from '../utilities/WorkerSetup';


function WebWorker(props) {
    var ww;
    const [count, setCount] = useState(0);

    const onFetch = () =>  {
        // console.log("Fetch Direct");
        const users = Users();
        setCount(users.length);
    }
    const onFetchWW = () => {
        // console.log('Fetch Web Worker');
        // convert user function to string and pass as message to worker
        // this is a work around since we cannot pass the function directly
        var u = Users.toString();
        if(ww) {
            ww.postMessage({users: u});
            ww.addEventListener("message", event => {
                setCount(event.data.length);
            });
        }
    }
    useEffect(() => {
        // this.worker = new WebWorker(worker);
        ww = new WebWorkerSetup(worker);
        return () => {
            if(ww) {
                ww.terminate();
            }
        };
      });
    return (
        <div className="component">
          Web Worker Name : {props.name}
          <div className="d-sm-flex justify-content-center mb-3">
            <div className="p-3 p-sm-5">
                <ReactCountdownClock
                    seconds={100}
                    color="#000"
                    alpha={0.9}
                    size={200}/>    
            <p className="text-md-center">Total User Count: {count}</p>
            <p className="text-md-center">
                <button className="btn btn-dark" onClick={() => onFetch()}>
                    Fetch Users Direct
                </button>
            </p>

            </div>
            <div className="p-3 p-sm-5">
                <ReactCountdownClock
                seconds={100}
                color="#60be54"
                alpha={0.9}
                size={200}/>    
            <p className="text-md-center">Total User Count: {count}</p>
            <p className="text-md-center">
                 <button className="btn btn-success" onClick={() => onFetchWW()}>
                    Fetch Users Web Worker
                </button>
            </p>
            </div>
          </div>

        </div>
    )
}
WebWorker.propTypes = {
    name: PropTypes.string.isRequired,
  };

export default WebWorker;

/**


 */