import { CandidateOrgUnitDto, CandidateOrgUnitService } from "/@/openapi";

export const useCandidateOrgUnitList = () => {
  let orgUnitCandidateList = ref<CandidateOrgUnitDto[]>([]);
  const getOrgUnitCandidateList = async () => {
    orgUnitCandidateList.value =
      await CandidateOrgUnitService.candidateOrgUnitGetCandidateOrgUnitEvaList();
  };
  return { orgUnitCandidateList, getOrgUnitCandidateList };
};
