import { ref } from 'vue'
import { defineStore } from 'pinia'
import { COOKIES } from '../consts/cacheKey'

export default defineStore(
  'antiforgery',
  () => {
    const antiforgery = ref('')
    function getAntiforgery() {
      return antiforgery.value
    }

    function setAntiforgery(value: string) {
      antiforgery.value = value
    }

    return {
      antiforgery,
      getAntiforgery,
      setAntiforgery,
    }
  },
  {
    persist: {
      key: COOKIES,
    },
  },
)
