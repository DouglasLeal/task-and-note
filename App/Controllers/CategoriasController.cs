using App.Interfaces;
using App.Models;
using App.Repositories;
using App.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Slugify;

namespace App.Controllers
{
    public class CategoriasController : Controller
    {
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly IMapper _mapper;
        private readonly ISlugHelper _slugHelper;
        private readonly UserManager<IdentityUser> _userManager;

        public CategoriasController(ICategoriaRepository categoriaRepository, 
            IMapper mapper, 
            UserManager<IdentityUser> userManager,
            ISlugHelper slugHelper
            )
        {
            _categoriaRepository = categoriaRepository;
            _mapper = mapper;
            _userManager = userManager;
            _slugHelper = slugHelper;
        }

        public async Task<IActionResult> Index()
        {
            var categorias = await _categoriaRepository.Listar();

            var viewModels = _mapper.Map<IEnumerable<CategoriaViewModel>>(categorias);
            ViewBag.Categorias = viewModels;
            return View();
        }

        public async Task<IActionResult> Criar([Bind("Nome, Slug")] CategoriaViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var categoria = _mapper.Map<Categoria>(viewModel);
                var usuario = await _userManager.GetUserAsync(User);
                categoria.AspNetUserId = usuario.Id;

                if(viewModel.Slug == null)
                {
                    categoria.Slug = _slugHelper.GenerateSlug(viewModel.Nome);
                }
                else
                {
                    categoria.Slug = _slugHelper.GenerateSlug(viewModel.Slug);
                }

                await _categoriaRepository.Criar(categoria);
                return RedirectToAction(nameof(Index));
            }

            var categorias = await _categoriaRepository.Listar();
            var viewModels = _mapper.Map<IEnumerable<CategoriaViewModel>>(categorias);
            ViewBag.Categorias = viewModels;
            return View("Index", viewModel);
        }

        
        public async Task<IActionResult> Editar(int id)
        {
            var categorias = await _categoriaRepository.Listar();
            var categoria = await _categoriaRepository.BuscarPorId(id);

            var viewModels = _mapper.Map<IEnumerable<CategoriaViewModel>>(categorias);
            var viewModel = _mapper.Map<CategoriaViewModel>(categoria);
            ViewBag.Categorias = viewModels;
            return View("Index", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditarAction([Bind("Id, Nome, Slug")] CategoriaViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var categoria = _mapper.Map<Categoria>(viewModel);
                var usuario = await _userManager.GetUserAsync(User);
                categoria.AspNetUserId = usuario.Id;

                if (viewModel.Slug == null)
                {
                    categoria.Slug = _slugHelper.GenerateSlug(viewModel.Nome);
                }
                else
                {
                    categoria.Slug = _slugHelper.GenerateSlug(viewModel.Slug);
                }

                await _categoriaRepository.Atualizar(categoria);
                return RedirectToAction(nameof(Index));
            }

            var categorias = await _categoriaRepository.Listar();
            var viewModels = _mapper.Map<IEnumerable<CategoriaViewModel>>(categorias);
            ViewBag.Categorias = viewModels;
            return View("Index", viewModel);
        }

        public async Task<IActionResult> Excluir(CategoriaViewModel viewModel)
        {
            var categoria = await _categoriaRepository.BuscarPorId(viewModel.Id);

            await _categoriaRepository.Excluir(categoria);

            return RedirectToAction(nameof(Index));
        }
    }
}
