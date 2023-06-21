/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */
import type { AppraisementCreateDto } from '../models/AppraisementCreateDto';
import type { AppraisementDto } from '../models/AppraisementDto';
import type { AppraisementUpdateDto } from '../models/AppraisementUpdateDto';
import type { CombineType } from '../models/CombineType';
import type { PagedResultDtoOfAppraisementDto } from '../models/PagedResultDtoOfAppraisementDto';

import type { CancelablePromise } from '../core/CancelablePromise';
import { OpenAPI } from '../core/OpenAPI';
import { request as __request } from '../core/request';

export class AppraisementService {

    /**
     * @returns AppraisementDto Success
     * @throws ApiError
     */
    public static appraisementCreate({
requestBody,
}: {
requestBody?: AppraisementCreateDto,
}): CancelablePromise<AppraisementDto> {
        return __request(OpenAPI, {
            method: 'POST',
            url: '/api/vote/appraisement',
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
     * @returns PagedResultDtoOfAppraisementDto Success
     * @throws ApiError
     */
    public static appraisementGetList({
filter,
skipCount,
maxResultCount,
sorting,
combineWith,
}: {
filter?: string,
skipCount?: number,
maxResultCount?: number,
sorting?: string,
combineWith?: CombineType,
}): CancelablePromise<PagedResultDtoOfAppraisementDto> {
        return __request(OpenAPI, {
            method: 'GET',
            url: '/api/vote/appraisement',
            query: {
                'Filter': filter,
                'SkipCount': skipCount,
                'MaxResultCount': maxResultCount,
                'Sorting': sorting,
                'CombineWith': combineWith,
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
    public static appraisementDelete({
id,
}: {
id: string,
}): CancelablePromise<any> {
        return __request(OpenAPI, {
            method: 'DELETE',
            url: '/api/vote/appraisement/{id}',
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
     * @returns AppraisementDto Success
     * @throws ApiError
     */
    public static appraisementGet({
id,
}: {
id: string,
}): CancelablePromise<AppraisementDto> {
        return __request(OpenAPI, {
            method: 'GET',
            url: '/api/vote/appraisement/{id}',
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
     * @returns AppraisementDto Success
     * @throws ApiError
     */
    public static appraisementUpdate({
id,
requestBody,
}: {
id: string,
requestBody?: AppraisementUpdateDto,
}): CancelablePromise<AppraisementDto> {
        return __request(OpenAPI, {
            method: 'PUT',
            url: '/api/vote/appraisement/{id}',
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
     * @returns AppraisementDto Success
     * @throws ApiError
     */
    public static appraisementGetAllAvailable(): CancelablePromise<Array<AppraisementDto>> {
        return __request(OpenAPI, {
            method: 'GET',
            url: '/api/vote/appraisement/available',
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
