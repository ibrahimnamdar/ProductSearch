import React, { useState, useEffect } from "react";
import { useSelector, useDispatch } from "react-redux";
import "./styles.scss";

export default function OrderSelectBox({ style, onChange }) {
  const orderType = useSelector((state) => state.productReducer.orderType);

  return (
    <div style={style} onChange={onChange}>
      <select
        className="order-select-box"
        value={orderType}
        onChange={onChange}
      >
        <option value="" disabled selected>
          Sıralama
        </option>
        <option value="LowestPrice">En Düsük Fiyat</option>
        <option value="HighestPrice">En Yüksek Fiyat</option>
        <option value="NewAZ">En Yeniler (A&gt;Z)</option>
        <option value="NewZA">En Yeniler (Z&gt;A)</option>
      </select>
    </div>
  );
}
