/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */

import type { EvaluationCategory } from './EvaluationCategory';

export type AppraisementCreateDto = {
    name?: string | null;
    description?: string | null;
    category?: EvaluationCategory;
    start?: string;
    end?: string;
};
