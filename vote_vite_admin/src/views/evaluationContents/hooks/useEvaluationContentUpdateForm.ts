import type { FieldRule, FormInstance } from 'vant'
import type {
  EvaluationContentDto,
  EvaluationContentUpdateDto,
} from '/@/openapi'
import {
  EvaluationContentService,
} from '/@/openapi'

import { notify, toast } from '/@/utils/app'

export function useEvlauationContentUpdateForm() {
  const loading = ref(false)
  const formRef = ref<FormInstance>()
  const formRules = reactive<Record<string, FieldRule[]>>({
    name: [
      {
        required: true,
        message: '请输入名称',
        trigger: 'onBlur',
      },
    ],
    description: [
      {
        required: true,
        message: '请输入描述',
        trigger: 'onBlur',
      },
    ],
    category: [
      {
        required: true,
        message: '请选择类型',
        trigger: 'onBlur',
      },
    ],
  })
  const form = reactive<EvaluationContentUpdateDto>({})

  const updateEvaluationContent = async (
    evaluationContentId: string,
  ): Promise<EvaluationContentDto | undefined> => {
    try {
      await formRef.value?.validate()
      loading.value = true
      const res = await EvaluationContentService.evaluationContentUpdate({
        id: evaluationContentId,
        requestBody: form,
      })
      notify('更新成功')
      return res
    }
    catch (error: any) {
      toast(error)
      return undefined
    }
    finally {
      loading.value = false
    }
  }
  return { loading, formRef, formRules, form, updateEvaluationContent }
}
