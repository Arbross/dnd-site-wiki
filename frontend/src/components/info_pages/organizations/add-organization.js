import { useRef, useState } from 'react';
import { ButtonGroup, FormControl, InputGroup, Button } from 'react-bootstrap';
import { Link, useNavigate } from 'react-router-dom';
import { CreateOrganization } from '../../../api/organizationAxios';
import './add-organization.css';

const AddOrganization = () => {
    const nameRef = useRef();
    const [isFriend, setIsFriend] = useState(false);
    const descriptionRef = useRef();
    const reputationRef = useRef();

    const navigate = useNavigate();
    const [errorMessage, setErrorMessage] = useState("");

    const submitHandler = async (event) => {
        event.preventDefault();

        try {
          const response = await CreateOrganization({ name: nameRef.current.value, 
            isFriend: isFriend,
            description: descriptionRef.current.value,
            reputation: reputationRef.current.value
          }, sessionStorage.getItem('token'));
    
          if (response.status === 200)
          {
            navigate("/organizations");
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

    const isFriend_OnChange = () => {
      if (isFriend === true)
      {
        setIsFriend(false);
      }
      else {
        setIsFriend(true);
      }
    }

    return(
        <div>
            <h2 className='text-center'>Add Organization</h2>
            <form onSubmit={submitHandler} className='d-flex flex-column align-items-center container'>
                <InputGroup className='m-2'>
                  <FormControl
                    placeholder="Enter name"
                    aria-label="Enter name"
                    type="text" ref={nameRef} required
                  />
                </InputGroup>
                <InputGroup className='m-2'>
                  <FormControl
                    placeholder="Enter reputation"
                    aria-label="Enter reputation"
                    type="number" min={-100} max={100} ref={reputationRef} required
                  />
                </InputGroup>
                <InputGroup className='m-2'>
                  <FormControl
                    placeholder="Enter description"
                    aria-label="Enter description"
                    type="text" ref={descriptionRef} required
                  />
                </InputGroup>
                <div className='organization-is-friend m-1'>
                  <input type="checkbox" className="form-check-input" onChange={isFriend_OnChange}/>
                  <label className="form-check-label">&ensp;Is Friend</label>
                </div>
                <label className='error-register-message'>{errorMessage}</label>
                <ButtonGroup className='m-2' aria-label="Button submit">
                  <Button type="submit">Add Organization</Button>
                </ButtonGroup>
                <Link to="/organizations" className="organization-add-to-organizations-link">Back to organizations</Link> 
            </form>
        </div>
    );
}

export default AddOrganization;