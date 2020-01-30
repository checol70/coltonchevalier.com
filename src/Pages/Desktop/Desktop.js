import React, { Component } from "react";
import "./Desktop.css";
import Unity, { UnityContent } from "react-unity-webgl";

class Desktop extends Component{
    state = {
        unityContent :  new UnityContent(
            "MyGame/Build/MyGame.json",
            "MyGame/Build/UnityLoader.js"
            )
    }
    exit = (place)=>{
        console.log("tried running it")
        console.log(place)
        console.log(this.props.history)
        this.props.history.push(place);
    }
    render(){
        return (
            <div>
                <Unity unityContent={this.state.unityContent}/>
                <button onClick = {()=>{this.exit("/")}}>tryit</button>
            </div>
        )
    }
}

export default Desktop;