import React, { Component } from 'react'
import "./SongList.css"

class SongList extends Component {
    render() {
        return (
            <section className="songs">
            {
                this.props.songs.map(song =>
                    <div key={song.songid}>
                        {song.title}
                    </div>
                )
            }
            </section>
        )
    }
}

export default SongList