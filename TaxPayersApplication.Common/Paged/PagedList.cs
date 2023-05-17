using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxPayersApplication.Common.Paged
{
    public class PagedList<T> : List<T>
    {
        public int TotalPages { get; private set; }
        public int PageSize { get; private set; }
        public int TotalCount { get; private set; }
        public int TotalItemCount { get; set; }
        public int CurrentPage { get; set; }
        public int Count { get; set; }
        public int PageCount { get; set; }
        public bool HasPrevious
        {
            get
            {
                return (CurrentPage > 1);
            }
        }
        public bool HasNext
        {
            get
            {
                return (CurrentPage < TotalPages);
            }
        }
        public PagedList()
        {
        }

        public PagedList(IEnumerable<T> source, int startRowIndex, int pageSize)
            : this(source == null ? new List<T>().AsQueryable() : source.AsQueryable(), startRowIndex, pageSize)
        {
        }

        public static PagedList<T> Create(IQueryable<T> source, int pageNumber, int pageSize)
        {
            if (pageNumber == 0) pageNumber = 1;
            var count = source.Count();
            if (count > 0)
            {
                var items = source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
                return new PagedList<T>(items, count, pageNumber, pageSize);
            }
            return null;

        }
        private PagedList(IQueryable<T> source, int startRowIndex, int pageSize)
        {
            TotalItemCount = source.Count();
            if (TotalItemCount > 0)
            {
                if (startRowIndex == -1)
                {
                    Data = source.Take(pageSize).ToArray();
                    PageCount = 1;
                }
                else
                {
                    Data = source.Skip(startRowIndex).Take(pageSize).ToArray();
                    PageCount = (int)Math.Ceiling(TotalItemCount / (decimal)pageSize);
                }

                Count = Data.Length;
            }
        }
        public PagedList(List<T> items, int count, int pageNumber, int pageSize)
        {
            TotalCount = count;
            PageSize = pageSize;
            CurrentPage = pageNumber;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            if (pageNumber == 0) pageNumber = 1;

            AddRange(items);
        }

        private T[] _Data;

        public T[] Data
        {
            get
            {
                return _Data ??= Array.Empty<T>();
            }
            set
            {
                _Data = value;
            }
        }
    }
}
