/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */

import type { CandidateOrgUnitCategory } from './CandidateOrgUnitCategory';

export type CandidateOrgUnitUpdateDto = {
    category?: CandidateOrgUnitCategory;
    superiorId?: string;
    organizationUnitId?: string;
    concurrencyStamp?: string | null;
    isActive?: boolean;
};
