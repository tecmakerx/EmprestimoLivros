﻿using EmprestimoLivros.Data;
using EmprestimoLivros.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmprestimoLivros.Controllers {
    public class EmprestimoController : Controller {

        readonly private ApplicationDbContext _db;

        public EmprestimoController(ApplicationDbContext db) {
        
            _db = db;
        
        }

        public IActionResult Index() {
            IEnumerable<EmprestimosModel>emprestimos = _db.Emprestimos;
            return View(emprestimos);
        }



        [HttpGet]
        public IActionResult Editar(int? id) {
            if(id == null || id == 0) {
                return NotFound();
            }
            EmprestimosModel emprestimo = _db.Emprestimos.FirstOrDefault(x => x.Id == id);
            if(emprestimo == null) {
                return NotFound();
            }
            return View(emprestimo);
        }

        [HttpGet]
        public IActionResult Excluir(int? id) {
            if (id == null || id == 0) {
                return NotFound();
            }
            EmprestimosModel emprestimo = _db.Emprestimos.FirstOrDefault(x => x.Id == id);
            if (emprestimo == null) {
                return NotFound();
            }
            return View(emprestimo);
        }

    
        [HttpGet]
        public IActionResult Cadastrar() {
            return View();
        }
        





        [HttpPost]
        public IActionResult Cadastrar(EmprestimosModel emprestimo) {
            if(ModelState.IsValid) {
                _db.Emprestimos.Add(emprestimo);
                _db.SaveChanges();

                TempData["MensagemSucesso"] = "Cadastro realizada com sucesso!";


                return RedirectToAction("Index");
            }
            else {
                return View();
            }
        }


        [HttpPost]
        public IActionResult Editar(EmprestimosModel emprestimo) {
            if (ModelState.IsValid) {
                _db.Emprestimos.Update(emprestimo);
                _db.SaveChanges();

                TempData["MensagemSucesso"] = "Edição realizada com sucesso!";

                return RedirectToAction("Index");
            }
            TempData["MensagemErro"] = "Algum erro ocorreu ao realizar a edição!";


            return View(emprestimo);
        }



        [HttpPost]
        public IActionResult Excluir(EmprestimosModel emprestimo) {
            if(emprestimo == null) {
                return NotFound();
            }
            _db.Emprestimos.Remove(emprestimo);

            _db.SaveChanges();

            TempData["MensagemSucesso"] = "Exclusão realizada com sucesso!";

            return RedirectToAction("Index");
        }



       
    }
}
