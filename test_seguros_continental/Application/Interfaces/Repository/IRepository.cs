﻿namespace test_seguros_continental.Application.Interfaces.Repository
{
    public interface IRepository<TEntity>
    {
        Task<IEnumerable<TEntity>> GetAllPagination(int pageNumber, int pageSize);
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> GetById(int id);
        Task Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        Task Save();

        IEnumerable<TEntity> Search(Func<TEntity, bool> predicate);
    }
}
