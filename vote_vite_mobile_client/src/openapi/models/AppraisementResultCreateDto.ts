/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */

import type { AppraisementResultScoreDetailDto } from './AppraisementResultScoreDetailDto';
import type { EvaluationCategory } from './EvaluationCategory';

export type AppraisementResultCreateDto = {
    appraisementId?: string;
    candidateId?: string;
    contentScores?: Array<AppraisementResultScoreDetailDto> | null;
    category?: EvaluationCategory;
};
