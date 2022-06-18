import { useRef, useState } from 'react';
import { ButtonGroup, Form, FormControl, InputGroup, Button } from 'react-bootstrap';
import { Link, useNavigate } from 'react-router-dom';
import { CreateItem } from '../../../api/itemAxios';
import './add-item.css';

const AddItem = () => {
    const nameRef = useRef();
    const typeRef = useRef();
    const costRef = useRef();
    const weightRef = useRef();
    const descriptionRef = useRef();
    const rarityRef = useRef();
    const effectRef = useRef();
    const imageRef = useRef();

    const navigate = useNavigate();
    const [errorMessage, setErrorMessage] = useState("");

    const submitHandler = async (event) => {
        event.preventDefault();

        try {
          const response = await CreateItem({ name: nameRef.current.value, 
            type: typeRef.current.value,
            cost: costRef.current.value,
            weight: weightRef.current.value,
            description: descriptionRef.current.value,
            rarity: rarityRef.current.value,
            effect: effectRef.current.value,
            image: imageRef.current.value
          }, sessionStorage.getItem('token'));
    
          if (response.status === 200)
          {
            navigate("/items");
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
            <h2 className='text-center'>Add Item</h2>
            <form onSubmit={submitHandler} className='d-flex flex-column align-items-center container'>
                <InputGroup className='m-2'>
                  <FormControl
                    placeholder="Enter name"
                    aria-label="Enter name"
                    type="text" ref={nameRef} required
                  />
                </InputGroup>
                <Form.Select aria-label="Type selection" ref={typeRef} className='m-2' required>
                  <option disabled selected>Select...</option>
                  <option defaultValue="Armor">Armor</option>
                  <option defaultValue="Potion">Potion</option>
                  <option defaultValue="Ring">Ring</option>
                  <option defaultValue="Rod">Rod</option>
                  <option defaultValue="Scroll">Scroll</option>
                  <option defaultValue="Staff">Staff</option>
                  <option defaultValue="Wand">Wand</option>
                  <option defaultValue="Weapon">Weapon</option>
                  <option defaultValue="Wondrous">Wondrous</option>
                </Form.Select>
                <InputGroup className='m-2'>
                  <FormControl
                    placeholder="Enter cost"
                    aria-label="Enter cost"
                    type="number" min="0" ref={costRef} required
                  />
                </InputGroup>
                <Form.Select aria-label="Rarity selection" className='m-2' ref={rarityRef} required>
                  <option disabled selected>Select...</option>
                  <option defaultValue="Common">Common</option>
                  <option defaultValue="Uncommon">Uncommon</option>
                  <option defaultValue="Rare">Rare</option>
                  <option defaultValue="Very_Rare">Very Rare</option>
                  <option defaultValue="Legendary">Legendary</option>
                  <option defaultValue="Artifact">Artifact</option>
                  <option defaultValue="Varies">Varies</option>
                  <option defaultValue="Unknown_Rarity">Unknown Rarity</option>
                </Form.Select>
                <InputGroup className='m-2'>
                  <FormControl
                    placeholder="Enter weight"
                    aria-label="Enter weight"
                    type="number" min="0" ref={weightRef} required
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
                    placeholder="Enter effect"
                    aria-label="Enter effect"
                    type="text" ref={effectRef} required
                  />
                </InputGroup>
                <InputGroup className='m-2'>
                  <FormControl
                    placeholder="Enter image"
                    aria-label="Enter image"
                    type="text" ref={imageRef} required
                  />
                </InputGroup>
                <label className='error-register-message'>{errorMessage}</label>
                <ButtonGroup className='m-2' aria-label="Button submit">
                  <Button type="submit">Add Item</Button>
                </ButtonGroup>
                <Link to="/items" className="item-add-to-items-link">Back to items</Link> 
            </form>
        </div>
    );
}

export default AddItem;