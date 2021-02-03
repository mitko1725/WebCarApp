const orderButton = document.getElementsByName('orderSearchButton')[0];
const orderUrl = '/Orders/OrderSearchCheck';
const form = document.getElementById('searchBar');
orderButton.addEventListener('click', function () {
    
    let orderInput = document.getElementsByName('orderNumber')[0].value;
    console.log(orderInput);
    if (isEmpty(orderInput)) {
        alert("Insert Order Number");
    }
    else {


        fetch(orderUrl, {
            method: 'POST',
            body: JSON.stringify(orderInput),
            headers: {
                'Accept': 'application/json; charset=utf-8',
                'Content-Type': 'application/json;charset=UTF-8'
            }
        })
            .then(res => res.json())
            .then(data => {

                if (data.theOrderNumber != 0) {
                    var input = document.createElement("input");
                    input.setAttribute("type", "hidden");
                    input.setAttribute("name", "orderNumber");
                    input.setAttribute("value", data.theOrderNumber);


                    form.appendChild(input);
                    form.submit();

                }
                else {
                    alert('Unfortunately, there are no results!');
                }

            })
            .catch(error => console.error('Error:', error));
    }
});


function isEmpty(val) {
    return (val === undefined || val == null || val.length <= 0) ? true : false;
}