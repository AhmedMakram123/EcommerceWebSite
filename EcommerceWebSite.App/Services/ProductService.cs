﻿//using AutoMapper;
using EcommerceWebSite.App.Contract;
using EcommerceWebSite.Domain.DTOs;
using EcommerceWebSite.Domain.Models;

namespace EcommerceWebSite.App.Services
{
    //public class ProductService : IProductService
    //{
    //    private readonly IProductRepository productRepository;
    //    private readonly IMapper mapper;

    //    public ProductService(IProductRepository _product, IMapper _mapper)
    //    {
    //        this.productRepository = _product;
    //        this.mapper = _mapper;
    //    }
    //    public async Task<CreateOrUpdateProductDTO> GetAll()
    //    {
    //        var prd = await productRepository.GetAllAsync();
    //        return mapper.Map<CreateOrUpdateProductDTO>(prd);
    //    }
    //    public async Task<CreateOrUpdateProductDTO> Save()
    //    {
    //        var res = await productRepository.SaveChangesAsync();
    //        return mapper.Map<CreateOrUpdateProductDTO>(res);
    //    }
    //    public async Task<CreateOrUpdateProductDTO> Update(CreateOrUpdateProductDTO product)
    //    {
    //        var prd = mapper.Map<Product>(product);
    //        var NewProd = await productRepository.UpdateAsync(prd);
    //        return mapper.Map<CreateOrUpdateProductDTO>(NewProd);
    //    }
    //    public async Task<CreateOrUpdateProductDTO> GetOne(int id)
    //    {
    //        var prd = await productRepository.GetByIdAsync(id);
    //        return mapper.Map<CreateOrUpdateProductDTO>(prd);
    //    }

    //    public async Task<ResultView<CreateOrUpdateProductDTO>> Create(CreateOrUpdateProductDTO product)
    //    {
    //        var query = await productRepository.GetAllAsync();
    //        var OldProduct = query.Where(p => p.Name == product.Name).FirstOrDefault();
    //        if (OldProduct != null)
    //        {
    //            return new ResultView<CreateOrUpdateProductDTO> { Entity = null, IsSuccess = false, msg = "Already Exists" };
    //        }
    //        else
    //        {
    //            var prd = mapper.Map<Product>(product);
    //            var NewProd = await productRepository.CreateAsync(prd);
    //            await productRepository.SaveChangesAsync();
    //            var p = mapper.Map<CreateOrUpdateProductDTO>(NewProd);
    //            return new ResultView<CreateOrUpdateProductDTO> { Entity = p, IsSuccess = true, msg = "Created Successful" };
    //        }
    //    }
    //    public async Task<ResultView<CreateOrUpdateProductDTO>> Delete(CreateOrUpdateProductDTO product)
    //    {
    //        var prd = mapper.Map<Product>(product);
    //        var OldProd = productRepository.DeleteAsync(prd);
    //        await productRepository.SaveChangesAsync();
    //        var p = mapper.Map<CreateOrUpdateProductDTO>(OldProd);
    //        return new ResultView<CreateOrUpdateProductDTO> { Entity = p, IsSuccess = true, msg = "Deleted Successful" };
    //    }
    //}
}