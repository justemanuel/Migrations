using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Migrations.Web.Contracts;
using Migrations.Web.Models.DTOs;
using Migrations.Web.Models.NorthwindDB;
using Migrations.Web.Models.NorthwindDB.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Migrations.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategory _categoryRepo;
        private readonly ILogger<CategoryController> _logger;
        private readonly IMapper _mapper;
        private readonly NorthwindContext _context;

        public CategoryController(ICategory categoryRepo, ILogger<CategoryController> logger,
            IMapper mapper, NorthwindContext context)
        {
            _categoryRepo = categoryRepo;
            _logger = logger;
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var items = await _categoryRepo.GetAll();

            var dtos = _mapper.Map<IEnumerable<CategoryDto>>(items);

            return Ok(dtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _categoryRepo.GetOne(id);

            if (result == null) return NotFound();

            return Ok(result);
        }

        //[HttpGet]
        //[Route("exception")]
        //public async Task<IActionResult> Exception()
        //{
        //    throw new NotImplementedException("not implemented");
        //    //throw new Exception("test");
        //}

        [HttpPost]
        public async Task<IActionResult> Post(CategoryCreateDto dto)
        {
            var newCategory = _mapper.Map<Category>(dto);

            _categoryRepo.CreateCategory(newCategory);

            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = newCategory.CategoryId }, newCategory);
        }

        [HttpPut]
        public async Task<IActionResult> Put(int id, CategoryCreateDto dto)
        {
            var item = await _categoryRepo.GetOne(id);

            if (item == null) return NotFound();

            _mapper.Map(dto, item);

            _categoryRepo.UpdateCategory(item);

            await _context.SaveChangesAsync();

            return Ok(item);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _categoryRepo.GetOne(id);

            if (item == null) return NotFound();

            _categoryRepo.DeleteCategory(item);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
