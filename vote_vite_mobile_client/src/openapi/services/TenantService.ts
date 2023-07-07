/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */
import type { PagedResultDtoOfTenantDto } from '../models/PagedResultDtoOfTenantDto';
import type { TenantCreateDto } from '../models/TenantCreateDto';
import type { TenantDto } from '../models/TenantDto';
import type { TenantUpdateDto } from '../models/TenantUpdateDto';

import type { CancelablePromise } from '../core/CancelablePromise';
import { OpenAPI } from '../core/OpenAPI';
import { request as __request } from '../core/request';

export class TenantService {

    /**
     * @returns TenantDto Success
     * @throws ApiError
     */
    public static tenantGet({
id,
}: {
id: string,
}): CancelablePromise<TenantDto> {
        return __request(OpenAPI, {
            method: 'GET',
            url: '/api/multi-tenancy/tenants/{id}',
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

    /**
     * @returns TenantDto Success
     * @throws ApiError
     */
    public static tenantUpdate({
id,
requestBody,
}: {
id: string,
requestBody?: TenantUpdateDto,
}): CancelablePromise<TenantDto> {
        return __request(OpenAPI, {
            method: 'PUT',
            url: '/api/multi-tenancy/tenants/{id}',
            path: {
                'id': id,
            },
            body: requestBody,
            mediaType: 'application/json',
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
     * @returns any Success
     * @throws ApiError
     */
    public static tenantDelete({
id,
}: {
id: string,
}): CancelablePromise<any> {
        return __request(OpenAPI, {
            method: 'DELETE',
            url: '/api/multi-tenancy/tenants/{id}',
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

    /**
     * @returns PagedResultDtoOfTenantDto Success
     * @throws ApiError
     */
    public static tenantGetList({
filter,
sorting,
skipCount,
maxResultCount,
}: {
filter?: string,
sorting?: string,
skipCount?: number,
maxResultCount?: number,
}): CancelablePromise<PagedResultDtoOfTenantDto> {
        return __request(OpenAPI, {
            method: 'GET',
            url: '/api/multi-tenancy/tenants',
            query: {
                'Filter': filter,
                'Sorting': sorting,
                'SkipCount': skipCount,
                'MaxResultCount': maxResultCount,
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
     * @returns TenantDto Success
     * @throws ApiError
     */
    public static tenantCreate({
requestBody,
}: {
requestBody?: TenantCreateDto,
}): CancelablePromise<TenantDto> {
        return __request(OpenAPI, {
            method: 'POST',
            url: '/api/multi-tenancy/tenants',
            body: requestBody,
            mediaType: 'application/json',
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
     * @returns string Success
     * @throws ApiError
     */
    public static tenantGetDefaultConnectionString({
id,
}: {
id: string,
}): CancelablePromise<string> {
        return __request(OpenAPI, {
            method: 'GET',
            url: '/api/multi-tenancy/tenants/{id}/default-connection-string',
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

    /**
     * @returns any Success
     * @throws ApiError
     */
    public static tenantUpdateDefaultConnectionString({
id,
defaultConnectionString,
}: {
id: string,
defaultConnectionString?: string,
}): CancelablePromise<any> {
        return __request(OpenAPI, {
            method: 'PUT',
            url: '/api/multi-tenancy/tenants/{id}/default-connection-string',
            path: {
                'id': id,
            },
            query: {
                'defaultConnectionString': defaultConnectionString,
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
     * @returns any Success
     * @throws ApiError
     */
    public static tenantDeleteDefaultConnectionString({
id,
}: {
id: string,
}): CancelablePromise<any> {
        return __request(OpenAPI, {
            method: 'DELETE',
            url: '/api/multi-tenancy/tenants/{id}/default-connection-string',
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
