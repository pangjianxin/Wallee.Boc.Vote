/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */

import type { EvaluationCategory } from './EvaluationCategory';

export type AppraisementUpdateDto = {
    name?: string | null;
    description?: string | null;
    category?: EvaluationCategory;
    start?: string;
    end?: string;
    concurrencyStamp?: string | null;
};
