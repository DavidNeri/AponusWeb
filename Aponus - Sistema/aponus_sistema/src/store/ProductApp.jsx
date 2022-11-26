import React from 'react'
import { Provider } from 'react-redux'
import { BrowserRouter } from 'react-router-dom'
import { ProductPage } from '../products/pages/ProductPage'
import { store } from './store'

export const ProductApp = () => {
  return (
    <Provider store={store}>
        <BrowserRouter>
          <ProductPage/>{/* Cambiar esto al route app */}
        </BrowserRouter>
    </Provider>
  )
}
