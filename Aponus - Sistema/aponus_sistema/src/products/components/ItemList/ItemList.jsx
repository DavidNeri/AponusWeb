import React, { useEffect } from 'react'
import { useSelector } from 'react-redux';
import { useProductStore } from '../../../hooks/useProductStore'
import { Item } from '../Item/Item';
export const ItemList = () => {

   const {startOnSetProducts,categorys}= useProductStore();

   

   useEffect(() => {
    startOnSetProducts();
   }, [])
   
  
  return (
       <div className='product-grid'>
                {
                    categorys.map(category => (
                        <Item key={category.categoryId} {...category}/>
                    ))
                }
       </div>
  )
}
