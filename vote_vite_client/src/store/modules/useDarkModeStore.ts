import { defineStore } from "pinia";

const useDarkModeStore = defineStore(
  "dark-mode",
  () => {
    let darkMode = ref(false);
    const toggleDarkMode = () => {
      darkMode.value = !darkMode.value;
      if (darkMode.value === true) {
        document.documentElement.classList.add("dark");
      } else {
        document.documentElement.classList.remove("dark");
      }
    };

    return { darkMode, toggleDarkMode };
  },
  {
    persist: {
      storage: localStorage,
      key: "dark-mode",
    },
  }
);

export default useDarkModeStore;
