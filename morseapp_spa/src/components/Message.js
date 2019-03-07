import React from 'react';

const Message = (props) => {
    return (
        <div className="ui message">
            <div className="header">
                {props.content}
            </div>
        </div>

    );
};

export default Message;