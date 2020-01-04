import React, {useState, useEffect} from 'react';
import PropTypes from 'prop-types';
// import {hot} from "react-hot-loader";
//import ErrorBoundary from './ErrorBoundary';

const Generator = (props) => {
  const [screenData, setScreenData] = useState(null);
  const [message, setMessage] = useState("Welcome to React Core Components");
  const createScreen = async () => {
    const postData = {message: message};
    const response = await fetch('/api/puppeteer/capture', {
      method: 'POST',
      mode: 'cors', // no-cors, *cors, same-origin
      cache: 'no-cache', // *default, no-cache, reload, force-cache, only-if-cached
      credentials: 'same-origin', // include, *same-origin, omit
      headers: {
        'Content-Type': 'application/json'
        // 'Content-Type': 'application/x-www-form-urlencoded',
      },      
      redirect: 'follow', // manual, *follow, error
      referrerPolicy: 'no-referrer', // no-referrer, *client
      body: JSON.stringify(postData)
    });
    const data = await response.json();
    // console.log(data);
    const imgData = 'data:image/jpg;base64, ' + data.message;
    setScreenData(imgData);
  };

  useEffect(() => {
    createScreen();
  },[]);

  const doSend = (e) => {
    e.preventDefault();
    // console.log(message);
    setScreenData(null);
    createScreen();
  };
    return (
        <div className="component">
          <p>{props.name}</p>
          <div className="m-1">
            <input name="message" type="text" value={message} size="30" 
              onChange={evt => setMessage(evt.target.value)} placeholder="Enter Message..." />
            <button className="btn btn-primary mx-2" onClick={doSend}>Send</button>
          </div>
          <div className="m-1">
            {screenData ? (
              <img src={screenData} />
            ) : (
              <p>Loading...</p>
            )}
          </div>
        </div>
    )
}
Generator.propTypes = {
    name: PropTypes.string.isRequired,
  };

export default Generator;
