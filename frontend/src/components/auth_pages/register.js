import { Link } from 'react-router-dom';
import { createRef, useState } from 'react';
import './register.css';
import { register } from '../../api/authAxios';
import { useNavigate } from "react-router-dom";
import { Button, Form, FormControl, FormGroup, FormLabel, InputGroup } from 'react-bootstrap';

const Register = () => {
  const navigate = useNavigate();

  const emailRef = createRef();
  const passwordRef = createRef();
  const firstNameRef = createRef();
  const secondNameRef = createRef();
  const userNameRef = createRef();

  const [errorMessage, setErrorMessage] = useState("");
  const [passwordVisibility, setPasswordVisibility] = useState(false);

  const registerShowPassword_OnChange = () => {
    if (passwordVisibility === true)
    {
      setPasswordVisibility(false);
    }
    else {
      setPasswordVisibility(true);
    }
  }
  
  const submitHandler = async (event) => {
    event.preventDefault();

    try {
      const response = await register({
        email: emailRef.current.value,
        firstName: firstNameRef.current.value,
        secondName: secondNameRef.current.value,
        userName: userNameRef.current.value,
        password: passwordRef.current.value
      });

      if (response.status === 200)
      {
        navigate("/login");
      }
    } catch (err) {
      if (!err?.response) {
        setErrorMessage('No Server Response!');
      } else if (err.response?.status === 400) {
        setErrorMessage('Invalid email or password!');
      } else if (err.response?.status === 401) {
        setErrorMessage('Unauthorized!');
      } else {
        setErrorMessage('Login Failed.');
      }
    }
  }

  return (
    <div className="p-lg-5">
      <h2 className='register-title'>Register form</h2>
      <Form onSubmit={submitHandler} className="d-flex flex-column container-xxl p-lg-5">
        <InputGroup className='m-2'>
          <FormControl
            placeholder="Enter email"
            aria-label="Enter email"
            type="email" ref={emailRef} required
          />
        </InputGroup>
        <InputGroup className='m-2'>
          <FormControl
            placeholder="Enter first name"
            aria-label="Enter first name"
            type="text" ref={firstNameRef} required
          />
        </InputGroup>
        <InputGroup className='m-2'>
          <FormControl
            placeholder="Enter second name"
            aria-label="Enter second name"
            type="text" ref={secondNameRef} required
          />
        </InputGroup>
        <InputGroup className='m-2'>
          <FormControl
            placeholder="Enter username"
            aria-label="Enter username"
            type="text" ref={userNameRef} required
          />
        </InputGroup>
        <InputGroup className='m-2'>
          <FormControl
            placeholder="Enter password"
            aria-label="Enter password"
            type={passwordVisibility ? "text" : "password"} ref={passwordRef} required
          />
        </InputGroup>
        <div className='register-show-password m-1'>
          <input type="checkbox" className="form-check-input" onChange={registerShowPassword_OnChange}/>
          <label className="form-check-label">&ensp;Show password</label>
        </div>
        <label className='error-register-message m-2'>{errorMessage}</label>
        <div className="d-flex">
          <Button type="submit" className="w-100 m-2">Register</Button>
          <Link to="/login" className="btn btn-primary w-100 m-2">Login page</Link>
        </div>
      </Form>
    </div>
  );
}

export default Register;