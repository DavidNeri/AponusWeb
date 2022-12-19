import React from 'react'
import { useProductStore } from '../../../hooks/useProductStore'

export const CartItem = ({
    quantityCompra,
    productId,
    productDescriptionName,
    productDescriptionDn,
    productDescriptionOutsideDiameter,
    productDescriptionInsideDiameter,
    price}) => {

      const {startOnDeleteProduct} = useProductStore();

      const handleProductDelete = (productId)=>{
        startOnDeleteProduct(productId)
      }

  return (
    <div>
      <p>{quantityCompra}</p>
      <p>{productId}</p>
      <p>{productDescriptionName}</p>
      <p>{price}</p>
      <button onClick={() => handleProductDelete(productId)} >ELIMINAR</button>
      <br/>
      <hr />
    </div>
  )
}
