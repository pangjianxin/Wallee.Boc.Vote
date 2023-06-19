import useDarkModeStore from "/@/store/modules/useDarkModeStore";

export function useDarkMode() {
  return useDarkModeStore().darkMode;
}

export function useToggleDarkMode() {
  useDarkModeStore().toggleDarkMode();
}
