import React from "react";
import logo from "./logo.svg";
import "./App.css";
import ProductList from "./screens/ProductList";
import NavBar from "./components/NavBar";
import { BrowserRouter, Routes, Route, Link } from "react-router-dom";
import "typeface-roboto";

function App() {
  return (
    <div className="App">
      <NavBar />
      <BrowserRouter>
        <Routes>
          <Route path="/" element={<App />} />
          <Route index element={<ProductList />} />
        </Routes>
      </BrowserRouter>
    </div>
  );
}

export default App;
