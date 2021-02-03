function hideAll() {

    document.getElementById('getCar').style.display = "none";
    document.getElementById('getClient').style.display = "none";
    document.getElementById('getOrder').style.display = "none";

    document.getElementById('updateCar').style.display = "none";
    document.getElementById('updateClient').style.display = "none";
    document.getElementById('updateOrder').style.display = "none";

    document.getElementById('postCar').style.display = "none";
    document.getElementById('postClient').style.display = "none";
    document.getElementById('postOrder').style.display = "none";

    document.getElementById('clientData').style.display = "none";
    document.getElementById('orderGetData').style.display = "none";


}
const controllerSelect = document.getElementsByName('selectedItem').item(0)
var controllerNumber = 0;
controllerSelect.addEventListener('change', function (e) {

    console.log(controllerSelect.value);
    hideAll();
    controllerNumber = controllerSelect.value;
    document.getElementsByClassName("apiButtons")[0].style.display = 'block';

});

const getButton = document.getElementById("getButton");
const updateButton = document.getElementById("updateButton");
const postButton = document.getElementById("postButton");


getButton.addEventListener('click', function () {
    hideAll();

    switch (controllerNumber) {
        case "1":
            document.getElementById('getCar').style.display = 'block';
            break;
        case "2":
            document.getElementById('getClient').style.display = 'block';
            break;
        case "3":
            document.getElementById('getOrder').style.display = 'block';
            break;
        default:
    }
});
updateButton.addEventListener('click', function () {
    hideAll();
    switch (controllerNumber) {
        case "1":
            document.getElementById('updateCar').style.display = 'block';
            break;
        case "2":
            document.getElementById('updateClient').style.display = 'block';
            break;
        case "3":
            document.getElementById('updateOrder').style.display = 'block';
            break;
        default:
    }
});
postButton.addEventListener('click', function () {
    hideAll();
    switch (controllerNumber) {
        case "1":
            document.getElementById('postCar').style.display = 'block';
            break;
        case "2":
            document.getElementById('postClient').style.display = 'block';
            break;
        case "3":
            document.getElementById('postOrder').style.display = 'block';
            break;
        default:
    }
});

document.getElementsByName('carId')[0].addEventListener("change", function () {

    carGetButton.style.display = 'block';

})
document.getElementsByName('clientId')[0].addEventListener("change", function () {

    clientGetButton.style.display = 'block';


})
document.getElementsByName('orderNumber')[0].addEventListener("change", function () {

    orderGetButton.style.display = 'block';


})

const carGetButton = document.getElementsByName('getButton')[0];
const clientGetButton = document.getElementsByName('getButton')[1];
const orderGetButton = document.getElementsByName('getButton')[2];

clientGetButton.addEventListener("click", function () {
    let clientId = document.getElementsByName('clientId')[0].value;
    let objWithInput = { clientId: clientId };
    let getClientUrl = '/Home/ClientData';
    for (var i = 0; i < document.getElementsByName('clientData').length; i++) {
        if (document.getElementsByName('clientData')[i].checked) {
            objWithInput[document.getElementsByName('clientData')[i].value] = true;
        }
        else {
            objWithInput[document.getElementsByName('clientData')[i].value] = false;
        }
    }
    console.log(clientId);
    console.log(objWithInput);


    fetch(getClientUrl, {
        method: 'POST',
        body: JSON.stringify(objWithInput),
        headers: {
            'Accept': 'application/json; charset=utf-8',
            'Content-Type': 'application/json;charset=UTF-8'
        }
    })
        .then(res => res.json())
        .then(data => {

            console.log(data);

            hideAll();
            document.getElementById("clientData").style.display = "block";
            document.getElementById('fullClientData').innerHTML = JSON.stringify(data);

        })
        .catch(error => console.error('Error:', error));


})

orderGetButton.addEventListener("click", function () {
    let orderNumber = document.getElementsByName('orderNumber')[0].value;
    let objWithInput = { orderNumber: orderNumber };
    let getOrderUrl = '/Home/OrderData';
    for (var i = 0; i < document.getElementsByName('orderData').length; i++) {
        if (document.getElementsByName('orderData')[i].checked) {
            objWithInput[document.getElementsByName('orderData')[i].value] = true;
        }
        else {
            objWithInput[document.getElementsByName('orderData')[i].value] = false;
        }
    }
    


    fetch(getOrderUrl, {
        method: 'POST',
        body: JSON.stringify(objWithInput),
        headers: {
            'Accept': 'application/json; charset=utf-8',
            'Content-Type': 'application/json;charset=UTF-8'
        }
    })
        .then(res => res.json())
        .then(data => {

            console.log(data);

            hideAll();
            removeElements();
            document.getElementById("orderGetData").style.display = "block";
        
        
            
            Object.entries(data).forEach(([key,value]) => {
                createElement("alert alert-primary yeet", `${key}: ${value}`,"alert");
                console.log(key);
                    console.log(value);
             

            })
          

        })
        .catch(error => console.error('Error:', error));


})


function createElement(classDetails, valueDetails, role) {
    let theParagraph = document.createElement('p');
    theParagraph.className = classDetails;
    theParagraph.innerHTML = valueDetails;
    theParagraph.role = role;

    document.getElementById('orderGetData').appendChild(theParagraph);
}
function removeElements() {

    var elements = document.getElementsByClassName('alert alert-primary yeet');
    console.log(elements.length);
    
    console.log(elements)
    if (elements.length > 0) {
        let theLength = elements.length;
        for (var i = 0; i < theLength; i++) {
            document.getElementById('orderGetData').removeChild(elements[0]);
        }
    }

}





