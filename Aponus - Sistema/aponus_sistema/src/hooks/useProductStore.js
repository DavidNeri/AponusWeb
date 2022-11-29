import { useDispatch } from "react-redux"
import { getCategory } from "../helpers/getCategory";
import { getProducts } from "../helpers/getProducts";
import { onSetCategory, onSetProductActive, onSetProductDiamater, onSetproductNominal, onSetProducts } from "../store/products/productSlice";

export const useProductStore = () => {

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
        console.log(search)
        dispatch(onSetProductDiamater(search));
    }

    const startOnSetProductActive = (id)=>{
        dispatch(onSetProductActive(id));
    }

    return{
        startOnSetProducts,
        startOnSetProductDiamater,
        startOnSetProductActive,
        startOnSetProductNominal,
    }
    
}
