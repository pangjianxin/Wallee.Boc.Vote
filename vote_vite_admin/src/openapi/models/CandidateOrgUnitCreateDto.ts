/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */

import type { CandidateOrgUnitCategory } from './CandidateOrgUnitCategory';

export type CandidateOrgUnitCreateDto = {
    organizationUnitId?: string;
    category?: CandidateOrgUnitCategory;
    superiorId?: string;
};
