import { useEffect, useState } from 'react';
import { Table, Button } from 'react-bootstrap';
import { Link } from 'react-router-dom';
import { GetOrganizations, RemoveOrganization } from '../../../api/organizationAxios';
import useAuth from '../../../hooks/useAuth';
import { confirmMessage, successMessage } from '../../services/alerts';

const Organizations = () => {
    const { auth } = useAuth(); 
    const [ organizations, setOrganizations ] = useState([]);

    const loadOrganizations = async () => {
        const response = await GetOrganizations(auth().token);
        setOrganizations(response.data);
    }

    useEffect(() => {
        loadOrganizations();
    }, []);

    const ButtonRemove_OnClick = (id) => {
        confirmMessage().then(async (result) => {
            if (result)
            {
                const response = await RemoveOrganization(id, auth().token);
                await loadOrganizations();

                if (response.status == 200)
                {
                    successMessage("Organization successfuly removed!");
                }
            }
        });
    }

    return(
        <div className="container">
            <div>
                <Link to="/add-organization" className='btn btn-primary m-2'>Add Organization</Link>
            </div>
            <div>
                <Table striped className="m-2">
                  <thead>
                    <tr>
                      <th>Name</th>
                      <th>Reputation</th>
                      <th>IsFriend</th>
                      <th>Details</th>
                    </tr>
                  </thead>
                  <tbody>
                    {
                        organizations.map((organization) => (
                            <tr>
                                <td>{organization.name}</td>
                                <td>{organization.reputation}</td>
                                <td>{`${organization.isFriend}`}</td>
                                <td>
                                    <Link to={"/organization-details/" + organization.id} state={{ from: organization }} className="m-1 btn btn-primary">Details</Link>
                                    <Button type="button" className="btn btn-primary m-1" onClick={() => ButtonRemove_OnClick(organization.id)}>Remove</Button>
                                </td>
                            </tr>)
                        )
                    }
                  </tbody>
                </Table>
            </div>
        </div>
    );
}

export default Organizations;