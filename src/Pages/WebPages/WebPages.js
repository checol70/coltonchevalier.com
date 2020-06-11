import React, { Component } from "react";
import { Link } from "react-router-dom";
import "./WebPages.css";

class WebPages extends Component{
    state = {
        pages:[
            new Page("Recipeoogle", "https://recipeoogle.herokuapp.com/")
            ,new Page("RPG Turn Tracker", "https://www.rpgturntracker.com/")
        ]
    }
    getLinks=()=>{
        this.state.pages.forEach((element)=>{

        })
    }
    render=()=>{
        return <div>

        </div>
    }
}

class Page{
    constructor(name, link, image, description){
        this.name = name;
        this.link = link;
        this.image = image;
        this.description = description;
    }
}

export default WebPages;