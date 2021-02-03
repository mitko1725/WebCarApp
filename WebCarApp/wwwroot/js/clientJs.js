const clientButton = document.getElementsByName('clientSearchButton')[0];
const clientUrl = '/Clients/ClientSearchCheck';
const form = document.getElementById('searchBar');





clientButton.addEventListener('click', function () {

    let egn = document.getElementsByName('egn')[0].value;
    console.log(egn);
    if (isEmpty(egn)) {
        alert("Insert Client Egn");
    }
    else {


        fetch(clientUrl, {
            method: 'POST',
            body: JSON.stringify(egn),
            headers: {
                'Accept': 'application/json; charset=utf-8',
                'Content-Type': 'application/json;charset=UTF-8'
            }
        })
            .then(res => res.json())
            .then(data => {

                if (data.clientEgn != 0) {
                    var input = document.createElement("input");
                    input.setAttribute("type", "hidden");
                    input.setAttribute("name", "egn");
                    input.setAttribute("value", data.clientEgn);


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



