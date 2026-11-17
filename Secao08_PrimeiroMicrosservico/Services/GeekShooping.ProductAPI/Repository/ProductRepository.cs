using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GeekShooping.ProductAPI.Data.ValueObjects;
using GeekShooping.ProductAPI.Models.Context;
using Microsoft.EntityFrameworkCore;

namespace GeekShooping.ProductAPI.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly MySQLContext _context;
        private readonly IMapper _mapper;

        public ProductRepository(MySQLContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ProductVO> Create(ProductVO product)
        {
            var productEntity = _mapper.Map<Models.Product>(product);

            _context.Products.Add(productEntity);
            _context.SaveChanges();

            return await Task.FromResult(_mapper.Map<ProductVO>(productEntity));
        }

        public async Task<bool> Delete(long id)
        {
            try
            {
                var product = await _context.Products.Where(p => p.Id == id).FirstOrDefaultAsync();

                if (product == null) return false;

                _context.Products.Remove(product);
                _context.SaveChanges();
                
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting product: {ex.Message}");
                return false;
            }
           
        }

        public async Task<IEnumerable<ProductVO>> FindAll()
        {
            var products = await _context.Products.ToListAsync();
            return _mapper.Map<IEnumerable<ProductVO>>(products);
        }

        public async Task<ProductVO> FindById(long id)
        {
            var product = await _context.Products.Where(p => p.Id == id).FirstOrDefaultAsync();
            return _mapper.Map<ProductVO>(product);
        }

        public async Task<ProductVO> Update(ProductVO product)
        {
            var productEntity = _mapper.Map<Models.Product>(product);

            _context.Products.Update(productEntity);
            await _context.SaveChangesAsync();
            
            return _mapper.Map<ProductVO>(productEntity);
        }
    }
}