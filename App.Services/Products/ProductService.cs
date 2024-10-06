using App.Repositories;
using App.Repositories.Products;
using System.Net;

namespace App.Services.Products
{
    public class ProductService(IProductRepository productRepository , IUnitOfWork unitOfWork) :IProductService
    {
        public async Task<ServiceResult<List<ProductDto>>> GetTopPriceProductAsync(int count)
        {
            var products = await productRepository.GetTopPriceProductAsync(count);

            var productsDto=products.Select(p=> new ProductDto(p.Id,p.Name,p.Price,p.Stock)).ToList();


            return new ServiceResult<List<ProductDto>>()
            {
                Data = productsDto
            };
        }

        public async Task<ServiceResult<ProductDto>> GetProductByIdAsync(int id) 
        { 
            var product=await productRepository.GetByIdAsync(id); 
              
             if(product is null) 
            {  
                ServiceResult<ProductDto>.Fail("Product not found",HttpStatusCode.NotFound); 
            }  
             var productAsDto=new ProductDto(product!.Stock,product.Name,product.Price,product.Id);

            return ServiceResult<ProductDto>.Success(productAsDto!); 

             
        }  

        public async Task<ServiceResult<CreateProductResponse>> CreateProductAsync(CreateProductRequest request)
        {
            var product =new Product()
            {
                Name = request.Name, Price = request.Price, Stock = request.Stock
            };
            await productRepository.AddAsync(product);
            await unitOfWork.SaveChangesAsync();
            return  ServiceResult<CreateProductResponse>.Success(new CreateProductResponse(product.Id));

        }

        public async Task<ServiceResult> UpdateProductasync(int id, UpdateProductRequest request)
        {
            var product = await productRepository.GetByIdAsync(id);
            if (product is null)
            {
                return ServiceResult.Fail("product not found", HttpStatusCode.NotFound);
            }
            product.Name = request.Name;
            product.Price = request.Price;
            product.Stock = request.Stock;
           
            await productRepository.AddAsync(product);
            await unitOfWork.SaveChangesAsync();
            return ServiceResult.Success();

        }


    }  
} 
