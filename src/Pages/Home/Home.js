import React, { Component } from "react";
import { Link } from "react-router-dom";
import "./Home.css";

class Home extends Component{
    render(){
        return (
            <div>
                <h2>Welcome to Colton's Portfolio</h2>
                <p>I am currently building my portfolio. This means that lots of content is missing. I do not have the unity game hooked up to the react app, but I have created the unity game that is going to be the center of the portfolio. I am planning on making it so that if you drive the tank past one of the walls it will lead you to a different page on this app. Please come back once I have hooked that up!</p>
                <p>Thanks,</p>
                <p>Colton</p>
                <h3>Instructions</h3>
                <p>Left Click: Fire Armor Piercing</p>
                <p>Right Click: Fire High Explosive</p>
                <p>WASD keys: drive the tank</p>
                <p>ESC/CTRL: Unlock Mouse Cursor</p>
                <p>To see content: Drive past initial wall placement. will bring you to react pages, or links to external pages.</p>

                <Link to="/desktop">
                    <button>Drive the Tank!</button>
                </Link>
                <Link to="/mobile">
                    <button disabled="true">Just show me the words.</button>
                </Link>
            </div>
        )
    }
}

export default Home;