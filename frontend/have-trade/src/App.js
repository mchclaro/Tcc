import { Route, Routes } from "react-router-dom";
import Home from "./components/layouts/Home";
import Leaflet from "./components/layouts/Leaflet";
import Business from "./components/pages/business/Business";

function App() {
  return (
    <Routes>
        <Route path='/' element={<Home />} />
        <Route path='/business' element={<Business />} />
        <Route path='/leaflet' element={<Leaflet />} />
    </Routes>
  );
}

export default App;
