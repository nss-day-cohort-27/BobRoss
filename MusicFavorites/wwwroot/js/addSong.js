document.querySelector(".addFavorite").addEventListener("click", e => {
    const select = document.querySelector(".remoteSongList")

    fetch("http://localhost:5000/favoritesongs/create", {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify({
            songURL: select.value,
            songTitle: select.options[select.selectedIndex].textContent
        })
    })
    .then(r => window.location.reload())
})