import React, {useState, useRef, useEffect} from 'react';
import PropTypes from 'prop-types';
// import {hot} from "react-hot-loader";
//import ErrorBoundary from './ErrorBoundary';

const Generator = (props) => {
  const [screenData, setScreenData] = useState(null);
  const [formClass, setFormClass] = useState("");
  const [isSending, setIsSending] = useState(false);
  const [message, setMessage] = useState("Welcome to React Core Components");
  let formRef = useRef(null);

  const createScreen = async () => {
    setIsSending(true);
    setScreenData(null);
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
    setIsSending(false);

  };

  useEffect(() => {
    createScreen();
  },[]);

  const handleSubmit = (e) => {
    e.preventDefault();
    e.stopPropagation();
    if(formRef.current.checkValidity() === false) {
      setFormClass("was-validated");
    }
    else {
      createScreen();
    }  
  };
    return (
        <div className="component">
          <p>{props.name}</p>
          <div className="m-1">
            <form ref={formRef} name="generator" className={"needs-validation " + formClass} noValidate onSubmit={handleSubmit}>
              <div className="form-group">
                <label htmlFor="name">Name</label>
                <input type="text" className="form-control" id="message" name="message" placeholder="Enter Message..." value={message}
                onChange={evt => setMessage(evt.target.value)}
                required/>
                <div className="invalid-feedback">
                  Please enter your message.
                </div>
            </div>   
            <button  disabled={isSending && "disabled"} type="submit" className="btn btn-primary m-1 flex-fill flex-md-grow-0">
            Send
            {isSending &&<span className="spinner-grow spinner-grow-sm ml-1" role="status" aria-hidden="true"></span>}
            </button>
            </form>
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

/*
          <form ref={formRef} name="contact" className={"needs-validation " + formClass} noValidate onSubmit={handleSubmit} method="POST" data-netlify="true" data-netlify-recaptcha="true">
            <input type='hidden' name="form-name" value="contact" />
            <div className="form-group">
              <label htmlFor="name">Name</label>
              <input type="text" className="form-control" id="name" name="name" placeholder="Name" required/>
              <div className="invalid-feedback">
                Please enter your name.
              </div>
            </div>      


*/