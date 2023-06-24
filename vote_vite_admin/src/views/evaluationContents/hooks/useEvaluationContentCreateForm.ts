import type { FieldRule, FormInstance } from 'vant'

import type {
  EvaluationContentCreateDto,
  EvaluationContentDto,
} from '/@/openapi'
import {
  EvaluationCategory,
  EvaluationContentService,
} from '/@/openapi'

import { notify, toast } from '/@/utils/app'

export function useEvlauationContentCreateForm() {
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
  const form = reactive<EvaluationContentCreateDto>({
    category: EvaluationCategory.部门评价,
  })

  const clearForm = () => {
    form.category = EvaluationCategory.部门评价
    form.name = ''
    form.description = ''
  }

  const createEvaluationContent = async (): Promise<
    EvaluationContentDto | undefined
  > => {
    try {
      await formRef.value?.validate()
      loading.value = true
      const res = await EvaluationContentService.evaluationContentCreate({
        requestBody: form,
      })
      notify('创建成功')
      clearForm()
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
  return { loading, formRef, formRules, form, createEvaluationContent }
}
