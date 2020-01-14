import React, { Component } from "react";
import { Link } from "react-router-dom";
import "./Home.css";

class Home extends Component{
    render(){
        return (
            <div>
                <h2>Welcome to Colton's Portfolio</h2>
                <p>For starters, Unity WebGL builds currently don't play well with touchscreens. Because of this I currently don't have anything for phones, but stay tuned!</p>
                <Link to="/desktop">
                    <button>Mouse and Keyboard</button>
                </Link>
                <Link to="/mobile">
                    <button disabled="true">Touchscreen</button>
                </Link>
            </div>
        )
    }
}

export default Home;