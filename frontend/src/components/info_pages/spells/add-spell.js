import { useRef, useState } from 'react';
import { ButtonGroup, Form, FormControl, InputGroup, Button } from 'react-bootstrap';
import { Link, useNavigate } from 'react-router-dom';
import { CreateSpell } from '../../../api/spellAxios';
import './add-spell.css';

const AddSpell = () => {
    const nameRef = useRef();
    const levelRef = useRef();
    const areaRef = useRef();
    const componentsRef = useRef();
    const damageTypeRef = useRef();
    const durationRef = useRef();
    const castingTimeByActionsRef = useRef();
    const descriptionRef = useRef();

    const navigate = useNavigate();
    const [errorMessage, setErrorMessage] = useState("");

    const submitHandler = async (event) => {
        event.preventDefault();

        try {
          const response = await CreateSpell({ name: nameRef.current.value, 
            level: levelRef.current.value,
            area: areaRef.current.value,
            components: componentsRef.current.value,
            damageType: damageTypeRef.current.value,
            duration: durationRef.current.value,
            castingTimeByActions: castingTimeByActionsRef.current.value,
            description: descriptionRef.current.value
          }, sessionStorage.getItem('token'));
    
          if (response.status === 200)
          {
            navigate("/spells");
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
            <h2 className='text-center'>Add Spell</h2>
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
                    placeholder="Enter level"
                    aria-label="Enter level"
                    min={0} max={10}
                    type="number" ref={levelRef} required
                  />
                </InputGroup>
                <InputGroup className='m-2'>
                  <FormControl
                    placeholder="Enter area"
                    aria-label="Enter area"
                    type="number" min="0" ref={areaRef} required
                  />
                </InputGroup>
                <InputGroup className='m-2'>
                  <FormControl
                    placeholder="Enter components (A, B, M, T)"
                    aria-label="Enter components (A, B, M, T)"
                    type="text" ref={componentsRef} required
                  />
                </InputGroup>
                <Form.Select aria-label="Damage type selection" ref={damageTypeRef} className='m-2' required>
                  <option disabled selected>Select...</option>
                  <option defaultValue="Abjuration">Abjuration</option>
                  <option defaultValue="Alteration">Alteration</option>
                  <option defaultValue="Conjuration">Conjuration</option>
                  <option defaultValue="Divination">Divination</option>
                  <option defaultValue="Enchantment">Enchantment</option>
                  <option defaultValue="Illusion">Illusion</option>
                  <option defaultValue="Invocation">Invocation</option>
                  <option defaultValue="Necromancy">Necromancy</option>
                </Form.Select>
                <InputGroup className='m-2'>
                  <FormControl
                    placeholder="Enter duration"
                    aria-label="Enter duration"
                    type="number" min={0} ref={durationRef} required
                  />
                </InputGroup>
                <InputGroup className='m-2'>
                  <FormControl
                    placeholder="Enter description"
                    aria-label="Enter description"
                    type="text" ref={descriptionRef} required
                  />
                </InputGroup>
                <InputGroup className='m-2'>
                  <FormControl
                    placeholder="Enter casting time by actions"
                    aria-label="Enter casting time by actions"
                    type="number" min={0} ref={castingTimeByActionsRef} required
                  />
                </InputGroup>
                <label className='error-register-message'>{errorMessage}</label>
                <ButtonGroup className='m-2' aria-label="Button submit">
                  <Button type="submit">Add Spell</Button>
                </ButtonGroup>
                <Link to="/spells" className="spell-add-to-spells-link">Back to spells</Link> 
            </form>
        </div>
    );
}

export default AddSpell;