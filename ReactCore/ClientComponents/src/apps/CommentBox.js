import React from 'react';
import PropTypes from 'prop-types';


function CommentBox(props) {

    return (
        <div className="component">
            Comment Box Component<br/>
           Post ID: {props.post_id}<br/>
           Comment: {props.post_comment}
        </div>
    )
}
CommentBox.propTypes = {
    post_id: PropTypes.string.isRequired,
    post_comment: PropTypes.string,
  };

export default CommentBox;