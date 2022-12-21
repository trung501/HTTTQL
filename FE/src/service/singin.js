var axios = require('axios');
console.log(document.getElementsByClassName("submit"))
document.getElementsByClassName("submit").onClick= function (event){
    event.preventDefault()
    var email = document.getElementsByClassName("email")
    var password = document.getElementsByClassName("password")
    console.log(email)
    var data = JSON.stringify({

        "email": email,
        "password": password
      });
      

      var config = {
        method: 'post',
        url: 'http://117.4.247.68:15333/authenticator/login/',
        headers: { 
          'Content-Type': 'application/json'
        },
        data : data
      };
      
      axios(config)
      .then(function (response) {
        console.log(JSON.stringify(response.data));
      })
      .catch(function (error) {
        console.log(error);
      });
}

