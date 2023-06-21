/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */
import type { CandidateOrgUnitCreateDto } from '../models/CandidateOrgUnitCreateDto';
import type { CandidateOrgUnitDto } from '../models/CandidateOrgUnitDto';
import type { CandidateOrgUnitUpdateDto } from '../models/CandidateOrgUnitUpdateDto';
import type { CandidateOrgUnitUpdateSuperiorDto } from '../models/CandidateOrgUnitUpdateSuperiorDto';
import type { CombineType } from '../models/CombineType';
import type { PagedResultDtoOfCandidateOrgUnitDto } from '../models/PagedResultDtoOfCandidateOrgUnitDto';

import type { CancelablePromise } from '../core/CancelablePromise';
import { OpenAPI } from '../core/OpenAPI';
import { request as __request } from '../core/request';

export class CandidateOrgUnitService {

    /**
     * @returns CandidateOrgUnitDto Success
     * @throws ApiError
     */
    public static candidateOrgUnitCreate({
requestBody,
}: {
requestBody?: CandidateOrgUnitCreateDto,
}): CancelablePromise<CandidateOrgUnitDto> {
        return __request(OpenAPI, {
            method: 'POST',
            url: '/api/vote/candidate-org-unit',
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
     * @returns PagedResultDtoOfCandidateOrgUnitDto Success
     * @throws ApiError
     */
    public static candidateOrgUnitGetList({
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
}): CancelablePromise<PagedResultDtoOfCandidateOrgUnitDto> {
        return __request(OpenAPI, {
            method: 'GET',
            url: '/api/vote/candidate-org-unit',
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
    public static candidateOrgUnitDelete({
id,
}: {
id: string,
}): CancelablePromise<any> {
        return __request(OpenAPI, {
            method: 'DELETE',
            url: '/api/vote/candidate-org-unit/{id}',
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
     * @returns CandidateOrgUnitDto Success
     * @throws ApiError
     */
    public static candidateOrgUnitGet({
id,
}: {
id: string,
}): CancelablePromise<CandidateOrgUnitDto> {
        return __request(OpenAPI, {
            method: 'GET',
            url: '/api/vote/candidate-org-unit/{id}',
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
     * @returns CandidateOrgUnitDto Success
     * @throws ApiError
     */
    public static candidateOrgUnitUpdate({
id,
requestBody,
}: {
id: string,
requestBody?: CandidateOrgUnitUpdateDto,
}): CancelablePromise<CandidateOrgUnitDto> {
        return __request(OpenAPI, {
            method: 'PUT',
            url: '/api/vote/candidate-org-unit/{id}',
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
     * @returns CandidateOrgUnitDto Success
     * @throws ApiError
     */
    public static candidateOrgUnitGetCandidateOrgUnitEvaList(): CancelablePromise<Array<CandidateOrgUnitDto>> {
        return __request(OpenAPI, {
            method: 'GET',
            url: '/api/vote/candidate-org-unit/candidate-org-units',
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
     * @returns CandidateOrgUnitDto Success
     * @throws ApiError
     */
    public static candidateOrgUnitUpdateSuperior({
id,
requestBody,
}: {
id: string,
requestBody?: CandidateOrgUnitUpdateSuperiorDto,
}): CancelablePromise<CandidateOrgUnitDto> {
        return __request(OpenAPI, {
            method: 'PUT',
            url: '/api/vote/candidate-org-unit/supervior/{id}',
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
