/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */

import type { AppraisementCategory } from './AppraisementCategory';

export type AppraisementDto = {
    id?: string;
    creationTime?: string;
    creatorId?: string | null;
    lastModificationTime?: string | null;
    lastModifierId?: string | null;
    name?: string | null;
    description?: string | null;
    category?: AppraisementCategory;
    start?: string;
    end?: string;
    concurrencyStamp?: string | null;
};
