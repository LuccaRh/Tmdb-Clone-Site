function getAuthHeader() {
  try {
    const tokenInteiro = document.cookie.split('; ').find(row => row.startsWith('TmdbAuthCookie='));
    console.log(tokenInteiro);
    const token = document.cookie.split('; ').find(row => row.startsWith('TmdbAuthCookie=')).split('=')[1];
    return { 'Authorization': `Bearer ${token}` };
  } catch (error) {
    console.log(error);
    return {};
  }
}

const createAccountForm = document.querySelector('#formLoginConta');



createAccountForm.addEventListener('submit',
  async (event) => {
    event.preventDefault();

    const userName = document.querySelector('#username').value;
    const senha = document.querySelector('#password').value;

    const data = { userName, senha };
    const options = {
      method: 'POST',
      headers: { 'Content-Type': 'application/json' },
      credentials: 'include',
      body: JSON.stringify(data)
    };

    await fetch('https://localhost:7242/Tmdb/Login', options)
      
      .then(res => {
        if (!res.ok) {
          return res.text().then(text => { throw new Error(text) })
        }
        else {
          return res.json();
        }
      })

      .then(response => {
        alert("Usuário Logado.");
        var dataExpiracao = new Date();
        dataExpiracao.setTime(dataExpiracao.getTime() + (8 * 60 * 60 * 1000));
        document.cookie = `TmdbAuthCookie=${response.token}; path=/; secure; samesite=none; expires=${dataExpiracao.toUTCString()}`;
        console.log(document.cookie);
        getAuthHeader();
        window.location.href = "../Home/Home.html"
      })

      .catch(error => { alert(error) })
  });