/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */

import type { AppraisementCategory } from './AppraisementCategory';

export type AppraisementCreateDto = {
    name?: string | null;
    description?: string | null;
    category?: AppraisementCategory;
    start?: string;
    end?: string;
};
