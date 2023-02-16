﻿using BeYourMarket.Model.Models;
using Repository.Pattern.Repositories;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeYourMarket.Service
{
    public interface IPaisService : IService<PAIS>
    {
        Dictionary<DateTime, int> GetItemsCount(DateTime datetime);
        Dictionary<Category, int> GetCategoryCount();
    }

    public class PaisService : Service<PAIS>, IPaisService
    {
        public PaisService(IRepositoryAsync<PAIS> repository)
            : base(repository)
        {
        }

        public Dictionary<DateTime, int> GetCategoryCount(DateTime fromDate)
        {
            var itemsCountDictionary = new Dictionary<DateTime, int>();
            for (DateTime i = fromDate; i <= DateTime.Now.Date; i = i.AddDays(1))
            {
                itemsCountDictionary.Add(i, 0);
            }

            var itemsCountQuery = Queryable().Where(x => x.Data_Cadastro >= fromDate).GroupBy(x => System.Data.Entity.DbFunctions.TruncateTime(x.Data_Cadastro)).Select(x => new { i = x.Key.Value, j = x.Count() }).ToDictionary(x => x.i, x => x.j);
            foreach (var item in itemsCountQuery)
            {
                itemsCountDictionary[item.Key] = item.Value;
            }

            return itemsCountDictionary;
        }

        public Dictionary<Category, int> GetCategoryCount()
        {
            throw new NotImplementedException();
        }

        Dictionary<DateTime, int> IPaisService.GetItemsCount(DateTime datetime)
        {
            throw new NotImplementedException();
        }
    }
}
