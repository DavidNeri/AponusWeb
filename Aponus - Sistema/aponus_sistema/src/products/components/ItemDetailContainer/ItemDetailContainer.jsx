import React, { useEffect } from 'react'
import { useSelector } from 'react-redux';
import { useParams } from 'react-router-dom'
import { useProductStore } from '../../../hooks/useProductStore';

export const ItemDetailContainer = () => {

    const {typeProductId} = useParams()
    const {startOnSetProductDiamater,startOnSetProductActive,startOnSetProductNominal}= useProductStore();

    const {productNominal,productActive,productDiameter} = useSelector(state => state.product);

    useEffect(() => {
        startOnSetProductNominal(typeProductId)
    
    }, [typeProductId])
    
    const onchangeProductNominal =(e)=>{
        if(e.target.value === 'Seleccionar Nominal') return;
        const search={
            productNominal:e.target.value,
            typeProductId
        }
        startOnSetProductDiamater(search);
    }
    
    const onChangeProductDiamater=(e)=>{
        
        startOnSetProductActive(e.target.value);
    }

    const onAddQuantity = (quantity) => {

    }


  return (
    <>
        <select name="productsNominal" onChange={onchangeProductNominal}>
            <option key={0}>Seleccionar Nominal</option>
            {
                productNominal?.map(productNominal => (
                    <option 
                        key={productNominal.productDescriptionDn}
                        value={productNominal.productDescriptionDn}
                    >
                        {productNominal.productDescriptionDn}
                    </option>
                ))
            }

        </select>

        <select name="products" onChange={onChangeProductDiamater}>
            <option key={0}>Seleccionar Diametro</option>
            {
                productDiameter?.map(producD => (
                    
                    <option 
                        key={producD.productId}
                        value={producD.productId}
                        >
                        {producD.productDescriptionOutsideDiameter} {producD.productDescriptionInsideDiameter}
                    </option>
                ))
            }
        </select>

        <div>
            Precio y stock 
            {productActive?.price}{productActive?.quantity}
        </div>
    </>
  )
}
