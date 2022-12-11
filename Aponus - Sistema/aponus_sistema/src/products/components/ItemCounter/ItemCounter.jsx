import React, { useEffect, useState } from 'react'

export const ItemCounter = ({onAddQuantity,initialValue=1,stock}) => {


  const [counter, setCounter] = useState(initialValue)
  
  useEffect(() => {
    setCounter(initialValue)
  
  }, [initialValue])
  

  const handleAdd = ()=>{
    setCounter(counter + 1);
  }

  const handleDecrease = () => {
    setCounter(counter - 1);
  }


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
