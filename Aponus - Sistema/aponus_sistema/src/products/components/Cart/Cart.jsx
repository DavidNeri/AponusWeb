import React from 'react'
import { useProductStore } from '../../../hooks/useProductStore';
import { CartItem } from '../CartItem/CartItem';


export const Cart = () => {

    const {cart} = useProductStore();

    console.log(cart);
  return (
    <div>
      carrito
        {
            cart.map(item => (
                <CartItem key={item.productId} {...item}/>
            ))
        }
    </div>
    
  )
}
