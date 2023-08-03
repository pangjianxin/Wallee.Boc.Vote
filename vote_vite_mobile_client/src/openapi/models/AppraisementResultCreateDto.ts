/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */

import type { AppraisementResultDetailCreateDto } from './AppraisementResultDetailCreateDto';
import type { EvaluationCategory } from './EvaluationCategory';

export type AppraisementResultCreateDto = {
    appraisementId?: string;
    clientIp?: string | null;
    ruleName?: string | null;
    details?: Array<AppraisementResultDetailCreateDto> | null;
    category?: EvaluationCategory;
};
