import { useNavigate } from "react-router-dom"
import { Button } from 'react-bootstrap';

const Unauthorized = () => {
    const navigate = useNavigate();
    const goBack = () => navigate("/login");

    return (
        <section className="container p-5">
            <h2>Unauthorized</h2>
            <br />
            <strong>You do not have access to the requested page.</strong>
            <div>
                <br />
                <Button onClick={goBack}>Login Page</Button>
            </div>
        </section>
    )
}

export default Unauthorized;