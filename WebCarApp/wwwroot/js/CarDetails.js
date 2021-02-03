
function isEmpty(val) {
    return (val === undefined || val == null || val.length <= 0) ? true : false;
}
let checkMake = document.getElementsByClassName('checkMake')[0];

function makeNameIsNull() {
    if (isEmpty(checkMake.innerHTML)) {
        document.getElementsByTagName('h1')[0].innerHTML = "No such Car."
    }

};
makeNameIsNull();