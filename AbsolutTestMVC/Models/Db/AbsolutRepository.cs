using System.Collections.Generic;

namespace AbsolutTestMVC.Models.Db
{
    /// <summary>
    /// Класс описывающий работу с данными, что то типа репозитория.
    /// </summary>
    public class AbsolutRepository : IAbsolutDataRepository
    {
        /// <summary>
        /// Ленивая инициализация свойства.
        /// </summary>
        private List<AbsolutData> absolutDatas ;
        private bool __init_absolutDatas;

        private List<AbsolutData> AbsolutDatas
        {
            get
            {
                if (!__init_absolutDatas)
                {
                    absolutDatas = new List<AbsolutData>();
                    for (int i = 0; i < 100; i++)
                    {
                        absolutDatas.Add(new AbsolutData
                        {
                            LastName = $"LastName-{i}",
                            Name = $"Name - {i},",
                            PersonID = $"PersonID - {i}"
                        }
                        );
                    }
                    __init_absolutDatas = true;
                }
                return absolutDatas;
            }
        }
        /// <summary>
        /// Получить все данные
        /// </summary>
        /// <returns></returns>
        public List<AbsolutData> GetAbsolutDatas()
        {
            return AbsolutDatas;
        }
    }
}