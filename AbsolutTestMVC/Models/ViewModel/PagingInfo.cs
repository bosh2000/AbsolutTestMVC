using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbsolutTestMVC.Models.ViewModels
{
    /// <summary>
    /// Класс описывающий онформацию о страницах.
    /// </summary>
    public class PagingInfo
    {
        public int TotalItems { get; set; }
        public int ItemsPerPage { get; set; }
        public int CurrentPage { get; set; }
        

        public int TotalPages => (int)Math.Ceiling((decimal) TotalItems / ItemsPerPage);
    }
}
