import { Route, Routes } from "react-router-dom";
import Home from "./components/layouts/Home";
import Leaflet from "./components/layouts/Leaflet";
import Business from "./components/pages/business/Business";
import BusinessCategory from "./components/pages/business/BusinessCategory";

function App() {
  return (
    <Routes>
        <Route path='/' element={<Home />} />
        <Route path='/business' element={<Business />} />
        <Route path='/business/category' element={<BusinessCategory />} />
        <Route path='/leaflet' element={<Leaflet />} />
    </Routes>
  );
}

export default App;
