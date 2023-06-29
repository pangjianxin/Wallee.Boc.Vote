import { reactive } from 'vue'
import type { FieldRule, FormInstance } from 'vant'
import type { CancelablePromise } from '/@/openapi/core/CancelablePromise'
import { request as __request } from '/@/openapi/core/request'
import { OpenAPI } from '/@/openapi/core/OpenAPI'
import { toast } from '/@/utils/app'

export interface PasswordLogin {
  username: string
  password: string
  grant_type: string
  client_id: string
  scope: string
}

export function useLogin() {
  const loading = ref(false)
  const formRef = ref<FormInstance>()

  const form = reactive<PasswordLogin>({
    username: '',
    password: '',
    grant_type: import.meta.env.VITE_OIDC_GRANT_TYPE_PASSWORD,
    client_id: import.meta.env.VITE_OIDC_CLIENT_ID,
    scope: import.meta.env.VITE_OIDC_SCOPE,
  })

  const formRules = reactive<Record<string, FieldRule[]>>({
    username: [
      {
        required: true,
        message: '请输入你的用户名',
        trigger: 'onChange',
      },
    ],
    password: [
      {
        required: true,
        message: '请输入你的密码',
        trigger: 'onChange',
      },
    ],
  })

  const passwordLogin = async () => {
    try {
      await formRef.value?.validate()
      loading.value = true
      return await __request<
        CancelablePromise<{
          access_token: string
          token_type: string
          id_token: string
          expires_in: number
        }>
      >(OpenAPI, {
        method: 'POST',
        url: '/connect/token',
        body: form,
        mediaType: 'application/x-www-form-urlencoded',
        errors: {
          400: 'Bad Request',
          401: 'Unauthorized',
          403: 'Forbidden',
          404: 'Not Found',
          500: 'Server Error',
          501: 'Server Error',
        },
      })
    }
    catch (err: any) {
      toast(err.message)
      return undefined
    }
    finally {
      loading.value = false
    }
  }

  function getUserInfo() {
    return __request(OpenAPI, {
      method: 'GET',
      url: '/connect/userinfo',
      errors: {
        400: 'Bad Request',
        401: 'Unauthorized',
        403: 'Forbidden',
        404: 'Not Found',
        500: 'Server Error',
        501: 'Server Error',
      },
    })
  }

  return {
    formRef,
    loading,
    form,
    formRules,
    passwordLogin,
    getUserInfo,
  }
}
