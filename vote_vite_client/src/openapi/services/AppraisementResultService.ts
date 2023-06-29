/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */
import type { AppraisementResultCreateDto } from '../models/AppraisementResultCreateDto';
import type { AppraisementResultDto } from '../models/AppraisementResultDto';
import type { AppraisementResultUpdateDto } from '../models/AppraisementResultUpdateDto';
import type { CombineType } from '../models/CombineType';
import type { PagedResultDtoOfAppraisementResultDto } from '../models/PagedResultDtoOfAppraisementResultDto';

import type { CancelablePromise } from '../core/CancelablePromise';
import { OpenAPI } from '../core/OpenAPI';
import { request as __request } from '../core/request';

export class AppraisementResultService {

    /**
     * @returns AppraisementResultDto Success
     * @throws ApiError
     */
    public static appraisementResultCreate({
requestBody,
}: {
requestBody?: AppraisementResultCreateDto,
}): CancelablePromise<AppraisementResultDto> {
        return __request(OpenAPI, {
            method: 'POST',
            url: '/api/vote/appraisement-result',
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
     * @returns PagedResultDtoOfAppraisementResultDto Success
     * @throws ApiError
     */
    public static appraisementResultGetList({
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
}): CancelablePromise<PagedResultDtoOfAppraisementResultDto> {
        return __request(OpenAPI, {
            method: 'GET',
            url: '/api/vote/appraisement-result',
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
    public static appraisementResultDelete({
id,
}: {
id: string,
}): CancelablePromise<any> {
        return __request(OpenAPI, {
            method: 'DELETE',
            url: '/api/vote/appraisement-result/{id}',
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
     * @returns AppraisementResultDto Success
     * @throws ApiError
     */
    public static appraisementResultGet({
id,
}: {
id: string,
}): CancelablePromise<AppraisementResultDto> {
        return __request(OpenAPI, {
            method: 'GET',
            url: '/api/vote/appraisement-result/{id}',
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
     * @returns AppraisementResultDto Success
     * @throws ApiError
     */
    public static appraisementResultUpdate({
id,
requestBody,
}: {
id: string,
requestBody?: AppraisementResultUpdateDto,
}): CancelablePromise<AppraisementResultDto> {
        return __request(OpenAPI, {
            method: 'PUT',
            url: '/api/vote/appraisement-result/{id}',
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

}
