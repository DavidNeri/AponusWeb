import React from 'react'
import { Route, Routes } from 'react-router-dom'
import { ItemList, NavBar, TopBar } from '../products/components'
import { ItemDetailContainer } from '../products/components/ItemDetailContainer/ItemDetailContainer'
import { ProductPage } from '../products/pages/ProductPage'


export const AppRouter = () => {
  return (
    <>
      <TopBar/>
      <NavBar/>
    <Routes>
        <Route>
          <Route path="/*" element={<ProductPage/>}/>
          <Route path="/details/:typeProductId" element={<ItemDetailContainer/>}/>
        </Route>
    </Routes>
    </>
  )
}
