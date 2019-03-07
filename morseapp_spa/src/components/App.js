import React from 'react';
import axios from 'axios';
import InputBar from './InputBar';
import Message from './Message';

class App extends React.Component {
    state = {
        decodeMessageContent: '',
        encodeMessageContent: ''
    };

    onDecodeSubmit = async term => {
        const response = await axios.post('http://localhost:5000/translate/decode', {
            "code": "morse",
            "message": term
        })
            .catch(error => {
                console.log(error);
                this.setState({ decodeMessageContent: "Invalid characters in message." });
                return;
            });

        if (typeof (response) != "undefined") {
            this.setState({ decodeMessageContent: response.data });
            this.setState({ encodeMessageContent: "" });
            console.log(this.state.decodeMessageContent);
        }
    }

    onEncodeSubmit = async term => {
        const response = await axios.post('http://localhost:5000/translate/encode', {
            "code": "morse",
            "message": term
        })
            .catch(error => {
                console.log(error);
                this.setState({ encodeMessageContent: "Invalid characters in message." });
                return;
            });

        if (typeof (response) != "undefined") {
            this.setState({ encodeMessageContent: response.data });
            this.setState({ decodeMessageContent: "" });
            console.log(this.state.encodeMessageContent);
        }

    }

    render() {
        return (
            <div className="ui segment" style={{ marginLeft: '200px', marginTop: '50px', marginRight: '200px' }}>
                <div className="ui two column very relaxed grid">
                    <div className="column">
                        <div className="ui container" style={{ marginBottom: '50px' }}>
                            <InputBar onSubmit={this.onDecodeSubmit} />
                        </div>
                        <Message content={this.state.decodeMessageContent} />
                    </div>
                    <div className="column">
                        <div className="ui container" style={{ marginBottom: '50px' }}>
                            <InputBar onSubmit={this.onEncodeSubmit} />
                        </div>
                        <Message content={this.state.encodeMessageContent} />
                    </div>
                </div>
            </div>
        );
    };
}

export default App;