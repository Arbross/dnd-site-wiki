import { Link } from 'react-router-dom';
import { createRef, useState } from 'react';
import './login.css';
import { login } from '../../api/authAxios';
import useAuth from '../../hooks/useAuth';
import { useNavigate } from "react-router-dom";
import { Button, Form, FormControl, FormGroup, InputGroup } from 'react-bootstrap';

export default function Login() {
  const navigate = useNavigate();
  const emailRef = createRef();
  const passwordRef = createRef();
  const [errorMessage, setErrorMessage] = useState("");
  const [passwordVisibility, setPasswordVisibility] = useState(false);

  const { loadToStorage } = useAuth();

  const loginShowPassword_OnChange = () => {
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
      const response = await login(emailRef.current.value, passwordRef.current.value);

      const token = response?.data?.token;
      const userRoles = response?.data?.userRoles;
      const userId = response?.data?.userId;

      let roles = '["' + userRoles[0] + '", "' + userRoles[1] + '"]';

      loadToStorage({ userId, roles, token });
      if (response.status === 200)
      {
        navigate("/home");
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
      <h2 className='login-title'>Login form</h2>
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
            placeholder="Enter password"
            aria-label="Enter password"
            type={passwordVisibility ? "text" : "password"} ref={passwordRef} required
          />
        </InputGroup>
        <div className='login-show-password m-1'>
          <input type="checkbox" className="form-check-input" onChange={loginShowPassword_OnChange}/>
          <label className="form-check-label">&ensp;Show password</label>
        </div>
        <label className='error-login-message m-2'>{errorMessage}</label>
        <div className="d-flex">
          <Button type="submit" className="w-100 m-2">Login</Button>
          <Link to="/register" className="btn btn-primary w-100 m-2">Registration page</Link>
        </div>
      </Form>
    </div>
  );
} 