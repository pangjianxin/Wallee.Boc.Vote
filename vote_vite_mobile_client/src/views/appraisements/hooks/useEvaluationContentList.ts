import {
  EvaluationContentDto,
  EvaluationContentService,
  EvaluationCategory,
} from "/@/openapi";

export const useEvaluationContentList = () => {
  let evaContentList = ref<EvaluationContentDto[]>([]);

  const getEvaContentList = async (category: EvaluationCategory) => {
    evaContentList.value =
      await EvaluationContentService.evaluationContentGetListByCategory({
        category,
      });
  };

  return { evaContentList, getEvaContentList };
};
