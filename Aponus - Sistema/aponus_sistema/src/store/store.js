import { configureStore} from "@reduxjs/toolkit";
import { authSlice } from "./auth/authSlice";
import { productSlice } from "./products/productSlice";




export const store = configureStore({

    reducer:{
        product: productSlice.reducer,
        auth: authSlice.reducer,
    }
})