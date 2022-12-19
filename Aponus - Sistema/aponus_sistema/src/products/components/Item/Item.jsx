import React from 'react'
import { NavLink } from 'react-router-dom'
import './_Item.scss'
export const Item = ({categoryId,categoryDescription}) => {
  return (
    <div key={categoryId}>
    <div className="product">
            <img src="" alt={categoryDescription} width="280px" height="280px" />
            <div className="product__info">
                <span className="product__send">Envío con normalidad</span>
                <span className="product__costo">Envío gratis</span>
                <span className="product__description">{categoryDescription}</span>
                <div className="product__assessment">
                </div>
                <NavLink to={`/details/${categoryId}`}>
                    Detalle
                </NavLink>
        </div>
    </div>
</div>
  )
}
