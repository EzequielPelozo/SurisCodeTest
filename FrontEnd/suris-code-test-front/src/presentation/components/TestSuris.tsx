import { useEffect } from 'react'
import { useCategoryStore } from '../store/categories/useCategoryStore'

export const TestSuris = () => {

 const { categories, getAllCategory } = useCategoryStore();

  useEffect(() => {
    getAllCategories();
  },[])

  const getAllCategories = async() => {
    await getAllCategory();
  }


  return (
    <>
    {
        JSON.stringify(categories)
    }
    </>
  )
}
