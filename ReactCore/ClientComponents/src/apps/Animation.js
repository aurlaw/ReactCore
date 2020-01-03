import React from 'react';
import PropTypes from 'prop-types';


function Animation(props) {

    return (
        <div className="component">
          Animation Name : {props.name}
          <br/>
          TODO
        </div>
    )
}
Animation.propTypes = {
    name: PropTypes.string.isRequired,
  };

export default Animation;