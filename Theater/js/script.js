window.onload = function() {
    showSpectacle();
};

function showSpectacle() {
    var selectBox = document.getElementById("spectacle");
    var selectedValue = selectBox.options[selectBox.selectedIndex].value;
    var spectacleImage = document.getElementById("spectacle-image");

    spectacleImage.src = "images/" + selectedValue;

    var spectacleInfo = document.getElementById("spectacle-info");
    spectacleInfo.style.display = "block";
}

function redirectToSpectacole() {
    var selectBox = document.getElementById("spectacle");
    var selectedValue = selectBox.options[selectBox.selectedIndex].value;

    sessionStorage.setItem("selectedSpectacle", selectedValue);

    window.location.href = "spectacle.html";
}


document.addEventListener('DOMContentLoaded', function() {
    // Your JavaScript code here
    const container = document.querySelector(".container");
    const seats = document.querySelectorAll(".row .seat:not(.sold)");
    const count = document.getElementById("count");
    const total = document.getElementById("total");
    const theaterSelect = document.getElementById("spectacle");

    // Rest of your JavaScript code


populateUI()

let ticketPrice = +theaterSelect.value;

function setTheaterData(theaterIndex, theaterPrice) {
    localStorage.setItem("selectedTheaterIndex", theaterIndex)
    localStorage.setItem("selectedTheaterPrice",theaterPrice)
}

function updateSelectedCount() {
    const selectedSeats = document.querySelectorAll('.row .seat.selected');
    const selectedSeatIds = [...selectedSeats].map(seat => seat.id);

    localStorage.setItem('selectedSeats', JSON.stringify(selectedSeatIds));

    const selectedSeatsCount = selectedSeats.length;

    count.innerText = selectedSeatsCount;
    total.innerText = selectedSeatsCount * ticketPrice;

    setTheaterData(theaterSelect.selectedIndex, theaterSelect.value);
}


function populateUI(){
    const selectedSeats = JSON.parse(localStorage.getItem('selectedSeats'))

    if(selectedSeats !== null && selectedSeats.length > 0){
        seats.forEach((seat, index) => {
            if(selectedSeats.indexOf(index) > -1){
                seat.classList.add("selected");
            } else {
                seat.classList.remove("selected");
            }
        });
    } else {
        seats.forEach(seat => {
            seat.classList.remove("selected");
        });
    }

    const slectedTheaterIndex = localStorage.getItem('selectedTheaterIndex')

    if(slectedTheaterIndex !== null){
        theaterSelect.selectedIndex = slectedTheaterIndex;
    }
}


theaterSelect.addEventListener('change', e =>{
    ticketPrice =+e.target.value
    setTheaterData(e.target.selectedIndex, e.target.value)
    updateSelectedCount()
})

container.addEventListener('click', e => {
    if(e.target.classList.contains('seat') && !e.target.classList.contains('sold')){
        e.target.classList.toggle('selected')

        updateSelectedCount()
    }
})


});

function refreshPage() {
    location.reload();
}


