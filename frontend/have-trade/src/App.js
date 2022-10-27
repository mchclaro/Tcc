import { Route, Routes } from "react-router-dom";
import Footer from "./components/layouts/Footer";
import Home from "./components/layouts/Home";
import Menu from "./components/layouts/Menu";

function App() {
  return (
    <Routes>
        <Route path='/' element={<Home />} />
    </Routes>
  );
}

export default App;
