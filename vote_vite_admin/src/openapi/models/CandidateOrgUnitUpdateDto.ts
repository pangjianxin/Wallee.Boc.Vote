/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */

import type { CandidateOrgUnitCategory } from './CandidateOrgUnitCategory';

export type CandidateOrgUnitUpdateDto = {
    organName?: string | null;
    organCode?: string | null;
    category?: CandidateOrgUnitCategory;
    concurrencyStamp?: string | null;
};
