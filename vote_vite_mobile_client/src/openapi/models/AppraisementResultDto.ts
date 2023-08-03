/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */

import type { AppraisementResultDetailDto } from './AppraisementResultDetailDto';
import type { EvaluationCategory } from './EvaluationCategory';

export type AppraisementResultDto = {
    id?: string;
    creationTime?: string;
    creatorId?: string | null;
    lastModificationTime?: string | null;
    lastModifierId?: string | null;
    readonly clientIp?: string | null;
    readonly ruleName?: string | null;
    readonly appraisementId?: string;
    readonly candidateId?: string;
    readonly details?: Array<AppraisementResultDetailDto> | null;
    readonly score?: number;
    category?: EvaluationCategory;
};
