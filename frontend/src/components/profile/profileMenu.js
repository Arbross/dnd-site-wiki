import { ListGroup } from "react-bootstrap";
import { Link } from "react-router-dom";

const ProfileMenu = (user) => {
    return(
        <div className="m-2">
            <ListGroup>
                <ListGroup.Item><Link className="btn" to="/profile">Profile</Link></ListGroup.Item>
                <ListGroup.Item>
                    <Link className="btn" to="/profile/characters">Characters</Link>
                    <Link className="btn" to="/profile/add-character">Add Characters</Link>
                </ListGroup.Item>
                <ListGroup.Item><Link className="btn" to="/team">Team</Link></ListGroup.Item>
                <ListGroup.Item><Link className="btn" to="/pinned">Pinned</Link></ListGroup.Item>
            </ListGroup>
        </div>
    );
}

export default ProfileMenu;