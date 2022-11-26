import { createSlice } from '@reduxjs/toolkit'
export const productSlice = createSlice({
    name: 'product',
    initialState: {
        isLoading:false,
        cart:null,
        products:[],
        productActive:null,
        productNominal:null,
        isSaving:'',
        quantityProduct:0,
        quantityCart:0
    },
    reducers: { 

        startLoadingProduct:(state)=>{

        },

        onSetProducts:(state,{payload})=>{

        },

        onSetproduct:(state,{payload})=>{

        },

        addCartProduct:(state,{payload})=>{

        },

        getQuantityCart:(state)=>{
            
        },

        deleteProductCart:(state,{payload})=>{

        }
    }
})


    export const {
        onSetProducts,
        onSetproduct,
        addCartProduct,
        getQuantityCart,
        startLoadingProduct, 
        deleteProductCart,
    
    } = productSlice.actions