 $("#login-button").click(function(event){
     event.preventDefault();
     var user = document.getElementById("user").value;
     var pass = document.getElementById("pass").value;
	 $('form').fadeOut(500);
     $('.wrapper').addClass('form-success');
     window.location = "http://localhost:52080/login.aspx?user=" + user + "&pass=" + pass;
});