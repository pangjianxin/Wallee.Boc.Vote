import type { EvaluationContentDto } from "/@/openapi";
import { EvaluationContentService } from "/@/openapi";
import type { Pageable } from "/#/pageable";

export function useEvaluationContentList() {
  const loading = ref(false);
  const filter = ref("");
  const sorting = ref("");
  const list = ref<EvaluationContentDto[]>([]);
  const cachedList = ref<EvaluationContentDto[]>([]);
  const finished = ref(false);
  const pageable = reactive<Pageable>({
    pageNum: 1,
    pageSize: 10,
    total: 0,
  });

  const getList = async () => {
    try {
      const res = await EvaluationContentService.evaluationContentGetList({
        filter: filter.value,
        sorting: sorting.value,
        maxResultCount: pageable.pageSize,
        skipCount: (pageable.pageNum - 1) * pageable.pageSize,
      });
      list.value = res.items ?? [];
      cachedList.value.push(...(res.items ?? []));
      pageable.total = res.totalCount!;
      if (pageable.pageNum * pageable.pageSize >= pageable.total) {
        finished.value = true;
      }
    } catch {
      finished.value = true;
    } finally {
      loading.value = false;
    }
  };

  const clear = () => {
    cachedList.value = [];
    list.value = [];
    pageable.pageNum = 1;
  };

  return {
    loading,
    cachedList,
    finished,
    filter,
    sorting,
    pageable,
    list,
    clear,
    getList,
  };
}
