import { Routes, Route } from "react-router-dom";
import { HomePage } from "./components/homePage/components.homePage";
import { About } from "./components/About/components.About";
import { AllProducts } from "./components/allProducts/components.allProducts";
import { ContactUs } from "./components/contactUs/components.contactUs";
import "./App.css";
import { NavBar } from "./components/navBar/components.navBar";

function App() {
  return (
    <div className="App">
      <NavBar></NavBar>
      <Routes>
        <Route path="/" element={<HomePage></HomePage>}></Route>
        <Route path="/about" element={<About></About>}></Route>
        <Route
          path="/allProducts"
          element={<AllProducts></AllProducts>}
        ></Route>
        <Route path="/contactUs" element={<ContactUs></ContactUs>}></Route>
      </Routes>
    </div>
  );
}

export default App;
