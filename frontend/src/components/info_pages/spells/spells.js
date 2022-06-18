import { useEffect, useState } from 'react';
import { Table, Button } from 'react-bootstrap';
import { Link } from 'react-router-dom';
import { GetSpells, RemoveSpell } from '../../../api/spellAxios';
import useAuth from '../../../hooks/useAuth';
import { confirmMessage, successMessage } from '../../services/alerts';

const Spells = () => {
    const { auth } = useAuth(); 
    const [ spells, setSpells ] = useState([]);

    const loadSpells = async () => {
        const response = await GetSpells(auth().token);
        setSpells(response.data);
    }

    useEffect(() => {
        loadSpells();
    }, []);

    const ButtonRemove_OnClick = (id) => {
        confirmMessage().then(async (result) => {
            if (result)
            {
                const response = await RemoveSpell(id, auth().token);
                await loadSpells();

                if (response.status == 200)
                {
                    successMessage("Spell successfuly removed!");
                }
            }
        });
    }

    return(
        <div className="container">
            <div>
                <Link to="/add-spell" className='btn btn-primary m-2'>Add Spell</Link>
            </div>
            <div>
                <Table striped className="m-2">
                  <thead>
                    <tr>
                      <th>Name</th>
                      <th>Level</th>
                      <th>Damage Type</th>
                      <th>Components</th>
                      <th>Details</th>
                    </tr>
                  </thead>
                  <tbody>
                    {
                        spells.map((spell) => (
                            <tr>
                                <td>{spell.name}</td>
                                <td>{spell.level}</td>
                                <td>{spell.damageType}</td>
                                <td>{spell.components}</td>
                                <td>
                                    <Link to={"/spell-details/" + spell.id} state={{ from: spell }} className="m-1 btn btn-primary">Details</Link>
                                    <Button type="button" className="btn btn-primary m-1" onClick={() => ButtonRemove_OnClick(spell.id)}>Remove</Button>
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

export default Spells;