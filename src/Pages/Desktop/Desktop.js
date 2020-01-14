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
    render(){
        return (
            <div>
                <Unity unityContent={this.state.unityContent}/>
            </div>
        )
    }
}

export default Desktop;