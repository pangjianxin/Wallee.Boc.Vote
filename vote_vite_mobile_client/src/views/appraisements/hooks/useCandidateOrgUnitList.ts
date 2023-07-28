import { CandidateOrgUnitDto, CandidateOrgUnitService } from "/@/openapi";

export const useCandidateOrgUnitList = () => {
  let list = ref<CandidateOrgUnitDto[]>([]);
  const getList = async () => {
    list.value =
      await CandidateOrgUnitService.candidateOrgUnitGetCandidateOrgUnitEvaList();
  };
  return { list, getList };
};
