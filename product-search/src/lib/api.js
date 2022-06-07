const baseUrl = "https://localhost:7170/api";

export async function getfilteredProducts(data) {
  const settings = {
    method: "POST",
    headers: {
      Accept: "application/json",
      "Content-Type": "application/json",
    },
    body: JSON.stringify(data),
  };
  const response = await fetch(`${baseUrl}/product/filterproducts`, settings);
  return response.json();
}
