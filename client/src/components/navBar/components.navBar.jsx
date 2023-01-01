import React from "react";
import { Link } from "react-router-dom";

export const NavBar = (props) => {
  return (
    <div>
      <ul>
        <li>
          <Link to="/">
            <label>Home</label>
          </Link>
        </li>
        <li>
          <Link to="/about">
            <label>About</label>
          </Link>
        </li>
        <li>
          <Link to="/allProducts">
            <label>All Products</label>
          </Link>
        </li>
        <li>
          <Link to="/contactUs">
            <label>Contact us</label>
          </Link>
        </li>
      </ul>
    </div>
  );
};
