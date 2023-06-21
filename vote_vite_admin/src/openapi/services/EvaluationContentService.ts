/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */
import type { CombineType } from '../models/CombineType';
import type { EvaluationCategory } from '../models/EvaluationCategory';
import type { EvaluationContentCreateDto } from '../models/EvaluationContentCreateDto';
import type { EvaluationContentDto } from '../models/EvaluationContentDto';
import type { EvaluationContentUpdateDto } from '../models/EvaluationContentUpdateDto';
import type { PagedResultDtoOfEvaluationContentDto } from '../models/PagedResultDtoOfEvaluationContentDto';

import type { CancelablePromise } from '../core/CancelablePromise';
import { OpenAPI } from '../core/OpenAPI';
import { request as __request } from '../core/request';

export class EvaluationContentService {

    /**
     * @returns EvaluationContentDto Success
     * @throws ApiError
     */
    public static evaluationContentCreate({
requestBody,
}: {
requestBody?: EvaluationContentCreateDto,
}): CancelablePromise<EvaluationContentDto> {
        return __request(OpenAPI, {
            method: 'POST',
            url: '/api/vote/evaluation-content',
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
     * @returns PagedResultDtoOfEvaluationContentDto Success
     * @throws ApiError
     */
    public static evaluationContentGetList({
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
}): CancelablePromise<PagedResultDtoOfEvaluationContentDto> {
        return __request(OpenAPI, {
            method: 'GET',
            url: '/api/vote/evaluation-content',
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
    public static evaluationContentDelete({
id,
}: {
id: string,
}): CancelablePromise<any> {
        return __request(OpenAPI, {
            method: 'DELETE',
            url: '/api/vote/evaluation-content/{id}',
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
     * @returns EvaluationContentDto Success
     * @throws ApiError
     */
    public static evaluationContentGet({
id,
}: {
id: string,
}): CancelablePromise<EvaluationContentDto> {
        return __request(OpenAPI, {
            method: 'GET',
            url: '/api/vote/evaluation-content/{id}',
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
     * @returns EvaluationContentDto Success
     * @throws ApiError
     */
    public static evaluationContentUpdate({
id,
requestBody,
}: {
id: string,
requestBody?: EvaluationContentUpdateDto,
}): CancelablePromise<EvaluationContentDto> {
        return __request(OpenAPI, {
            method: 'PUT',
            url: '/api/vote/evaluation-content/{id}',
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
     * @returns EvaluationContentDto Success
     * @throws ApiError
     */
    public static evaluationContentGetListByCategory({
category,
}: {
category: EvaluationCategory,
}): CancelablePromise<Array<EvaluationContentDto>> {
        return __request(OpenAPI, {
            method: 'GET',
            url: '/api/vote/evaluation-content/category/{category}',
            path: {
                'category': category,
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
