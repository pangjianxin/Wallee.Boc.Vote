import { defineStore } from 'pinia'
import type { RouteLocationNormalized } from 'vue-router'

const useCachedViewStore = defineStore(
  'cached-view',
  () => {
    const cachedViewList = ref<string[]>([])

    const addCachedView = (view: RouteLocationNormalized) => {
      // 不重复添加
      if (cachedViewList.value.includes(view.name as string))
        return
      if (view?.meta?.keepAlive)
        cachedViewList.value.push(view.name as string)
    }
    const delCachedView = (view: RouteLocationNormalized) => {
      const index = cachedViewList.value.indexOf(view.name as string)
      index > -1 && cachedViewList.value.splice(index, 1)
    }
    const delAllCachedViews = () => {
      cachedViewList.value = [] as string[]
    }

    return {
      cachedViewList,
      addCachedView,
      delAllCachedViews,
      delCachedView,
    }
  },
  {
    persist: {
      storage: localStorage,
      key: 'cached-view',
    },
  },
)
export default useCachedViewStore
