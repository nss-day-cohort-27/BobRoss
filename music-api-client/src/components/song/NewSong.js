import React, { Component } from "react"


export default class NewSong extends Component {

    // Set initial state
    state = {
        title: "",
        releaseDate: "",
        songLength: 0,
        artistId: 0,
        albumId: 0,
        genreId: 0
    }

    // Update state whenever an input field is edited
    handleFieldChange = (evt) => {
        const stateToChange = {}
        stateToChange[evt.target.id] = evt.target.value
        this.setState(stateToChange)
    }

    // Simplistic handler for login submit
    handleLogin = (e) => {
        e.preventDefault()


        fetch("http://localhost:5555/api/songs", {
            "method": "POST",
            "headers": {
                "Content-Type": "application/json",
                "Authorization": `Bearer ${localStorage.getItem("jukebox_token")}`
            },
            "body": JSON.stringify({
                "title": this.state.title,
                "songLength": this.state.songLength,
                "releaseDate": this.state.releaseDate,
                "genreId": this.state.genreId,
                "artistId": this.state.artistId,
                "albumId": this.state.albumId
            })
        })
        .then(res => res.json())
        .then(theNewSong => {
            console.log(theNewSong)
        })

    }

    render() {
        return (
            <form onSubmit={this.handleLogin}>
                <h1 className="h3 mb-3 font-weight-normal">Please sign in</h1>
                <label htmlFor="songTitle">
                    Song Title
                </label>
                <input onChange={this.handleFieldChange} type="text"
                       id="title"
                       placeholder="Song title"
                       required="" autoFocus="" />
                <label htmlFor="releaseDate">
                    Date released
                </label>
                <input onChange={this.handleFieldChange} type="date"
                       id="releaseDate"
                       placeholder="Date of release"
                       required="" />
                <label htmlFor="songLength">
                    Song length
                </label>
                <input onChange={this.handleFieldChange} type="number"
                       id="songLength"
                       placeholder="Length of song in seconds"
                       required="" />
                <label htmlFor="genreId">
                    Genre
                </label>
                <input onChange={this.handleFieldChange} type="number"
                       id="genreId"
                       placeholder="Genre"
                       required="" />
                <label htmlFor="artistId">
                    Artist
                </label>
                <input onChange={this.handleFieldChange} type="number"
                       id="artistId"
                       placeholder="Artist"
                       required="" />
                <label htmlFor="albumId">
                    Album
                </label>
                <input onChange={this.handleFieldChange} type="number"
                       id="albumId"
                       placeholder="Album"
                       required="" />
                <button type="submit">
                    Create Song
                </button>
            </form>
        )
    }
}