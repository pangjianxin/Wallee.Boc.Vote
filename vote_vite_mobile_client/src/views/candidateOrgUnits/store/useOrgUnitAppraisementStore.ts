import { defineStore } from "pinia";

export default defineStore(
  "org-unit-appraisement",
  () => {
    let state = reactive<Record<string, string[]>>({});
    const updateState = (appraisementId: string, orgUnitId: string) => {
      state[appraisementId].push(orgUnitId);
    };
    const clearState = () => {
      state = {};
    };
    return { state, updateState, clearState };
  },
  {
    persist: { storage: localStorage },
  }
);
