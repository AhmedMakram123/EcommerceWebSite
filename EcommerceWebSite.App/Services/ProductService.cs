using AutoMapper;
using EcommerceWebSite.App.Contract;
using EcommerceWebSite.Domain.DTOs;
using EcommerceWebSite.Domain.DTOs.Products;
using EcommerceWebSite.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceWebSite.App.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;
        private readonly IMapper mapper;

        public ProductService(IProductRepository _product, IMapper _mapper)
        {
            this.productRepository = _product;
            this.mapper = _mapper;
        }

        public async Task<List<GetAllProductDTO>> GetAll()
        {
            var prd = await productRepository.GetAllAsync();
            return mapper.Map<List<GetAllProductDTO>>(prd);
        }

        public async Task<GetAllProductDTO> GetOne(int id)
        {
            var prd = await productRepository.GetByIdAsync(id);
            return mapper.Map<GetAllProductDTO>(prd);
        }

        public async Task<ResultView<GetAllProductDTO>> Create(CreateOrUpdateProductDTO product)
        {
            var query = await productRepository.GetAllAsync();
            var OldProduct = query.Where(p => p.EnName == product.EnName).FirstOrDefault();
            if (OldProduct != null)
            {
                return new ResultView<GetAllProductDTO> { Entity = null, IsSuccess = false, msg = "Already Exists" };
            }
            else
            {
                var prd = mapper.Map<Product>(product);
                // Set ImgURL property
                prd.imgURL = product.imgURL;
                var NewProd = await productRepository.CreateAsync(prd);
                try
                {
                    await productRepository.SaveChangesAsync();
                }
                catch
                {
                    return new ResultView<GetAllProductDTO> { Entity = null, IsSuccess = false, msg = "Make sure you inserted all data correctly" };
                }
                var p = mapper.Map<GetAllProductDTO>(NewProd);
                return new ResultView<GetAllProductDTO> { Entity = p, IsSuccess = true, msg = "Created Successful" };
            }
        }

        public async Task<CreateOrUpdateProductDTO> Update(GetAllProductDTO product)
        {
            var prd = await productRepository.GetByIdAsync(product.id);

            prd.ArName = product.ArName;
            prd.EnName = product.EnName;
            prd.Price = product.Price;
            prd.imgURL = product.imgURL;
            prd.Description = product.Description;
            prd.Quantity = product.Quantity;
            prd.SubCategoryId = product.SubCategoryId;
            var NewProd = await productRepository.UpdateAsync(prd);
            await productRepository.SaveChangesAsync();
            return mapper.Map<CreateOrUpdateProductDTO>(NewProd);
        }

        public async Task<ResultView<GetAllProductDTO>> Delete(int id)
        {
            var prdDTO = await GetOne(id);
            var prd = mapper.Map<Product>(prdDTO);
            var OldProd = await productRepository.DeleteAsync(prd);
            await productRepository.SaveChangesAsync();
            var p = mapper.Map<GetAllProductDTO>(OldProd);
            return new ResultView<GetAllProductDTO> { Entity = p, IsSuccess = true, msg = "Deleted Successful" };
        }

        public async Task<int> Save()
        {
            var res = await productRepository.SaveChangesAsync();
            return res;
        }

        public async Task<List<Product>> getAllProductByCategory(int CategoryId)
        {
            return await (await productRepository.getAllProductByCategory(CategoryId)).ToListAsync();
        }
    }
}
