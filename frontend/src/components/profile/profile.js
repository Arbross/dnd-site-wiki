import { useEffect, useState } from "react";
import { Table } from "react-bootstrap";
import GetUserById from '../../api/userAxios';
import useAuth from "../../hooks/useAuth";
import ProfileMenu from "./profileMenu";

export default function Profile() {
    const [user, setUser] = useState({});
    const { auth } = useAuth();

    const loadUser = async () => {
        const response = await GetUserById(auth().userId, auth().token);
        setUser(response.data);
    }

    useEffect(() => {
        loadUser();
    }, []);
      
      const CheckRoles = () => {
        let roles = "";
        if (auth()?.roles[0] !== null && auth()?.roles[0] != "undefined")
        {
            roles += auth()?.roles[0];
        }

        if (auth()?.roles[1] !== null && auth()?.roles[1] != "undefined")
        {
            roles = roles + ", " + auth()?.roles[0];
        }
        
        return roles;
    }
    
    return(
        <>
            <div className="d-flex p-2 container">
                {/* Searcher */}
                <ProfileMenu value={user} />
                <Table striped className="m-2">
                  <thead>
                    <tr>
                      <th>Username</th>
                      <th>First Name</th>
                      <th>Second Name</th>
                      <th>Email</th>
                      <th>Roles</th>
                    </tr>
                  </thead>
                  <tbody>
                    <tr>
                      <td>{user.userName}</td>
                      <td>{user.firstName}</td>
                      <td>{user.secondName}</td>
                      <td>{user.email}</td>
                      <td>{<CheckRoles />}</td>
                    </tr>
                  </tbody>
                </Table>
            </div>
        </>
    );
}
