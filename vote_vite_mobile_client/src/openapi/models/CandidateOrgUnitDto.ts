/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */

import type { CandidateOrgUnitCategory } from './CandidateOrgUnitCategory';

export type CandidateOrgUnitDto = {
    id?: string;
    creationTime?: string;
    creatorId?: string | null;
    lastModificationTime?: string | null;
    lastModifierId?: string | null;
    organizationUnitId?: string;
    organName?: string | null;
    organCode?: string | null;
    category?: CandidateOrgUnitCategory;
    superior?: string;
    superiorName?: string | null;
    isActive?: boolean;
    concurrencyStamp?: string | null;
};
