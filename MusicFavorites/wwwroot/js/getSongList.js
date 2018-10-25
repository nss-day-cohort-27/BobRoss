fetch("http://localhost:5555/api/songs")
    .then(res => res.json())
    .then(console.log)