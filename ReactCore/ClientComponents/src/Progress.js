
import React from 'react';
import PropTypes from 'prop-types';


function ProgressBar(props) {
    let pct = props.pctLoaded !==  undefined ? props.pctLoaded : 100;
    return (
        <div className="progress">
            <div className="progress-bar progress-bar-striped progress-bar-animated" 
                role="progressbar" 
                aria-valuenow={pct} 
                aria-valuemin="0"
                aria-valuemax="100" 
                style={{width: pct + '%'}}>{props.loadingValue}</div>
        </div>  
    )
}
ProgressBar.propTypes = {
    loadingValue: PropTypes.string.isRequired,
    pctLoaded: PropTypes.number
  };

export default ProgressBar;