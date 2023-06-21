/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */

import type { CandidateOrgUnitCategory } from './CandidateOrgUnitCategory';

export type CandidateOrgUnitCreateDto = {
    organName?: string | null;
    organCode?: string | null;
    organizationUnitId?: string;
    category?: CandidateOrgUnitCategory;
    superiorId?: string;
};
