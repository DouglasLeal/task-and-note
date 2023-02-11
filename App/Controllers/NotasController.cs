using App.Interfaces;
using App.Models;
using App.Repositories;
using App.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Slugify;
using System.Runtime.ConstrainedExecution;

namespace App.Controllers
{
    [Authorize]
    public class NotasController : Controller
    {
        private readonly INotaRepository _notaRepository;
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly IMapper _mapper;
        private readonly ISlugHelper _slugHelper;
        private readonly UserManager<IdentityUser> _userManager;

        public NotasController(INotaRepository notaRepository,
            ICategoriaRepository categoriaRepository,
            IMapper mapper,
            UserManager<IdentityUser> userManager,
            ISlugHelper slugHelper
            )
        {
            _notaRepository = notaRepository;
            _categoriaRepository = categoriaRepository;
            _mapper = mapper;
            _userManager = userManager;
            _slugHelper = slugHelper;
        }

        public async Task<IActionResult> Index()
        {
            var usuario = await _userManager.GetUserAsync(User);

            var notas = await _notaRepository.Listar(usuario.Id);

            var viewModels = _mapper.Map<IEnumerable<NotaViewModel>>(notas);
            return View(viewModels);
        }

        [HttpGet]
        public async Task<IActionResult> Criar()
        {
            var usuario = await _userManager.GetUserAsync(User);

            ViewBag.CategoriaId = new SelectList(await _categoriaRepository.Listar(usuario.Id), "Id", "Nome");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Criar([Bind("Titulo, Conteudo, CategoriaId, Cor")] NotaViewModel viewModel)
        {
            var usuario = await _userManager.GetUserAsync(User);

            if (ModelState.IsValid)
            {
                var nota = _mapper.Map<Nota>(viewModel);
                
                nota.AspNetUserId = usuario.Id;


                await _notaRepository.Criar(nota);
                return RedirectToAction(nameof(Index));
            }

            ViewBag.CategoriaId = new SelectList(await _categoriaRepository.Listar(usuario.Id), "Id", "Nome", viewModel.CategoriaId);

            return View("Criar", viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Editar(int id)
        {
            var usuario = await _userManager.GetUserAsync(User);

            var nota = await _notaRepository.BuscarPorId(id);
            var viewModel = _mapper.Map<NotaViewModel>(nota);

            ViewBag.CategoriaId = new SelectList(await _categoriaRepository.Listar(usuario.Id), "Id", "Nome");

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditarAction(int id, [Bind("Titulo, Conteudo, CategoriaId, Cor")] NotaViewModel viewModel)
        {
            var nota = await _notaRepository.BuscarPorId(id);
            nota.Titulo = viewModel.Titulo;
            nota.Conteudo = viewModel.Conteudo;
            nota.CategoriaId = viewModel.CategoriaId;
            nota.Cor = viewModel.Cor;

            await _notaRepository.Atualizar(nota);

            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Excluir(int id)
        {
            var tarefa = await _notaRepository.BuscarPorId(id);

            await _notaRepository.Excluir(tarefa);

            return RedirectToAction(nameof(Index));
        }
    }
}
