import { useDispatch, useSelector } from "react-redux"
import { getCategory } from "../helpers/getCategory";
import { getProducts } from "../helpers/getProducts";
import { onAddCartProduct, OndeleteProductCart, onSetCategory, onSetProductActive, onSetProductDiamater, onSetproductNominal, onSetProducts } from "../store/products/productSlice";

export const useProductStore = () => {
    const {categorys,productNominal,productActive,productDiameter,cart} = useSelector(state => state.product);

    const dispatch = useDispatch();

    const startOnSetProducts= async()=>{
        
        const products = await getProducts();
        dispatch(onSetProducts(products));

        const categorys = await getCategory();
        dispatch(onSetCategory(categorys));

    }

    const startOnSetProductNominal = (typeProductId) =>{
        dispatch(onSetproductNominal(typeProductId));
    }

    const startOnSetProductDiamater = (search)=>{
        dispatch(onSetProductDiamater(search));
    }

    const startOnSetProductActive = (id)=>{
        dispatch(onSetProductActive(id));
    }

    const startOnAddCartProduct = (product)=>{
        dispatch(onAddCartProduct(product));
    }

    const startOnDeleteProduct = (id)=>{
        dispatch(OndeleteProductCart(id));
    }

    return{

        //Propiedades
        categorys,
        productNominal,
        productActive,
        productDiameter,
        cart,
        //Metodos
        startOnSetProducts,
        startOnSetProductDiamater,
        startOnSetProductActive,
        startOnSetProductNominal,
        startOnAddCartProduct,
        startOnDeleteProduct,
    }
    
}
