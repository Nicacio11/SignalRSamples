//create connection

var connectionUserAccount = new signalR.HubConnectionBuilder().withUrl("/hubs/userCount").build();

connectionUserAccount.on("updateTotalViews", (value)=> {
    var newCountSpan = document.getElementById("totalViewsCounter");
    newCountSpan.innerText = value.toString();
});

function newWindowLoadedOnClient(){
    connectionUserAccount.send("NewWindowLoaded");
}

function fullfilled(){
    console.log("Fullfilled");
    newWindowLoadedOnClient();
}
function rejected(){
    console.log("Rejected");
}
connectionUserAccount.start()
    .then(fullfilled, rejected);