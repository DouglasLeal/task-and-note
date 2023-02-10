using App.Interfaces;
using App.Models;
using App.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    [Authorize]
    public class TarefasController : Controller
    {
        private readonly ITarefaRepository _tarefaRepository;
        private readonly IMapper _mapper;
        private readonly UserManager<IdentityUser> _userManager;

        public TarefasController(IMapper mapper, ITarefaRepository tarefaRepository, UserManager<IdentityUser> userManager)
        {
            _tarefaRepository = tarefaRepository;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var usuario = await _userManager.GetUserAsync(User);
            var tarefas = await _tarefaRepository.Listar(usuario.Id);

            var viewModels = _mapper.Map<IEnumerable<TarefaViewModel>>(tarefas);
            ViewBag.Tarefas = viewModels;
            return View();
        }

        public async Task<IActionResult> Criar([Bind("Conteudo")] TarefaViewModel viewModel)
        {
            var usuario = await _userManager.GetUserAsync(User);
            if (ModelState.IsValid)
            {
                var tarefa = _mapper.Map<Tarefa>(viewModel);
                
                tarefa.AspNetUserId = usuario.Id;

                await _tarefaRepository.Criar(tarefa);
                return RedirectToAction(nameof(Index));
            }

            var tarefas = await _tarefaRepository.Listar(usuario.Id);

            var viewModels = _mapper.Map<IEnumerable<TarefaViewModel>>(tarefas);
            ViewBag.Tarefas = viewModels;
            return View("Index", viewModel);
        }

        public async Task<IActionResult> EditarCheckbox(TarefaViewModel viewModel)
        {
            var tarefa = await _tarefaRepository.BuscarPorId(viewModel.Id);
            tarefa.Concluido = !tarefa.Concluido;

            await _tarefaRepository.Atualizar(tarefa);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> EditarConteudo(TarefaViewModel viewModel)
        {
            var tarefa = await _tarefaRepository.BuscarPorId(viewModel.Id);
            tarefa.Conteudo = viewModel.Conteudo;

            await _tarefaRepository.Atualizar(tarefa);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Excluir(TarefaViewModel viewModel)
        {
            var tarefa = await _tarefaRepository.BuscarPorId(viewModel.Id);
 

            await _tarefaRepository.Excluir(tarefa);

            return RedirectToAction(nameof(Index));
        }
    }
}
