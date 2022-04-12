function findSongs(){
    var url = "https://localhost:7056/API/songs";
    let searchString = document.getElementById("searchSong").value;

    url += searchString;

    console.log(searchString)

    fetch(url).then(function(response) {
		console.log(response);
		return response.json();
	}).then(function(json) {
        console.log(json)
        let html = ``;
		json.forEach((song) => {
            console.log(song.songTitle)
            html += `<div class="card col-md-4 bg-dark text-white">`;
			html += `<img src="./images/music.jpeg" class="card-img" alt="...">`;
			html += `<div class="card-img-overlay">`;
			html += `<h5 class="card-title">`+song.songTitle+`</h5>`;
            html += `</div>`;
            html += `</div>`;
		});
		
        if(html === ``){
            html = "No Songs found :("
        }
		document.getElementById("searchSongs").innerHTML = html;

	}).catch(function(error) {
		console.log(error);
	})
}

function addSongs(){
    const url = "https://localhost:7056/API/songs";
    
    const title = {
        SongTitle: document.getElementById("title").value}
    console.log(title);

    fetch(url, {
        method: "POST",
        headers: {
            "Accept": 'application/json',
            "Content-Type": 'application/json',
        },
        body: JSON.stringify(title)
    })
    .then((response)=>{
        console.log(response);
        findSongs();
    }) 
}

function deleteSongs(){
    let id = document.getElementById("deleteSong").value;
    const url = "https://localhost:7056/API/songs/"+id;

    fetch(url, {
        method: "DELETE",
        headers: {
            "Content-type": 'application/json'
        },

    })
    .then((response)=>{
        console.log(response);
        findSongs();
    }) 
    .catch(function(error) {
		console.log(error);
	})

}

function favoriteSongs(){
    let id = document.getElementById("favoriteSong").value;
    const url = "https://localhost:7056/API/songs/"+id;

    fetch(url, {
        method: "PUT",
        headers: {
            "Content-type": 'application/json'
        },

    })
    .then((response)=>{
        console.log(response);
        findSongs();
    }) 
    .catch(function(error) {
		console.log(error);
	})

}
