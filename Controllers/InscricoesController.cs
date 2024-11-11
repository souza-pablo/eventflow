using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EventFlow.Data;
using EventFlow.Models;
using EventFlow.Enums;

namespace EventFlow.Controllers
{
    public class InscricoesController : Controller
    {
        private readonly EventFlowContext _context;

        public InscricoesController(EventFlowContext context)
        {
            _context = context;
        }

        // GET: Inscricoes
        public async Task<IActionResult> Index()
        {
            var eventFlowContext = _context.Inscricoes.Include(i => i.Evento).Include(i => i.Participante);
            return View(await eventFlowContext.ToListAsync());
        }

        // GET: Inscricoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inscricao = await _context.Inscricoes
                .Include(i => i.Evento)
                .Include(i => i.Participante)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (inscricao == null)
            {
                return NotFound();
            }

            return View(inscricao);
        }

        // GET: Inscricoes/Create
        public IActionResult Create()
        {
            ViewData["EventoId"] = new SelectList(_context.Eventos, "Id", "Nome");
            ViewData["ParticipanteId"] = new SelectList(_context.Participantes, "Id", "Email");
            PopularOpcoesEnums();
            return View();
        }

        // POST: Inscricoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EventoId,ParticipanteId,DataInscricao,StatusPagamento,MetodoPagamento")] Inscricao inscricao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(inscricao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EventoId"] = new SelectList(_context.Eventos, "Id", "Nome", inscricao.EventoId);
            ViewData["ParticipanteId"] = new SelectList(_context.Participantes, "Id", "Email", inscricao.ParticipanteId);
            PopularOpcoesEnums();
            return View(inscricao);
        }

        // GET: Inscricoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inscricao = await _context.Inscricoes.FindAsync(id);
            if (inscricao == null)
            {
                return NotFound();
            }
            ViewData["EventoId"] = new SelectList(_context.Eventos, "Id", "Nome", inscricao.EventoId);
            ViewData["ParticipanteId"] = new SelectList(_context.Participantes, "Id", "Email", inscricao.ParticipanteId);
            PopularOpcoesEnums();
            return View(inscricao);
        }

        // POST: Inscricoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EventoId,ParticipanteId,DataInscricao,StatusPagamento,MetodoPagamento")] Inscricao inscricao)
        {
            if (id != inscricao.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(inscricao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InscricaoExists(inscricao.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["EventoId"] = new SelectList(_context.Eventos, "Id", "Nome", inscricao.EventoId);
            ViewData["ParticipanteId"] = new SelectList(_context.Participantes, "Id", "Email", inscricao.ParticipanteId);
            PopularOpcoesEnums();
            return View(inscricao);
        }

        private void PopularOpcoesEnums()
        {
            ViewData["StatusPagamentoOptions"] = new List<SelectListItem>
            {
                new SelectListItem { Value = ((int)StatusPagamento.Pendente).ToString(), Text = "Pendente" },
                new SelectListItem { Value = ((int)StatusPagamento.Pago).ToString(), Text = "Pago" }
            };
            ViewData["MetodoPagamentoOptions"] = new List<SelectListItem>
            {
                new SelectListItem { Value = ((int)MetodoPagamento.PIX).ToString(), Text = "PIX" },
                new SelectListItem { Value = ((int)MetodoPagamento.Dinheiro).ToString(), Text = "Dinheiro" },
                new SelectListItem { Value = ((int)MetodoPagamento.CartaoCredito).ToString(), Text = "Cartão de Crédito" },
                new SelectListItem { Value = ((int)MetodoPagamento.CartaoDebito).ToString(), Text = "Cartão de Débito" }
            };
        }

        // GET: Inscricoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inscricao = await _context.Inscricoes
                .Include(i => i.Evento)
                .Include(i => i.Participante)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (inscricao == null)
            {
                return NotFound();
            }

            return View(inscricao);
        }

        // POST: Inscricoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var inscricao = await _context.Inscricoes.FindAsync(id);
            if (inscricao != null)
            {
                _context.Inscricoes.Remove(inscricao);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InscricaoExists(int id)
        {
            return _context.Inscricoes.Any(e => e.Id == id);
        }
    }
}
