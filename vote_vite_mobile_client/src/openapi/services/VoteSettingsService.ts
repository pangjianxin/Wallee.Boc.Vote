/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */
import type { UpdateVoteSettingsDto } from '../models/UpdateVoteSettingsDto';
import type { VoteSettingsDto } from '../models/VoteSettingsDto';

import type { CancelablePromise } from '../core/CancelablePromise';
import { OpenAPI } from '../core/OpenAPI';
import { request as __request } from '../core/request';

export class VoteSettingsService {

    /**
     * @returns VoteSettingsDto Success
     * @throws ApiError
     */
    public static voteSettingsGetVoteSettings(): CancelablePromise<VoteSettingsDto> {
        return __request(OpenAPI, {
            method: 'GET',
            url: '/api/app/vote-settings/vote-settings',
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
    public static voteSettingsUpdateVoteSettings({
requestBody,
}: {
requestBody?: UpdateVoteSettingsDto,
}): CancelablePromise<any> {
        return __request(OpenAPI, {
            method: 'PUT',
            url: '/api/app/vote-settings/vote-settings',
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
