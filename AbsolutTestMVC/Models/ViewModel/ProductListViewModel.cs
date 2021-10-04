using AbsolutTestMVC.Models.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbsolutTestMVC.Models.ViewModels
{
    /// <summary>
    /// Класс для View index
    /// </summary>
    public class ProductListViewModel
    {
        public IEnumerable<AbsolutData> AbsolutDatas { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurrentCategory { get; set; }
    }
}
