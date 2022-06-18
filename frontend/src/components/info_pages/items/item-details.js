import { Card, FormLabel } from "react-bootstrap";
import { Link, useLocation } from "react-router-dom";
import './item-details.css';

const ItemDetails = () => {
    const location = useLocation()
    const { from } = location.state;

    return(
        <div className="container">
            <h2 className="m-3 text-center">Details</h2>
            <div className="m-3">
                <Card.Header><h3>{from.name}</h3></Card.Header>
                <Card bg="light" className="d-flex flex-row justify-content-between p-3">
                    <div>
                        <FormLabel><b>Type:</b> {from.type}</FormLabel><br />
                        <FormLabel><b>Cost:</b> {from.cost} copper coins</FormLabel><br />
                        <FormLabel><b>Rarity:</b> {from.rarity}</FormLabel><br />
                        <FormLabel><b>Weight:</b> {from.weight} kg</FormLabel><br />
                        <FormLabel><b>Description:</b> {from.description}</FormLabel><br />
                        <FormLabel><b>Effect:</b> {from.effect}</FormLabel><br />
                        <Link to="/items" className="btn btn-primary">Back to Items</Link>
                    </div>
                    <div>
                        <img src={from.image} alt="Item" className="width"/>
                    </div>
                </Card>
            </div>
        </div>
    );
}

export default ItemDetails;