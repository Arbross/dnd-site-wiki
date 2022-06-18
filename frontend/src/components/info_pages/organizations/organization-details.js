import { Card, FormLabel } from "react-bootstrap";
import { Link, useLocation } from "react-router-dom";
import './organization-details.css';

const OrganizationDetails = () => {
    const location = useLocation()
    const { from } = location.state;

    return(
        <div className="container">
            <h2 className="m-3 text-center">Details</h2>
            <div className="m-3">
                <Card.Header><h3>{from.name}</h3></Card.Header>
                <Card bg="light" className="d-flex flex-row justify-content-between p-3">
                    <div>
                        <FormLabel><b>Reputation:</b> {from.reputation} points</FormLabel><br />
                        <FormLabel><b>Description:</b> {from.description}</FormLabel><br />
                        <FormLabel><b>Is Friend:</b> {`${from.isFriend}`}</FormLabel><br />
                        <Link to="/organizations" className="btn btn-primary">Back to Organizations</Link>
                    </div>
                    {/* <div>
                        <img src={from.image} alt="Item" className="width"/>
                    </div> */}
                </Card>
            </div>
        </div>
    );
}

export default OrganizationDetails;