import React, { Component } from "react";
import "./Desktop.css";
import Unity, { UnityContent } from "react-unity-webgl";

class Desktop extends Component{
    state = {
    }
    unityContent =  new UnityContent(
        "MyGame/Build/MyGame.json",
        "MyGame/Build/UnityLoader.js"
    )
    exit = (place)=>{
        console.log("Called");
        console.log(place)
        this.props.history.push(place);
    }
    setup = ()=>{
        this.unityContent.on("exit", (str)=>{
            console.log(typeof str) 
            this.exit(str)
        })
    }
    
    render(){
        return (
            <div>
            {this.setup()}
                <Unity unityContent={this.unityContent}/>
            </div>
        )
    }
}

export default Desktop;