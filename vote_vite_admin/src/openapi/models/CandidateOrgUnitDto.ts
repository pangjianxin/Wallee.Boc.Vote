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
    organName?: string | null;
    organCode?: string | null;
    category?: CandidateOrgUnitCategory;
    superiorName?: string | null;
    superiorEhr?: string | null;
    concurrencyStamp?: string | null;
};
