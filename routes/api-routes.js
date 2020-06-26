module.exports = function (app){
    app.get("/hit", (req,res)=>{
        
        res.send("API reached");
    })
}