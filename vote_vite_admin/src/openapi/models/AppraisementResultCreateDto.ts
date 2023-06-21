/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */

import type { AppraisementResultScoreDetailDto } from './AppraisementResultScoreDetailDto';
import type { EvaluationCategory } from './EvaluationCategory';

export type AppraisementResultCreateDto = {
    appraisementId?: string;
    evaluator?: string;
    candidateId?: string;
    clientIpAddress?: string | null;
    contentScores?: Array<AppraisementResultScoreDetailDto> | null;
    category?: EvaluationCategory;
};
