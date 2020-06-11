import React, { Component } from "react";
import "./Desktop.css";
import Unity, { UnityContent } from "react-unity-webgl";

class Desktop extends Component{
    state = {
        height : window.innerHeight,
        width:window.innerWidth
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
    componentDidMount() {
        window.addEventListener('resize', this.changeResolution);
      }
      componentWillUnmount() {
        window.removeEventListener('resize', this.changeResolution);
      }
    changeResolution = ()=>{
        console.log("hello")
        console.log(this.state.height);
        if(this.state.height === parseInt(window.innerHeight) && this.state.width === parseInt(window.innerWidth)){
            return;
        }
        else{
            this.unityContent.send(
                "Main Camera", 
                "ChangeResolution", 
                {height: parseInt(window.innerHeight),
                width: parseInt(window.innerWidth),
                fullscreen:false}
                );
        }
        this.setState({height : parseInt(window.innerHeight), width : parseInt(window.innerWidth)})
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
            {this.changeResolution()}
                <Unity unityContent={this.unityContent}/>
            </div>
        )
    }
}

export default Desktop;