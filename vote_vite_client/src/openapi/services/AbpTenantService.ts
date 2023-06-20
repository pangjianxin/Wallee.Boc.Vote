/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */
import type { FindTenantResultDto } from '../models/FindTenantResultDto';

import type { CancelablePromise } from '../core/CancelablePromise';
import { OpenAPI } from '../core/OpenAPI';
import { request as __request } from '../core/request';

export class AbpTenantService {

    /**
     * @returns FindTenantResultDto Success
     * @throws ApiError
     */
    public static abpTenantFindTenantByName({
name,
}: {
name: string,
}): CancelablePromise<FindTenantResultDto> {
        return __request(OpenAPI, {
            method: 'GET',
            url: '/api/abp/multi-tenancy/tenants/by-name/{name}',
            path: {
                'name': name,
            },
            errors: {
                400: `Bad Request`,
                401: `Unauthorized`,
                403: `Forbidden`,
                404: `Not Found`,
                500: `Server Error`,
                501: `Server Error`,
            },
        });
    }

    /**
     * @returns FindTenantResultDto Success
     * @throws ApiError
     */
    public static abpTenantFindTenantById({
id,
}: {
id: string,
}): CancelablePromise<FindTenantResultDto> {
        return __request(OpenAPI, {
            method: 'GET',
            url: '/api/abp/multi-tenancy/tenants/by-id/{id}',
            path: {
                'id': id,
            },
            errors: {
                400: `Bad Request`,
                401: `Unauthorized`,
                403: `Forbidden`,
                404: `Not Found`,
                500: `Server Error`,
                501: `Server Error`,
            },
        });
    }

}
