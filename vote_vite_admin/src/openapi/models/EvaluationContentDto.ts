/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */

import type { EvaluationCategory } from './EvaluationCategory';

export type EvaluationContentDto = {
    id?: string;
    name?: string | null;
    description?: string | null;
    category?: EvaluationCategory;
    concurrencyStamp?: string | null;
};
