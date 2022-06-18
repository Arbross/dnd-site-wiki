import './add-character.css';
import { UpdateUser } from '../../../api/userAxios';
import { Form, FormControl, InputGroup, Button, ButtonGroup } from 'react-bootstrap';
import { Link, useLocation } from 'react-router-dom';
import { useRef, useState } from 'react';

const AddCharacter = () => {
    const [ errorMessage, setErrorMessage ] = useState("");
    const navigate = useLocation();

    let classRef = useRef();
    let levelRef = useRef();

    const submitHandler = async (event) => {
        event.preventDefault();

        try {
          const response = await UpdateUser({ 
            
          }, sessionStorage.getItem('token'));
    
          if (response.status === 200)
          {
            navigate("/profile/characters");
          }
        } catch (err) {
          if (!err?.response) {
            setErrorMessage('No Server Response!');
          } else if (err.response?.status === 400) {
            setErrorMessage('Invalid data!');
          } else {
            setErrorMessage('Adding Failed.' + err.errorMessage);
          }
        }
    }

    return(
        <div>
            <h2 className='text-center'>Add Character</h2>
            <form onSubmit={submitHandler} className='d-flex flex-column align-items-center container'>
                <InputGroup className='m-2'>
                  <FormControl
                    placeholder="Enter class"
                    aria-label="Enter class"
                    type="text" ref={classRef} required
                  />
                </InputGroup>
                <InputGroup className='m-2'>
                  <FormControl
                    placeholder="Enter level"
                    aria-label="Enter level"
                    type="text" ref={levelRef} required
                  />
                </InputGroup>
                <label className='error-register-message'>{errorMessage}</label>
                <ButtonGroup className='m-2' aria-label="Button submit">
                  <Button type="submit">Add Character</Button>
                </ButtonGroup>
                <Link to="/profile" className="character-add-to-characters-link">Back to Profile</Link> 
            </form>
        </div>
    );
}

export default AddCharacter;