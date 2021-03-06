﻿using SchoolManagerDeskop.Core.Dao;
using SchoolManagerDeskop.Core.Dao.Entities;
using SchoolManagerDeskop.Core.Repositories.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace SchoolManagerDeskop.Core.Repositories
{
    public interface IGroupsRepository : IRepository<Group>
    {
    }

    public class GroupsRepository : Repository<Group>, IGroupsRepository
    {
        public GroupsRepository(ISportEntitiesContextProvider sportEntitiesContextProvider)
        {
            _sportEntitiesContextProvider = sportEntitiesContextProvider ?? throw new ArgumentNullException(nameof(sportEntitiesContextProvider));

            _allIncludes = new Expression<Func<Group, object>>[]
            {
                x => x.Trainer
            };
        }

        internal override Expression<Func<Group, bool>>[] GetSearchExpression(string searchText) => new Expression<Func<Group, bool>>[]
        {
            x => x.Name.Contains(searchText)
                || x.Description.Contains(searchText)
                || x.Trainer.FirstName.Contains(searchText)
                || x.Trainer.MiddleName.Contains(searchText)
                || x.Trainer.LastName.Contains(searchText)
        };
    }
}
