import React, {useState, useEffect} from 'react';
import PropTypes from 'prop-types';
// import {hot} from "react-hot-loader";
//import ErrorBoundary from './ErrorBoundary';

const Generator = (props) => {
  const [screenData, setScreenData] = useState(null);

  useEffect(() => {
          const fetchData = async () => {
            const response = await fetch('/api/puppeteer/capture');
            let data = await response.json();
            console.log(data);
          };

        //   // const response = await fetch('/api/puppeteer/capture');
        //   // let data = await response.json();
        //   // console.log(data);

        //   // const imgData = 'data:image/jpg;base64, ' + data.message;
        //   // setScreenData(imgData);
        // fetchData();
  },[]);
    return (
        <div className="component">
          Generator Name : {props.name}
          <br/>
          {screenData ? (
            <img src={screenData} />
          ) : (
            <p>Loading...</p>
          )}
        </div>
    )
}
Generator.propTypes = {
    name: PropTypes.string.isRequired,
  };

export default Generator;
