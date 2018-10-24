import React, { Component } from "react"
import { Link } from "react-router-dom"
import "bootstrap/dist/css/bootstrap.min.css"


class NavBar extends Component {
    render() {
        return (
            <nav className="navbar navbar-light fixed-top light-blue flex-md-nowrap p-0 shadow">
                <ul className="nav nav-pills">
                    <li className="nav-item">
                        <Link className="nav-link" to="/list">List Songs</Link>
                    </li>
                    <li className="nav-item">
                        <Link className="nav-link" to="/create">Create Song</Link>
                    </li>
                    <li className="nav-item">
                        <Link className="nav-link" to="/login">API Login</Link>
                    </li>
                </ul>
            </nav>
        )
    }
}

export default NavBar