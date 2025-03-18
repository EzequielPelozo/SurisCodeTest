using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestSurisCode.Models.Dtos;
using TestSurisCode.Repository.IRepository;

namespace TestSurisCode.Controllers
{
    // [Route("api/[controller]")] opcion estatica ?
    [Route("api/categories")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository _ctRepo;
        private readonly IMapper _mapper;

        public CategoriesController(ICategoryRepository ctRepo, IMapper mapper)
        {
            _ctRepo = ctRepo;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetCategories()
        {
            var categoriesList = _ctRepo.GetCategories();
            var categoriesListDto = new List<CategoryDto>();

            foreach (var category in categoriesList)
            {
                categoriesListDto.Add(_mapper.Map<CategoryDto>(category));
            }

            return Ok(categoriesListDto);
        }
    }
}
