/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */

import type { EvaluationCategory } from './EvaluationCategory';

export type EvaluationContentCreateDto = {
    name?: string | null;
    description?: string | null;
    category?: EvaluationCategory;
};
