import React from 'react'

export const ItemCounter = ({onAddQuantity,initialValue=1,stock}) => {




  return (
    <>
    <div className="itemCounterContainer">

        <button onClick={handleAdd}>+</button>

        <input type="text" value={counter} disabled="false" />
        <button onClick={handleDecrease}>-</button>
    </div>
        <div>
            <button className='btnSucess' onClick={() => onAddQuantity(counter)}>Agregar al carrito</button>
        </div>
    </>
  )
}
