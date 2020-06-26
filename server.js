const express = require("express");
const session = require("express-session");

const app = express();

const path = require("path");
const bodyParser = require("body-parser");
const PORT = process.env.PORT || 3001;
const API = require("./routes/api-routes");
const config = (process.env.NODE_ENV == "production"?{id:process.env.id, secret:process.env.id}: require("./config")); 

//here is where the middleware lies

app.use(bodyParser.urlencoded({extended:false}));
app.use(bodyParser.json());

if(process.env.NODE_ENV === "production"){
    app.use(express.static("client/build"));
}
API(app);
app.get("*", (req, res) => {
    res.sendFile(path.join(__dirname, "./build/index.html"));
});
app.listen(PORT, () => {
    console.log(`🌎 ==> Server now on port ${PORT}!`);
});