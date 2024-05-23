document.addEventListener('DOMContentLoaded', () => {
    const apiUrl = 'http://localhost:5040/api/Spectacol';
    
    fetch(apiUrl)
        .then(response => {
            if (!response.ok) {
                throw new Error('Network response was not ok ' + response.statusText);
            }
            return response.json();
        })
        .then(data => {
            populateSpectacles(data);
        })
        .catch(error => console.error('Error fetching data:', error));

    function populateSpectacles(data) {
        const select = document.getElementById('spectacle');
        
        data.forEach(spectacle => {
            const option = document.createElement('option');
            option.value = spectacle.spectacolId;
            option.textContent = spectacle.nume;
            select.appendChild(option);
        });

        select.addEventListener('change', event => {
            const selectedSpectacleId = event.target.value;
            const selectedSpectacle = data.find(spectacle => spectacle.spectacolId == selectedSpectacleId);
            populateSeats(selectedSpectacle);
        });

        // Automatically populate seats for the first spectacle
        if (data.length > 0) {
            populateSeats(data[0]);
        }
    }

    function populateSeats(spectacle) {
        const seatsContainer = document.getElementById('seats-container');
        seatsContainer.innerHTML = ''; // Clear previous seats
        
        const numRows = Math.ceil(spectacle.numarLocuri / 20);
        let seatIndex = 0;

        for (let i = 0; i < numRows; i++) {
            const row = document.createElement('div');
            row.classList.add('row');

            for (let j = 0; j < 20 && seatIndex < spectacle.numarLocuri; j++, seatIndex++) {
                const seat = document.createElement('div');
                seat.classList.add('seat');
                
                if (spectacle.locs[seatIndex] && spectacle.locs[seatIndex].stare === 'ocupat') {
                    seat.classList.add('sold');
                }

                row.appendChild(seat);
            }

            seatsContainer.appendChild(row);
        }
    }
});

function refreshPage() {
    // Implement your form submission logic here
    alert('Form submitted');
}
