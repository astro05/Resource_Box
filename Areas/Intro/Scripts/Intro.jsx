
//import React, { useEffect, useRef } from 'react';
//import React from 'react';
//import ReactDOM from 'react-dom';
//import lottie from 'lottie-web';


export default function App() {
    const defaultOptions = {
        loop: true,
        autoplay: true,
        animationData: "./Areas/Intro/Scripts/loadball.json",
        rendererSettings: {
            preserveAspectRatio: "xMidYMid slice"
        }
    };

    return (
        <div>
            <Lottie
                options={defaultOptions}
                height={400}
                width={400}
            />
        </div>
    );
}


/*
class CommentBox extends React.Component {
    render() {
        return (
            <><div className="commentBox">Hello <Redirect to="./Areas/Intro/Scripts/loading.html" /></div>
                <meta httpEquiv="refresh" content="5;url=http://www.google.com" /></>

           

        );
    }
}

ReactDOM.render(
    React.createElement(CommentBox, null),
    document.getElementById('content'),
);
*/







/*
var Intro = React.createClass({
    render: function () {
        return (
            <div>Intro: JOY </div>
        );
    }

});

React.render(<Intro />, document.getElementById("reactdiv"));*/