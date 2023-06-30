import { AppraisementDto, AppraisementService } from "/@/openapi";
import { toast } from "/@/utils/app";

const useAvailableAppraisementList = () => {
  let list = ref<AppraisementDto[]>([]);
  let loading = ref(false);
  const getAvailableAppraisements = async () => {
    try {
      loading.value = true;
      list.value = await AppraisementService.appraisementGetAllAvailable();
      console.log(list.value);
    } catch (err) {
      toast(err as string);
    } finally {
      loading.value = false;
    }
  };
  return { list, loading, getAvailableAppraisements };
};

export default useAvailableAppraisementList;
