namespace Algebra.Data
{
    internal class PagedDataSet<TModel>
    {
        private System.Collections.Generic.List<TModel> list;
        private int page;
        private int rowsPerPage;
        private int count;

        public PagedDataSet(System.Collections.Generic.List<TModel> list, int page, int rowsPerPage, int count)
        {
            this.list = list;
            this.page = page;
            this.rowsPerPage = rowsPerPage;
            this.count = count;
        }
    }
}