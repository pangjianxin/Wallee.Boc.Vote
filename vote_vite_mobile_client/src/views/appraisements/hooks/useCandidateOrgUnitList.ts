import { CandidateOrgUnitDto, CandidateOrgUnitService } from "/@/openapi";
import orgOrderJson from "/@/views/appraisements/evaluation/orgOrder.json";

const orgOrder = orgOrderJson.orders;

export const useCandidateOrgUnitList = () => {
  let orgUnitCandidateList = ref<CandidateOrgUnitDto[]>([]);
  const getOrgUnitCandidateList = async () => {
    orgUnitCandidateList.value =
      await CandidateOrgUnitService.candidateOrgUnitGetCandidateOrgUnitEvaList();
    orgUnitCandidateList.value.sort(
      (a, b) =>
        orgOrder.find((it) => it.code === a.organCode)?.value! -
        orgOrder.find((it) => it.code === b.organCode)?.value!
    );
  };
  return { orgUnitCandidateList, getOrgUnitCandidateList };
};
