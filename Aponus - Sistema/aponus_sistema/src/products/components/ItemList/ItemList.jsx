import React, { useEffect } from 'react'
import { useSelector } from 'react-redux';
import { useProductStore } from '../../../hooks/useProductStore'
import { Item } from '../Item/Item';
export const ItemList = () => {

   const {startOnSetProducts,startOnSetProductDiamater,startOnSetProductActive}= useProductStore();

   const {categorys} = useSelector(state => state.product);

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

        // {/* <select name="productsNominal" onChange={onchangeProductNominal}>
        //     <option key={0}>Seleccionar Nominal</option>
        //     {
        //         productNominal?.map(productNominal => (
        //             <option 
        //                 key={productNominal.productId}
        //                 value={productNominal.productDescriptionDn}
        //             >
        //                 {productNominal.productDescriptionDn}
        //             </option>
        //         ))
        //     }
        // </select>
        // <select name="products" onChange={onChangeProductDiamater}>
        //     <option key={0}>Seleccionar Diametro</option>
        //     {
        //         productDiameter?.map(producD => (
                    
        //             <option 
        //                 key={producD.productId}
        //                 value={producD.productId}
        //                 >
        //                 {producD.productDescriptionOutsideDiameter} {producD.productDescriptionInsideDiameter}
        //             </option>
        //         ))
        //     }
        // </select>

        // <div>

        //     Precio y stock 
        //     {productActive?.price}{productActive?.quantity}
        // </div> */}
  )
}
