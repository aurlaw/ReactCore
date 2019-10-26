import React from 'react';
import PropTypes from 'prop-types';


function Privacy(props) {

    return (
        <div className="component">
          Privacy Policy Name : {props.policy_name}
        </div>
    )
}
Privacy.propTypes = {
    policy_name: PropTypes.string.isRequired,
  };

export default Privacy;