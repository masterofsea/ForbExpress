using System;

namespace ForbExpress.Models.ViewModels
{
    public class PageViewModel
    {
        public int Count { get; }
        public int CurrentPage { get; }
        public int TotalPages { get; }
        public int PageCapacity { get; }
        public int StartRow { get; }
        public int EndRow { get; }

        public PageViewModel(int count, int currentPage, int pageCapacity)
        {
            if (count == 0)
            {
                CurrentPage = 1;
                PageCapacity = pageCapacity;
                StartRow = 0;
                EndRow = 0;
                TotalPages = 0;
                return;
            }
            
            Count = count;
            CurrentPage = currentPage;

            TotalPages = (int) Math.Ceiling(count / (double) pageCapacity);

            if (currentPage > TotalPages) throw new PageModelException("Not valid number of current page");

            PageCapacity = pageCapacity;

            StartRow = (CurrentPage - 1) * PageCapacity + 1;
            
            EndRow = CurrentPage * PageCapacity < Count ? CurrentPage * PageCapacity : Count;
        }

        public bool HasPreviousPage => CurrentPage > 1;

        public bool HasNextPage => CurrentPage < TotalPages;

        public PageState FirstPageState => CurrentPage - 1 > 1
            ? CurrentPage - 1 == 1 ? PageState.Penultimate : PageState.Far
            : PageState.Disabled;

        public PageState LastPageState => CurrentPage + 1 < TotalPages
            ? CurrentPage + 2 == TotalPages ? PageState.Penultimate : PageState.Far
            : PageState.Disabled;
    }

    public class PageModelException : Exception
    {
        public PageModelException()
        {
        }

        public PageModelException(string message) : base(message)
        {
        }

        public PageModelException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }


    public enum PageState
    {
        Disabled,
        Penultimate,
        Far
    }
}