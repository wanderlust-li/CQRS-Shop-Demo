﻿using ShopDemo.Domain.Common;

namespace ShopDemo.Application.Repository.ProductRepository;

public interface IGenericRepository<T> where T: BaseEntity
{
    Task<IReadOnlyList<T>> GetAsync();
    
    Task<T> GetByIdAsync(int id);
    
    Task CreateAsync(T entity);
    
    Task UpdateAsync(T entity);
    
    Task DeleteAsync(T entity);
}