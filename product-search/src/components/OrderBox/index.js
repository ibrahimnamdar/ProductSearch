import React, { useState, useEffect } from "react";
import "./styles.scss";
import { useSelector, useDispatch } from "react-redux";
import { SET_ORDER } from "../../constants";

export default function OrderBox({ orderType, style, onClick, status }) {
  const dispatch = useDispatch();
  orderType = useSelector((state) => state.productReducer.orderType);

  const handleClick = (e) => {
    dispatch({
      type: SET_ORDER,
      orderType: e.target.getAttribute("data-value"),
    });
  };

  return (
    <div style={style} onClick={onClick}>
      <p className="filter-header">Sıralama</p>
      <div className="filter-body">
        <p
          className={
            orderType == "LowestPrice" ? "filter-item active" : "filter-item"
          }
          data-value="LowestPrice"
          onClick={handleClick}
        >
          En Düsük Fiyat
        </p>
        <p
          className={
            orderType == "HighestPrice" ? "filter-item active" : "filter-item"
          }
          data-value="HighestPrice"
          onClick={handleClick}
        >
          En Yüksek Fiyat
        </p>
        <p
          className={
            orderType == "NewAZ" ? "filter-item active" : "filter-item"
          }
          data-value="NewAZ"
          onClick={handleClick}
        >
          En Yeniler (A&gt;Z)
        </p>
        <p
          className={
            orderType == "NewZA" ? "filter-item active" : "filter-item"
          }
          data-value="NewZA"
          onClick={handleClick}
        >
          En Yeniler (Z&gt;A)
        </p>
      </div>
    </div>
  );
}
