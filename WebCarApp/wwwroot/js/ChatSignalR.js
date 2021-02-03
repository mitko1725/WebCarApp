
var connection =
    new signalR.HubConnectionBuilder()
        .withUrl("/ChatHub")
        .build();


function createOthersMessage(username, messageText) {
    var innerDiv = document.createElement('div');
    innerDiv.className = 'theChatContainer darker';
    document.getElementById('messagesList').appendChild(innerDiv);
    let theH4 = document.createElement("h4");
    theH4.innerHTML = username;
    innerDiv.appendChild(theH4);
    let theP = document.createElement("p");
    theP.innerHTML = messageText;
    innerDiv.appendChild(theP);
    let theH1 = document.createElement("SPAN");
    theH1.className = 'time-left';
    theH1.innerHTML = new Date().toLocaleTimeString();

    innerDiv.appendChild(theH1);

}

function createCallerMessage(username, messageText) {
    var innerDiv = document.createElement('div');
    innerDiv.className = 'theChatContainer';
    document.getElementById('messagesList').appendChild(innerDiv);
    let theH4 = document.createElement("h4");
    theH4.innerHTML = username;
    innerDiv.appendChild(theH4);
    let theP = document.createElement("p");
    theP.innerHTML = messageText;
    innerDiv.appendChild(theP);
    let theH1 = document.createElement("SPAN");
    theH1.className = 'time-left';
    theH1.innerHTML = new Date().toLocaleTimeString();

    innerDiv.appendChild(theH1);

}

connection.on("OthersMessage",
    function (message) {

        createOthersMessage(escapeHtml(message.user), escapeHtml(message.text));

    });
connection.on("CallerMessage",
    function (message) {

        createCallerMessage(escapeHtml(message.user), escapeHtml(message.text));


    });
document.getElementById("sendButton").addEventListener("click", function () {
    var message = document.getElementById("messageInput").value;
    var username = document.getElementById("usernameHolder").textContent;

    if (!isEmpty(username) && !isEmpty(document.getElementById("messageInput").value)) {

        document.getElementById("messageInput").value = "";
        connection.invoke("Send", username, message);
    }
    else {
        alert("You must enter username and message first!");
    }
});

connection.start().catch(function (err) {
    return console.error(err.toString());
});

function escapeHtml(unsafe) {
    return unsafe
        .replace(/&/g, "&amp;")
        .replace(/</g, "&lt;")
        .replace(/>/g, "&gt;")
        .replace(/"/g, "&quot;")
        .replace(/'/g, "&#039;");
}

document.getElementById("safeChanges").addEventListener("click", function () {
    let text = document.getElementsByName("usernameInput")[0].value.trim();
    if (!isEmpty(text) && text.length < 25) {
        document.getElementsByClassName("usernameFloatLeft")[0].style.display = "block";
        document.getElementById("usernameHolder").innerHTML = text;
        document.getElementsByClassName("usernameContainer")[0].style.display = "none";
    }
    else {
        alert("Please enter username again.\n\nUsername length must be below 25 symbols!\nUsername should not be empty!");
    }
})

document.getElementById("changeUsername").addEventListener("click", function () {
    document.getElementById("usernameHolder").innerHTML = "";
    document.getElementsByName("usernameInput")[0].value = "";
    document.getElementsByClassName("usernameContainer")[0].style.display = "block";
    document.getElementsByClassName("usernameFloatLeft")[0].style.display = "none";
})


function isEmpty(val) {
    return (val === undefined || val == null || val.length <= 0) ? true : false;
}


document.getElementById("greetings").addEventListener("click", function () {
    var message = "";
    let currentHours = new Date().getHours();
    var ampm = currentHours >= 12 ? 'pm' : 'am';
    console.log(currentHours);
    console.log(ampm);

    switch (ampm) {
        case "am":
            if (currentHours > 4) {
                message = "Good Morning";
            }
            else {
                message = "Good Evening";
            }
            break;
        case "pm":
            if (currentHours > 4) {
                message = "Good Afternoon";
            }
            else {
                message = "Good Evening";
            }
        default:
    }
    var username = document.getElementById("usernameHolder").textContent;

    if (!isEmpty(username)) {

        document.getElementById("messageInput").value = "";
        connection.invoke("Send", username, message);
    }
    else {
        alert("You must enter username first!");
    }


})

document.getElementById("goodbye").addEventListener("click", function () {
    var message = "";
    var arrayWithGoodbyes = ["Bye bye!", "I’m off", "Goodbye", "Have a nice day", "Take care", "Catch you later", "I gotta take off"];
    var randomNumber = getRandomInt(arrayWithGoodbyes.length);
    message = arrayWithGoodbyes[randomNumber];
    var username = document.getElementById("usernameHolder").textContent;

    if (!isEmpty(username)) {

        document.getElementById("messageInput").value = "";
        connection.invoke("Send", username, message);
    }
    else {
        alert("You must enter username first!");
    }


})

var text = "";
document.getElementById("joke").addEventListener("click", function () {
    
    var message = "";
    var url = 'https://icanhazdadjoke.com/';
    fetch(url)
        .then(function (response) {
            return response.text()
        })
        .then(function (html) {
            var parser = new DOMParser();
            var doc = parser.parseFromString(html, "text/html");
            var first = doc.body.innerHTML.search("<p class=\"subtitle\">");
            var crop = doc.body.innerHTML.substr(first + 20, 200);
            var last = crop.lastIndexOf("</p>");
            crop = crop.substr(0, last);
         
            message = crop;

            var username = document.getElementById("usernameHolder").textContent;

            if (!isEmpty(username)) {

                document.getElementById("messageInput").value = "";
                connection.invoke("Send", username, message);
            }
            else {
                alert("You must enter username first!");
            }
        })
        .catch(function (err) {
            console.log('Failed to fetch page: ', err);
        });

})



function formatAMPM(date) {
    var hours = date.getHours();
    var minutes = date.getMinutes();
    var ampm = hours >= 12 ? 'pm' : 'am';
    hours = hours % 12;
    hours = hours ? hours : 12; // the hour '0' should be '12'
    minutes = minutes < 10 ? '0' + minutes : minutes;
    var strTime = hours + ':' + minutes + ' ' + ampm;
    return strTime;
}
function getRandomInt(max) {
    return Math.floor(Math.random() * Math.floor(max));
}