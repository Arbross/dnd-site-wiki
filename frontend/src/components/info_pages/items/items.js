import { useEffect, useState } from 'react';
import { Table, Button } from 'react-bootstrap';
import { Link } from 'react-router-dom';
import { GetItems, RemoveItem } from '../../../api/itemAxios';
import useAuth from '../../../hooks/useAuth';
import { confirmMessage, successMessage } from '../../services/alerts';

const Items = () => {
    const { auth } = useAuth(); 
    const [ items, setItems ] = useState([]);

    const loadItems = async () => {
        const response = await GetItems(auth().token);
        setItems(response.data);
    }

    useEffect(() => {
        loadItems();
    }, []);

    const ButtonRemove_OnClick = (id) => {
        confirmMessage().then(async (result) => {
            if (result)
            {
                const response = await RemoveItem(id, auth().token);
                await loadItems();

                if (response.status == 200)
                {
                    successMessage("Item successfuly removed!");
                }
            }
        });
    }

    return(
        <div className="container">
            <div>
                <Link to="/add-item" className='btn btn-primary m-2'>Add Item</Link>
            </div>
            <div>
                <Table striped className="m-2">
                  <thead>
                    <tr>
                      <th>Name</th>
                      <th>Type</th>
                      <th>Rarity</th>
                      <th>Cost</th>
                      <th>Details</th>
                    </tr>
                  </thead>
                  <tbody>
                    {
                        items.map((item) => (
                            <tr>
                                <td>{item.name}</td>
                                <td>{item.type}</td>
                                <td>{item.rarity}</td>
                                <td>{item.cost}</td>
                                <td>
                                    <Link to={"/item-details/" + item.id} state={{ from: item }} className="m-1 btn btn-primary">Details</Link>
                                    <Button type="button" className="btn btn-primary m-1" onClick={() => ButtonRemove_OnClick(item.id)}>Remove</Button>
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

export default Items;