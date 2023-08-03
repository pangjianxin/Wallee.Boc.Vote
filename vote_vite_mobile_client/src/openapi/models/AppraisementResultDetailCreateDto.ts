/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */

import type { AppraisementResultDetailScoreDto } from './AppraisementResultDetailScoreDto';

export type AppraisementResultDetailCreateDto = {
    candidateId?: string;
    scoreDetails?: Array<AppraisementResultDetailScoreDto> | null;
};
