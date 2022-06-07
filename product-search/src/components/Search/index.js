import React, { useState, useEffect } from "react";
import { connect, useDispatch, useSelector } from "react-redux";
import "./styles.scss";
import { SET_SEARCH_QUERY } from "../../constants";

export default function Search() {
  const dispatch = useDispatch();

  const handleChange = (e) => {
    const value = e.target.value;
    dispatch({
      type: SET_SEARCH_QUERY,
      searchQuery: value,
    });
  };

  return (
    <input
      onChange={handleChange}
      className="search-input"
      placeholder="25 milyon’dan fazla ürün içerisinde ara"
    />
  );
}
