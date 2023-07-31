import { FormInstance, FieldRule } from "vant";
import { AppraisementService } from "/@/openapi";

export const useUploadQrcodeBackgroundImageForm = () => {
  let form = reactive({
    File: undefined,
  });
  let formRef = ref<FormInstance>();

  let formRules = ref<Record<string, FieldRule[]>>({
    file: [{ required: true }],
  });

  const uploadQrcodeBackgroundImage = async () => {
    AppraisementService.appraisementUploadQrcodeBackgroundImage({
      formData: form,
    });
  };

  return { form, formRef, formRules, uploadQrcodeBackgroundImage };
};
