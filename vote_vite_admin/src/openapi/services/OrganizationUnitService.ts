/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */
import type { CombineType } from '../models/CombineType';
import type { ListResultDtoOfOrganizationUnitDto } from '../models/ListResultDtoOfOrganizationUnitDto';
import type { ListResultDtoOfString } from '../models/ListResultDtoOfString';
import type { OrganizationUnitAddRoleDto } from '../models/OrganizationUnitAddRoleDto';
import type { OrganizationUnitAddUserDto } from '../models/OrganizationUnitAddUserDto';
import type { OrganizationUnitCreateDto } from '../models/OrganizationUnitCreateDto';
import type { OrganizationUnitDto } from '../models/OrganizationUnitDto';
import type { OrganizationUnitMoveDto } from '../models/OrganizationUnitMoveDto';
import type { OrganizationUnitUpdateDto } from '../models/OrganizationUnitUpdateDto';
import type { PagedResultDtoOfIdentityRoleDto } from '../models/PagedResultDtoOfIdentityRoleDto';
import type { PagedResultDtoOfIdentityUserDto } from '../models/PagedResultDtoOfIdentityUserDto';
import type { PagedResultDtoOfOrganizationUnitDto } from '../models/PagedResultDtoOfOrganizationUnitDto';

import type { CancelablePromise } from '../core/CancelablePromise';
import { OpenAPI } from '../core/OpenAPI';
import { request as __request } from '../core/request';

export class OrganizationUnitService {

    /**
     * @returns OrganizationUnitDto Success
     * @throws ApiError
     */
    public static organizationUnitCreate({
requestBody,
}: {
requestBody?: OrganizationUnitCreateDto,
}): CancelablePromise<OrganizationUnitDto> {
        return __request(OpenAPI, {
            method: 'POST',
            url: '/api/identity/organization-units',
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
     * @returns PagedResultDtoOfOrganizationUnitDto Success
     * @throws ApiError
     */
    public static organizationUnitGetList({
skipCount,
maxResultCount,
sorting,
combineWith,
}: {
skipCount?: number,
maxResultCount?: number,
sorting?: string,
combineWith?: CombineType,
}): CancelablePromise<PagedResultDtoOfOrganizationUnitDto> {
        return __request(OpenAPI, {
            method: 'GET',
            url: '/api/identity/organization-units',
            query: {
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
    public static organizationUnitDelete({
id,
}: {
id: string,
}): CancelablePromise<any> {
        return __request(OpenAPI, {
            method: 'DELETE',
            url: '/api/identity/organization-units/{id}',
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
     * @returns OrganizationUnitDto Success
     * @throws ApiError
     */
    public static organizationUnitGet({
id,
}: {
id: string,
}): CancelablePromise<OrganizationUnitDto> {
        return __request(OpenAPI, {
            method: 'GET',
            url: '/api/identity/organization-units/{id}',
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
     * @returns OrganizationUnitDto Success
     * @throws ApiError
     */
    public static organizationUnitUpdate({
id,
requestBody,
}: {
id: string,
requestBody?: OrganizationUnitUpdateDto,
}): CancelablePromise<OrganizationUnitDto> {
        return __request(OpenAPI, {
            method: 'PUT',
            url: '/api/identity/organization-units/{id}',
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
     * @returns ListResultDtoOfOrganizationUnitDto Success
     * @throws ApiError
     */
    public static organizationUnitFindChildren({
id,
recursive,
}: {
id: string,
recursive?: boolean,
}): CancelablePromise<ListResultDtoOfOrganizationUnitDto> {
        return __request(OpenAPI, {
            method: 'GET',
            url: '/api/identity/organization-units/find-children',
            query: {
                'Id': id,
                'Recursive': recursive,
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
     * @returns ListResultDtoOfOrganizationUnitDto Success
     * @throws ApiError
     */
    public static organizationUnitGetRoot(): CancelablePromise<ListResultDtoOfOrganizationUnitDto> {
        return __request(OpenAPI, {
            method: 'GET',
            url: '/api/identity/organization-units/root-node',
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
     * @returns OrganizationUnitDto Success
     * @throws ApiError
     */
    public static organizationUnitGetLastChildOrNull({
parentId,
}: {
parentId?: string,
}): CancelablePromise<OrganizationUnitDto> {
        return __request(OpenAPI, {
            method: 'GET',
            url: '/api/identity/organization-units/last-children',
            query: {
                'parentId': parentId,
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
     * @returns ListResultDtoOfOrganizationUnitDto Success
     * @throws ApiError
     */
    public static organizationUnitGetAllList(): CancelablePromise<ListResultDtoOfOrganizationUnitDto> {
        return __request(OpenAPI, {
            method: 'GET',
            url: '/api/identity/organization-units/all',
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
     * @returns ListResultDtoOfString Success
     * @throws ApiError
     */
    public static organizationUnitGetRoleNames({
id,
}: {
id: string,
}): CancelablePromise<ListResultDtoOfString> {
        return __request(OpenAPI, {
            method: 'GET',
            url: '/api/identity/organization-units/{id}/role-names',
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
     * @returns PagedResultDtoOfIdentityRoleDto Success
     * @throws ApiError
     */
    public static organizationUnitGetUnaddedRoles({
id,
filter,
skipCount,
maxResultCount,
sorting,
combineWith,
}: {
id: string,
filter?: string,
skipCount?: number,
maxResultCount?: number,
sorting?: string,
combineWith?: CombineType,
}): CancelablePromise<PagedResultDtoOfIdentityRoleDto> {
        return __request(OpenAPI, {
            method: 'GET',
            url: '/api/identity/organization-units/{id}/unadded-roles',
            path: {
                'id': id,
            },
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
     * @returns PagedResultDtoOfIdentityRoleDto Success
     * @throws ApiError
     */
    public static organizationUnitGetRoles({
id,
sorting,
skipCount,
maxResultCount,
}: {
id: string,
sorting?: string,
skipCount?: number,
maxResultCount?: number,
}): CancelablePromise<PagedResultDtoOfIdentityRoleDto> {
        return __request(OpenAPI, {
            method: 'GET',
            url: '/api/identity/organization-units/{id}/roles',
            path: {
                'id': id,
            },
            query: {
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
     * @returns any Success
     * @throws ApiError
     */
    public static organizationUnitAddRoles({
id,
requestBody,
}: {
id: string,
requestBody?: OrganizationUnitAddRoleDto,
}): CancelablePromise<any> {
        return __request(OpenAPI, {
            method: 'POST',
            url: '/api/identity/organization-units/{id}/roles',
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
     * @returns PagedResultDtoOfIdentityUserDto Success
     * @throws ApiError
     */
    public static organizationUnitGetUnaddedUsers({
id,
filter,
skipCount,
maxResultCount,
sorting,
combineWith,
}: {
id: string,
filter?: string,
skipCount?: number,
maxResultCount?: number,
sorting?: string,
combineWith?: CombineType,
}): CancelablePromise<PagedResultDtoOfIdentityUserDto> {
        return __request(OpenAPI, {
            method: 'GET',
            url: '/api/identity/organization-units/{id}/unadded-users',
            path: {
                'id': id,
            },
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
     * @returns PagedResultDtoOfIdentityUserDto Success
     * @throws ApiError
     */
    public static organizationUnitGetUsers({
id,
filter,
sorting,
skipCount,
maxResultCount,
}: {
id: string,
filter?: string,
sorting?: string,
skipCount?: number,
maxResultCount?: number,
}): CancelablePromise<PagedResultDtoOfIdentityUserDto> {
        return __request(OpenAPI, {
            method: 'GET',
            url: '/api/identity/organization-units/{id}/users',
            path: {
                'id': id,
            },
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
     * @returns any Success
     * @throws ApiError
     */
    public static organizationUnitAddUsers({
id,
requestBody,
}: {
id: string,
requestBody?: OrganizationUnitAddUserDto,
}): CancelablePromise<any> {
        return __request(OpenAPI, {
            method: 'POST',
            url: '/api/identity/organization-units/{id}/users',
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
    public static organizationUnitMove({
id,
requestBody,
}: {
id: string,
requestBody?: OrganizationUnitMoveDto,
}): CancelablePromise<any> {
        return __request(OpenAPI, {
            method: 'PUT',
            url: '/api/identity/organization-units/{id}/move',
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
    public static organizationUnitDeleteRole({
organizationUnitId,
roleId,
}: {
organizationUnitId: string,
roleId: string,
}): CancelablePromise<any> {
        return __request(OpenAPI, {
            method: 'DELETE',
            url: '/api/identity/organization-units/{organizationUnitId}/roles/{roleId}',
            path: {
                'organizationUnitId': organizationUnitId,
                'roleId': roleId,
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
    public static organizationUnitDeleteUser({
organizationUnitId,
userId,
}: {
organizationUnitId: string,
userId: string,
}): CancelablePromise<any> {
        return __request(OpenAPI, {
            method: 'DELETE',
            url: '/api/identity/organization-units/{organizationUnitId}/users/{userId}',
            path: {
                'organizationUnitId': organizationUnitId,
                'userId': userId,
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
