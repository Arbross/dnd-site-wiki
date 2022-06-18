import { Link } from "react-router-dom";
import './header.css';

const Header = () => {
    const logOut_OnClick = () => {
        sessionStorage.setItem('token', null);
        sessionStorage.setItem('userId', null);
        sessionStorage.setItem('roles', null);
        window.location.reload(false);
    }

    return(
        <header>
            <nav className="container d-flex justify-content-center no-onclick">
                <Link className="btn" to="/home">Home</Link>
                <Link className="btn" to="/profile">Profile</Link>
                <Link className="btn" to="/spells">Spells</Link>
                <Link className="btn" to="/items">Items</Link>
                <Link className="btn" to="/organizations">Organizations</Link>
                <a className="btn" onClick={logOut_OnClick}>Log Out</a>
            </nav>
        </header>
    );
}

export default Header;