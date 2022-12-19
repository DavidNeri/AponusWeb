import React from 'react'
import { Provider } from 'react-redux'
import { BrowserRouter } from 'react-router-dom'
import { ProductPage } from './products/pages/ProductPage'
import { AppRouter } from './router/AppRouter'
import { store } from './store/store'

export const ProductApp = () => {
  return (
    <Provider store={store}>
        <BrowserRouter>
          <AppRouter/>{/* Cambiar esto al route app */}
        </BrowserRouter>
    </Provider>
  )
}
