import { Route } from 'react-router-dom'
import React, { Component } from "react"
import SongList from './song/SongList'
import Login from './auth/APILogin';
import NewSong from './song/NewSong';


class ApplicationViews extends Component {

    state = {
        songs: []
    }

    componentDidMount () {
        fetch("http://localhost:5555/api/songs")
            .then(res => res.json())
            .then(songList => this.setState({
                songs: songList
            }));
    }


    render() {
        return (
            <React.Fragment>
                <Route exact path="/list" render={(props) => {
                    return <SongList songs={this.state.songs} />
                }} />
                <Route exact path="/login" render={(props) => {
                    return <Login />
                }} />
                <Route exact path="/create" render={(props) => {
                    return <NewSong />
                }} />
            </React.Fragment>
        )
    }
}

export default ApplicationViews