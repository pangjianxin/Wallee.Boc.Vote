/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */

import type { EvaluationCategory } from './EvaluationCategory';

export type AppraisementResultDto = {
    id?: string;
    evaluator?: string;
    candidateId?: string;
    content?: string | null;
    score?: number;
    clientIpAddress?: string | null;
    category?: EvaluationCategory;
};
