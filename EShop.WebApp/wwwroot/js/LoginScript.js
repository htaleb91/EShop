// script.js
document.getElementById('login-form').addEventListener('submit', function (e) {
    e.preventDefault();
    const username = document.getElementById('username').value;
    const password = document.getElementById('password').value;
    // Validate login credentials and perform login logic
    console.log('Login submitted:', username, password);
});

document.getElementById('signup-form').addEventListener('submit', function (e) {
    e.preventDefault();
    const signupUsername = document.getElementById('signup-username').value;
    const email = document.getElementById('email').value;
    const signupPassword = document.getElementById('signup-password').value;
    // Validate signup data and create a new user
    console.log('Sign up submitted:', signupUsername, email, signupPassword);
});
