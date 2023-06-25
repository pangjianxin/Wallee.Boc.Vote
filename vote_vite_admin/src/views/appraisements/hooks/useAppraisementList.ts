import type { AppraisementDto } from "/@/openapi";
import { AppraisementService } from "/@/openapi";
import type { Pageable } from "/#/pageable";

export function useAppraisementList() {
  const loading = ref(false);
  const filter = ref("");
  const sorting = ref("");
  const list = ref<AppraisementDto[]>([]);
  const cachedList = ref<AppraisementDto[]>([]);
  const finished = ref(false);
  const pageable = reactive<Pageable>({
    pageNum: 1,
    pageSize: 10,
    total: 0,
  });

  const getList = async () => {
    try {
      const res = await AppraisementService.appraisementGetList({
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
    } catch {
      finished.value = true;
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
}
