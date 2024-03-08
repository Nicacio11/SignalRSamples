//create connection
var newCountSpan = document.getElementById("cloakCounter");
var stoneCounter = document.getElementById("stoneCounter");
var wandCounter = document.getElementById("wandCounter");

var connectionDeathlyHallow = new signalR.HubConnectionBuilder()
    .withUrl("/hubs/deathlyhallows", signalR.HttpTransportType.WebSockets)
    .configureLogging(signalR.LogLevel.Information)
    // changing Transport Type => .withUrl("/hubs/userCount", signalR.HttpTransportType.ServerSentEvents)
    .build();

    connectionDeathlyHallow.on("updateDealthlyHallowCount", (cloak, stone, wand)=> {
        newCountSpan.innerText = cloak.toString();
        stoneCounter.innerText = stone.toString();
        wandCounter.innerText = wand.toString();
    });

function fullfilled(){
    connectionDeathlyHallow.invoke("GetRaceStatus").then((raceCounter) => {
        newCountSpan.innerText = raceCounter.cloak.toString();
        stoneCounter.innerText = raceCounter.stone.toString();
        wandCounter.innerText = raceCounter.wand.toString();
    })
}
function rejected(){
    console.log("Rejected");
}
connectionDeathlyHallow.start()
    .then(fullfilled, rejected);