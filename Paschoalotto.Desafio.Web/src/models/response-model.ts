export class ResponseModel<K = never> {
  data?: K;
  errorMessage?: string;
  page?: number;
  pageCount?: number;
}
