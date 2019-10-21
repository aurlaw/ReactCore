import React from 'react';
import PropTypes from 'prop-types';


function Animation(props) {

    return (
        <div className="component">
          Animation Name : {props.name}
        </div>
    )
}
Animation.propTypes = {
    name: PropTypes.string.isRequired,
  };

export default Animation;