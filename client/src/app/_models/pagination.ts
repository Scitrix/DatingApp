export interface Pagination {
    currentPage: number;
    itemsPerPage: number;
    totalItems: number;
    totalpages: number;
  }
  
  export class PaginatiedResult<T> {
    result: T;
    pagination: Pagination;
  }
  