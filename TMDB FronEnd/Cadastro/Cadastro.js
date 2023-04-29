const createAccountForm = document.querySelector('#formCriaçãoConta');

createAccountForm.addEventListener('submit', async (event) => {
  // Prevent form from submitting and refreshing the page
  event.preventDefault();

  const userName = document.querySelector('#username').value;
  const email = document.querySelector('#email').value;
  const senha = document.querySelector('#password').value;

  const data = { userName, email, senha};
  const options = {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(data)
  };

  await fetch('https://localhost:7242/Tmdb/Cadastro', options).then( res=>{
      if(!res.ok) {
        return res.text().then(text => { throw new Error(text) })
       }
      else {
       alert("Usuário Cadastrado.")
     }
    }).catch(error=>{
        alert(error);
    })

});