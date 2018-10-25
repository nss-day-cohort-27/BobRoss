fetch("http://localhost:5555/api/songs")
    .then(res => res.json())
    .then(songs => {
        const select = document.querySelector(".remoteSongList")

        const songOption = document.createElement("option")
        songOption.value = "0"
        songOption.textContent = "Select a favorite song..."
        select.appendChild(songOption)

        songs.map(song => {
            const songOption = document.createElement("option")
            songOption.value = song.songId
            songOption.textContent = song.title
            select.appendChild(songOption)
        })
    })
