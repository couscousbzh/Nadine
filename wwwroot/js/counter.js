
const connection = new signalR.HubConnectionBuilder()
    .withUrl("/counterhub")
    .build();

connection.on("CounterUpdate", (message) => {
    console.debug("COucou Yann");
    const encodedMsg = user + " says " + message;
    const li = document.createElement("li");
    li.textContent = encodedMsg;
    document.getElementById("messagesList").appendChild(li);
});

connection.start().catch(err => console.error(err));