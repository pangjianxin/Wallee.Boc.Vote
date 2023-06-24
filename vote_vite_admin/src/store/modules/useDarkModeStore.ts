import { defineStore } from 'pinia'

export default defineStore(
  'dark-mode',
  () => {
    const darkMode = ref(false)
    const toggleDarkMode = () => {
      darkMode.value = !darkMode.value
      if (darkMode.value === true)
        document.documentElement.classList.add('dark')
      else
        document.documentElement.classList.remove('dark')
    }

    return { darkMode, toggleDarkMode }
  },
  {
    persist: {
      storage: localStorage,
      key: 'dark-mode',
    },
  },
)
