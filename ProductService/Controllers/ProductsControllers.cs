using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using ProductService.Data;
using ProductService.Dtos;
using System.Collections.Generic;
using ProductService.Models;
using ProductService.SyncDataServices.Http;
using System.Threading.Tasks;

namespace ProductService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepo _repository;
        private readonly IMapper _mapper;
        private readonly ICommandDataClient _commandDataClient;

        public ProductsController(IProductRepo repository, IMapper mapper, ICommandDataClient commandDataClient)
        {
            _repository = repository;
            _mapper = mapper;
            _commandDataClient = commandDataClient;

        }
        [HttpGet]
        public ActionResult<IEnumerable<ProductReadDto>> GetAllProducts()
        {
            System.Console.WriteLine("->> Obter todos os produtos");

            var products = _repository.GetAllProducts();
            return Ok(_mapper.Map<IEnumerable<ProductReadDto>>(products));
        }

        [HttpGet("{id}", Name = "GetProductById")]
        public ActionResult<ProductReadDto> GetProductById(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Id inválido");
            }

            System.Console.WriteLine("->> Obter produto por id");

            var product = _repository.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<ProductReadDto>(product));
        }

        [HttpGet("{category}/products", Name = "GetProductsByCategory")]
        public ActionResult<IEnumerable<ProductReadDto>> GetProductsByCategory(string category)
        {
            if (category == null)
            {
                return BadRequest("Category is required");
            }
            System.Console.WriteLine("->> Obter produtos por categoria");

            var products = _repository.GetProductsByCategory(category);
            return Ok(_mapper.Map<IEnumerable<ProductReadDto>>(products));
        }

        [HttpPost]
        public async Task<ActionResult<ProductReadDto>> CreateProduct(ProductCreateDto productCreateDto)
        {
            if (productCreateDto == null)
            {
                return BadRequest("Product is required");
            }
            System.Console.WriteLine("->> Criar produto");

            var product = _mapper.Map<Product>(productCreateDto);
            _repository.CreateProduct(product);
            _repository.SaveChanges();

            var productReadDto = _mapper.Map<ProductReadDto>(product);

            try
            {
                await _commandDataClient.SendProductToUser(productReadDto);
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }

            return CreatedAtRoute(nameof(GetProductById), new { Id = productReadDto.Id }, productReadDto);
        }
    }
}