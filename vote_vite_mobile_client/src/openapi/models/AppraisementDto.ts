/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */

import type { EvaluationCategory } from './EvaluationCategory';

export type AppraisementDto = {
    id?: string;
    creationTime?: string;
    creatorId?: string | null;
    lastModificationTime?: string | null;
    lastModifierId?: string | null;
    name?: string | null;
    description?: string | null;
    category?: EvaluationCategory;
    start?: string;
    end?: string;
    concurrencyStamp?: string | null;
};
