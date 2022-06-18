import { Card, FormLabel } from "react-bootstrap";
import { Link, useLocation } from "react-router-dom";
import './spell-details.css';

const SpellDetails = () => {
    const location = useLocation()
    const { from } = location.state;

    return(
        <div className="container">
            <h2 className="m-3 text-center">Details</h2>
            <div className="m-3">
                <Card.Header><h3>{from.name}</h3></Card.Header>
                <Card bg="light" className="d-flex flex-row justify-content-between p-3">
                    <div>
                        <FormLabel><b>Level:</b> {from.level} lvl</FormLabel><br />
                        <FormLabel><b>Area:</b> {from.area} m</FormLabel><br />
                        <FormLabel><b>Components:</b> {from.components}</FormLabel><br />
                        <FormLabel><b>Damage Type:</b> {from.damageType}</FormLabel><br />
                        <FormLabel><b>Duration:</b> {from.duration} sec</FormLabel><br />
                        <FormLabel><b>Casting Time By Actions:</b> {from.castingTimeByActions} actions</FormLabel><br />
                        <FormLabel><b>Description:</b> {from.description}</FormLabel><br />
                        <Link to="/spells" className="btn btn-primary">Back to Spells</Link>
                    </div>
                    {/* <div>
                        <img src={from.image} alt="Item" className="width"/>
                    </div> */}
                </Card>
            </div>
        </div>
    );
}

export default SpellDetails;