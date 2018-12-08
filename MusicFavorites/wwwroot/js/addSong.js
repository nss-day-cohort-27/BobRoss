document.querySelector(".addFavorite").addEventListener("click", e => {
    const select = document.querySelector(".remoteSongList")

    fetch("http://localhost:5000/favoritesongs/create", {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify({
            favoriteSongId: select.options[select.selectedIndex].value,
            songURL: select.value,
            songTitle: select.options[select.selectedIndex].textContent
        })
    })
    .then(r => {
        if(r.status === 200) window.location.reload()
    })
})