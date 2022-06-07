import { SET_PRODUCTS, SET_ORDER, SET_SEARCH_QUERY } from "../constants";

const initialState = {
  products: [],
  orderType: "",
  searchQuery: "",
};

export default function setBrowserInfo(state = initialState, action) {
  switch (action.type) {
    case SET_PRODUCTS:
      return {
        ...state,
        products: action.products,
      };
    case SET_ORDER:
      return {
        ...state,
        orderType: action.orderType,
      };
    case SET_SEARCH_QUERY:
      return {
        ...state,
        searchQuery: action.searchQuery,
      };
    default:
      return state;
  }
}
