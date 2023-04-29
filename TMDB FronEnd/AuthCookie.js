function VerificarCookie() {
  const tokenInteiro = document.cookie.split('; ').find(row => row.startsWith('TmdbAuthCookie='));
  if (tokenInteiro === undefined) {
    console.log("Cookie não existe")
    return false;
  }
  else {
    return true;
  }
}

function UpdateCabeçario() {
  let logout = document.getElementById("Logout");
  if (VerificarCookie() === true) {
    let cadastro = document.getElementById("cadastro");
    let login = document.getElementById("login");

    const token = document.cookie.split('; ').find(row => row.startsWith('TmdbAuthCookie=')).split('=')[1];
    const decodedToken = jwt_decode(token);
    const nome = decodedToken.name;

    login.textContent = nome;
    login.href = "#";

    cadastro.style.display = "none";

    logout.style.display = "block";
  }
  else {
    logout.style.display = "none";
  }
}

window.onload = function () {
  UpdateCabeçario();
};

document.getElementById("Logout").addEventListener("click", function () {
  // Código para deletar o cookie aqui
  document.cookie = "TmdbAuthCookie=; expires=Thu, 01 Jan 1970 00:00:00 UTC; path=/;";
  location.reload();
});