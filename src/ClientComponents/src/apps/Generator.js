import React from 'react';
import PropTypes from 'prop-types';
// import {hot} from "react-hot-loader";


const Generator = (props) => {

    return (
        <div className="component">
          Generator Name : {props.name}
        </div>
    )
}
Generator.propTypes = {
    name: PropTypes.string.isRequired,
  };

export default Generator;