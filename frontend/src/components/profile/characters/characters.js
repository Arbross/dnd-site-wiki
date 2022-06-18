import { useEffect, useState } from "react";
import { Table } from "react-bootstrap";
import useAuth from "../../../hooks/useAuth";
import ProfileMenu from "../profileMenu";
import GetUserById from '../../../api/userAxios';

const Characters = () => {
    const [user, setUser] = useState({});
    const { auth } = useAuth();

    const loadUser = async () => {
        const response = await GetUserById(auth().userId, auth().token);
        setUser(response.data);
    }

    useEffect(() => {
        loadUser();
        
    }, []);

    return(
        <>
            <div className="d-flex p-2 container">
                {/* Searcher */}
                <ProfileMenu value={user} />
                <div className="w-100 m-2">
                    <Table striped>
                        <thead>
                          <tr>
                            <th>Character Name</th>
                            <th>Details</th>
                          </tr>
                        </thead>
                        <tbody>
                            {
                                user.playerList?.map((item, key) => {
                                    <tr>
                                        <td>{item.characterName}</td>
                                    </tr>
                                })
                            }
                        </tbody>
                    </Table>
                </div>
            </div>
        </>
    );
}

export default Characters;