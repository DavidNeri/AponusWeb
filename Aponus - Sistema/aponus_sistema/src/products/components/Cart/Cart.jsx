import React from 'react'
import { CartItem } from '../CarItem/CartItem';

export const Cart = () => {

    const {cart} = useProductStore();

  return (
    <div>
        {
            cart.map(item => (
                <CartItem {...item}/>
            ))
        }
    </div>
    
  )
}
