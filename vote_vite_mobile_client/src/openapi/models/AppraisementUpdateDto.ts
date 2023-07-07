/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */

import type { AppraisementCategory } from './AppraisementCategory';

export type AppraisementUpdateDto = {
    name?: string | null;
    description?: string | null;
    category?: AppraisementCategory;
    start?: string;
    end?: string;
    concurrencyStamp?: string | null;
};
