var film;
var id;

//crud-------------------------------------
function createFilm(film) {
    $.ajax({
        url: '/api/films/',
        type: 'POST',
        contentType: "application/json",
        data: JSON.stringify(film),
        success: function (data) {
            alert('Creating was performed.');
        }
    });
}

function updateFilm(id, film) {
    $.ajax({
        url: '/api/films/' + id,
        type: 'PUT',
        contentType: "application/json",
        data: JSON.stringify(film),
        success: function (data) {
            alert('Updating was performed.');
        }
    });
}

function deleteFilm(id) {
    $.ajax({
        url: '/api/films/' + id,
        type: 'DELETE',
        success: function (data) {
            location.reload();
        }
    });
}
//------------------------------------------

function fillFilm() {
    var nameInput = document.getElementById('name-input');
    var yearInput = document.getElementById('year-input');
    var countryInput = document.getElementById('country-input');
    var produceInput = document.getElementById('produce-input');
    var genreInput = document.getElementById('genre-input');
    var film = {
        id: id,
        name: nameInput.value,
        year: yearInput.value,
        country: countryInput.value,
        prod: produceInput.value,
        genre: genreInput.value
    };
    return film;
}

function update() {
    var film = fillFilm();
    updateFilm(id, film);
    location.assign('index.html');
}
