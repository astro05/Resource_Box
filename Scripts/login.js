const form = document.getElementById('form');
const email = document.getElementById('email');
const password = document.getElementById('password');



email.addEventListener('input', e => {
	e.preventDefault();
	
	checkEmail();
});
 
     password.addEventListener('input', e => {
	e.preventDefault();
	
	checkPassword();
});

      


function checkEmail()
      {
          const emailValue = email.value.trim();
          
          if(emailValue === '') {
		setErrorFor(email, 'Email cannot be blank');
	} else if (!isEmail(emailValue)) {
		setErrorFor(email, 'Not a valid email');
	} else {
		setSuccessFor(email);
	}
	}

  
      
      function checkPassword()
      {
          
	const passwordValue = password.value.trim();
	
	if(passwordValue === '') {
		setErrorFor(password, 'Password cannot be blank');
	} else {
		setSuccessFor(password);
	}
	
      }
      
      
      
form.addEventListener('submit', e => {
	e.preventDefault();
	
	checkInputs();
});     

var validEmail,pass;
function checkInputs() {
	// trim to remove the whitespaces
	
	 const emailValue = email.value.trim();
	const passwordValue = password.value.trim();
	
	 if(emailValue === '') {
         validEmail=false;
		setErrorFor(email, 'Email cannot be blank');
	} else if (!isEmail(emailValue)) {
		setErrorFor(email, 'Not a valid email');
	} else {
        validEmail=true;
		setSuccessFor(email);
	}
	
	if(passwordValue === '') {
		setErrorFor(password, 'Password cannot be blank');
        pass=false;
	} else {
		setSuccessFor(password);
        pass=true;
	}
	
    
}
form.addEventListener('submit', e => {
	e.preventDefault();
	
	if(validEmail && pass)
    {
    submitData();
    }
});

 

      function submitData(){
            document.getElementById("form").submit();
       }

function setErrorFor(input, message) {
	const formControl = input.parentElement;
	const small = formControl.querySelector('small');
	formControl.className = 'fm error';
	small.innerText = message;
}

function setSuccessFor(input) {
	const formControl = input.parentElement;
	formControl.className = 'fm success';
}
	
function isEmail(email) {
	return /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/.test(email);
}













// SOCIAL PANEL JS
const floating_btn = document.querySelector('.floating-btn');
const close_btn = document.querySelector('.close-btn');
const social_panel_container = document.querySelector('.social-panel-container');

floating_btn.addEventListener('click', () => {
	social_panel_container.classList.toggle('visible')
});

close_btn.addEventListener('click', () => {
	social_panel_container.classList.remove('visible')
});