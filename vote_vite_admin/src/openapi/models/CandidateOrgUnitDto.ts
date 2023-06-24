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
    readonly organizationUnitId?: string;
    organName?: string | null;
    organCode?: string | null;
    category?: CandidateOrgUnitCategory;
    readonly superior?: string;
    readonly superiorName?: string | null;
    concurrencyStamp?: string | null;
};
