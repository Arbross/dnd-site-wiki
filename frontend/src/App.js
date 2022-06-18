import { Route, Routes } from 'react-router-dom';
import './App.css';
import Login from './components/auth_pages/login';
import Register from './components/auth_pages/register';
import Unauthorized from './components/auth_pages/unauthorized';
import RequireAuth from './components/auth_pages/requireAuth';
import Home from './components/home';
import Missing from './components/missing';
import Layout from './components/page_parts/layout';

import Spells from './components/info_pages/spells/spells';
import Items from './components/info_pages/items/items';
import Organizations from './components/info_pages/organizations/organizations';
import Profile from './components/profile/profile';
import AddItem from './components/info_pages/items/add-item';
import AddOrganization from './components/info_pages/organizations/add-organization';
import AddSpell from './components/info_pages/spells/add-spell';
import ItemDetails from './components/info_pages/items/item-details';
import SpellDetails from './components/info_pages/spells/spell-details';
import OrganizationDetails from './components/info_pages/organizations/organization-details';
import Characters from './components/profile/characters/characters';
import AddCharacter from './components/profile/characters/add-character';

export const ROLES = {
  'Player': "Player",
  'Master': "Master"
}

export default function App() {
  return (
    <Routes>
      <Route path="/" element={<Layout />}>
        {/* public routes */}
        <Route path="/login" element={<Login />} />
        <Route path="/register" element={<Register />} />
        <Route path="/unauthorized" element={<Unauthorized />} />

        {/* we want to protect these routes */}
        <Route element={<RequireAuth allowedRoles={[ROLES.Player]} />}>
          <Route exact path="/profile" element={<Profile />}/>
          <Route path="/profile/characters" element={<Characters />} />
          <Route path="/profile/add-character" element={<AddCharacter />} />
          <Route path="/home" element={<Home />} />
          <Route path="/spells" element={<Spells />} />
          <Route path="/items" element={<Items />} />
          <Route path="/add-item" element={<AddItem />} />
          <Route path="/add-organization" element={<AddOrganization />} />
          <Route path="/add-spell" element={<AddSpell />} />
          <Route path="/item-details/:id" element={<ItemDetails />} />
          <Route path="/spell-details/:id" element={<SpellDetails />} />
          <Route path="/organization-details/:id" element={<OrganizationDetails />} />
          <Route path="/organizations" element={<Organizations />} />
        </Route>

        <Route element={<RequireAuth allowedRoles={[ROLES.Master]} />}>
          {/* <Route path="admin" element={<Admin />} /> */}
        </Route>

        {/* catch all */}
        <Route path="*" element={<Missing />} />
      </Route>
    </Routes>
  );
}
