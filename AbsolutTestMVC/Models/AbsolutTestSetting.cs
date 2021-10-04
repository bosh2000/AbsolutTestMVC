using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbsolutTestMVC.Models
{
    /// <summary>
    /// Класс описывающий настройки.
    /// </summary>
    public class AbsolutTestSetting
    {
        public const string AbsolutSectionSetting = "AbsolutSectionSetting";
        public int PageSize { get; set; }

        public int LinkCount { get; set; }

    }
}
