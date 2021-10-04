using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbsolutTestMVC.Models.Db
{
    /// <summary>
    /// Интерфейс репозитория.
    /// </summary>
    public interface IAbsolutDataRepository
    {
        public List<AbsolutData> GetAbsolutDatas();
    }
}
