var AllContent = document.getElementById('OrderAddleftAside');
var AllContent2 = document.getElementsByClassName('OrderTitle').item(0).textContent;

console.log(AllContent2);
console.log(AllContent);
var clickedCarId = '';
document.getElementsByName('carId').item(0).addEventListener('change', function (e) {
  
    clickedCarId = this.value;
    console.log('You selected: ', clickedCarId);


    const url = '/Orders/OrderPriceInfo';
    var id = clickedCarId;


    fetch(url, {
        method: 'POST',
        body: JSON.stringify(id),
        headers: {
            'Accept': 'application/json; charset=utf-8',
            'Content-Type': 'application/json;charset=UTF-8'
        }
    }).then(res => res.json())
        .then(data => {
        
            document.getElementById('PurchasePrice').value = data.price,
            document.getElementById('PurchaseDate').value = data.date
        

        })
        .catch(error => console.error('Error:', error));

});





