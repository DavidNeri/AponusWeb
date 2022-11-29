import React from 'react'

export const getProducts = async() => {

    const resp = await fetch('https://localhost:7038/Aponus/Products/ListProducts')
    const data = await resp.json();
  
    return data;

}
