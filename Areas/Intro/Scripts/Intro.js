import React from 'react';
//import './styles.css';
import Lottie from 'react-lottie';
//import animationData from './Areas/Intro/Scripts/loadball.json';




class Hello extends React.Component {
    render() {
        return (
            <div className="commentBox">Hello, world! I am a CommentBox.</div>
            

        );
    }
}

ReactDOM.render(
    React.createElement(CommentBox, null),
    document.getElementById('content'),
);








/*
class Hello extends React.Component {

    render() {
        return (<h1>Hello React</h1>);
    }

}