import React from 'react'

export const getCategory = async() => {
    const resp = await fetch('https://localhost:7038/Aponus/Categories/ListCategories')
    const data = await resp.json();

    return data
}
