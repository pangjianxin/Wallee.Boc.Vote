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
     * 创建评价活动
     * @returns AppraisementDto Success
     * @throws ApiError
     */
    public static appraisementCreate({
requestBody,
}: {
/**
 * 参数
 */
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
     * 评价活动的分页数据
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
     * 删除评价活动
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
     * 通过ID查找评价活动
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
     * 更新评价活动
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
     * 获取未过期的评价活动列表
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

    /**
     * 根据评价活动和相关角色下载二维码
     * @returns binary Success
     * @throws ApiError
     */
    public static appraisementGetDownloadAppraisementQrcode({
appraisementId,
ruleName,
}: {
appraisementId?: string,
ruleName?: string,
}): CancelablePromise<Blob> {
        return __request(OpenAPI, {
            method: 'GET',
            url: '/api/vote/appraisement/download/qr-code',
            query: {
                'AppraisementId': appraisementId,
                'RuleName': ruleName,
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
     * 上传二维码字体文件
     * @returns any Success
     * @throws ApiError
     */
    public static appraisementUploadQrcdoeBgImgFont({
formData,
}: {
formData?: {
File?: Blob;
},
}): CancelablePromise<any> {
        return __request(OpenAPI, {
            method: 'POST',
            url: '/api/vote/appraisement/upload/qrcode-font',
            formData: formData,
            mediaType: 'multipart/form-data',
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
     * 上传二维码的背景图片
     * @returns any Success
     * @throws ApiError
     */
    public static appraisementUploadQrcodeBgImg({
formData,
}: {
formData?: {
File?: Blob;
},
}): CancelablePromise<any> {
        return __request(OpenAPI, {
            method: 'POST',
            url: '/api/vote/appraisement/upload/qrcode-bg',
            formData: formData,
            mediaType: 'multipart/form-data',
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
