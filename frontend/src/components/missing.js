import { Button } from 'react-bootstrap';
import { useNavigate } from 'react-router-dom';
import { checkToken } from './page_parts/layout';

const Missing = () => {
    const navigate = useNavigate();

    const goBack = () => {
        if (!checkToken())
        {
            navigate("/login");
        }
        else if (checkToken())
        {
            navigate("/home");
        }
    };

    return (
        <section className="container p-5">
            <h2>Oops!</h2>
            <br />
            <strong>404 Page Not Found</strong>
            <div>
                <br />
                <Button onClick={goBack}>Home page</Button>
            </div>
        </section>
    )
}

export default Missing;