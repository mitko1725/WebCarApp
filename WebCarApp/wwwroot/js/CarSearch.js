const carButton = document.getElementsByName('carSearchButton')[0];
const carUrl = '/Cars/CarSearchCheck';
const form = document.getElementById('searchBar');
carButton.addEventListener('click', function () {

    let makeName = document.getElementsByName('makeName')[0].value;
    console.log(makeName);
    if (isEmpty(makeName)) {
        alert("Insert Car Make");
    }
    else {


        fetch(carUrl, {
            method: 'POST',
            body: JSON.stringify(makeName),
            headers: {
                'Accept': 'application/json; charset=utf-8',
                'Content-Type': 'application/json;charset=UTF-8'
            }
        })
            .then(res => res.json())
            .then(data => {

                if (data.carName != 0) {
                    var input = document.createElement("input");
                    input.setAttribute("type", "hidden");
                    input.setAttribute("name", "makeName");
                    input.setAttribute("value", data.carName);


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
