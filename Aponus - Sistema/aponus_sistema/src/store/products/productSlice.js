import { createSlice } from '@reduxjs/toolkit'
export const productSlice = createSlice({
    name: 'product',
    initialState: {
        isLoading:false,
        cart:null,
        products:[],
        categorys:[],
        productActive:null,
        productDiameter:null,
        productNominal:null,
        isSaving:'',
        quantityProduct:0,
        quantityCart:0
    },
    reducers: { 

        startLoadingProduct:(state)=>{

        },

        onSetProducts:(state,{payload})=>{
            state.products = payload;
        },

        onSetCategory:(state,{payload})=>{
            state.categorys = payload
        },
        onSetproductNominal:(state,{payload})=>{
            state.productNominal = state.products.filter(product => product.categoryId === payload);
            state.productNominal = state.productNominal.map(prodNom => {
                return prodNom.productDescriptionDn
            });
            state.productNominal = [...new Set(state.productNominal)];
            state.productNominal = state.productNominal.map(prodNom => {
                return {
                    productDescriptionDn: prodNom
                }
            })
        },

        onSetProductDiamater:(state,{payload})=>{
            console.log(payload);
            state.productDiameter = state.products.filter(productNom => 
                                                productNom.productDescriptionDn.toString() === payload.productNominal.toString()
                                                && productNom.categoryId.toString() === payload.typeProductId.toString());
        },
        addCartProduct:(state,{payload})=>{
            
        },

        onSetProductActive:(state,{payload})=>{
            state.productActive = state.products.find(product => product.productId.toString() === payload.toString());
        },

        onGetQuantityCart:(state)=>{
            let quantityCart = 0;
            state.cart.forEach()
        },

        onDeleteProductCart:(state,{payload})=>{
            state.cart = state.cart.filter(c => c.idProduct !== payload);
        },

        onAddCartProduct:(state,{payload})=>{

            const productExist = state.cart.filter(c => c.idProduct !== payload.idProduct);
            state.cart = [...productExist,payload];

        },


    }
})


    export const {
        onSetProducts,
        onSetproductNominal,
        addCartProduct,
        getQuantityCart,
        startLoadingProduct, 
        OndeleteProductCart,
        onSetCategory,
        onSetProductActive,
        onSetProductDiamater,
        onAddCartProduct
        
    
    } = productSlice.actions