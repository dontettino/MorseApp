import React from 'react';

class InputBar extends React.Component {
    state = { term: '' };

    onFormSubmit = event => {
        event.preventDefault();

        this.props.onSubmit(this.state.term);
    }

    render() {
        return (
            <div className="ui segment">
                <form onSubmit={this.onFormSubmit} className="ui form">
                    <div className="field">
                        <label>Input</label>
                        <div>
                            <input
                                type="text"
                                value={this.state.term}
                                onChange={e => this.setState({ term: e.target.value })}
                                name="message"
                                placeholder="Write your message here." />
                        </div>
                    </div>
                </form>
            </div>
        );
    }
}

export default InputBar;