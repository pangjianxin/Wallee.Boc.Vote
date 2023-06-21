import { EvaluationContentService, EvaluationContentDto } from "/@/openapi";
import { Pageable } from "/#/pageable";

export const useEvaluationContentList = () => {
  let loading = ref(false);
  let filter = ref("");
  let sorting = ref("");
  let list = ref<EvaluationContentDto[]>([]);
  let cachedList = ref<EvaluationContentDto[]>([]);
  let finished = ref(false);
  let pageable = reactive<Pageable>({
    pageNum: 1,
    pageSize: 10,
    total: 0,
  });

  const getList = async () => {
    try {
      let res = await EvaluationContentService.evaluationContentGetList({
        filter: filter.value,
        sorting: sorting.value,
        maxResultCount: pageable.pageSize,
        skipCount: (pageable.pageNum - 1) * pageable.pageSize,
      });
      list.value = res.items ?? [];
      cachedList.value.push(...(res.items ?? []));
      pageable.total = res.totalCount!;
      if (res.items?.length === 0) {
        finished.value = true;
      }
    } finally {
      loading.value = false;
    }
  };

  return {
    loading,
    cachedList,
    finished,
    filter,
    sorting,
    pageable,
    list,
    getList,
  };
};
