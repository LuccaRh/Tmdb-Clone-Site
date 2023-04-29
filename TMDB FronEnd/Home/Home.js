const API_KEY = "353b5dc08e1917040e6104fc8dfd49dd";
const MOVIE_ID = 545611;
const SIZE = "w154"

/*w92
w154
w185
w342
w500
w780
original*/ 

let imageElement = document.getElementById("movieImage1");
fetch(`https://api.themoviedb.org/3/movie/${MOVIE_ID}/images?api_key=${API_KEY}`)
  .then(response => {
    if (!response.ok) {
      console.log("Erro")
      throw new Error("Erro na requisição");
    } 
    return response.json();
  })
  .then(data => {
    const posterUrl = `https://image.tmdb.org/t/p/${SIZE}/${data.posters[0].file_path}`;
    imageElement.setAttribute("src", posterUrl);
  });
