// js/login.js

document.querySelector('form').addEventListener('submit', async function (e) {
    e.preventDefault();

    const username = document.querySelector('input[name="uname"]').value;
    const password = document.querySelector('input[name="psw"]').value;

    try {
        const response = await fetch('http://localhost:5040/api/Utilizator');
        const users = await response.json();

        const user = users.find(u => u.email === username && u.parola === password);

        if (user) {
            alert('Login successful!');
            // Redirect to spectacle.html
            window.location.href = 'spectacle.html';
        } else {
            alert('Invalid username or password');
        }
    } catch (error) {
        console.error('Error logging in:', error);
        alert('An error occurred while logging in. Please try again later.');
    }
});
