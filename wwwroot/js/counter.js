
const connection = new signalR.HubConnectionBuilder()
    .withUrl("/counterhub")
    .build();

connection.on("CounterUpdate", (message) => {
    console.debug("Hub Message CounterUpdate : " + message);
    
    const encodedMsg = message;
    
    //const li = document.createElement("li");
    //li.textContent = encodedMsg;
    //document.getElementById("messagesList").appendChild(li);

    document.getElementById("liveCounterText").innerHTML = encodedMsg;
});

connection.start().catch(err => console.error(err));