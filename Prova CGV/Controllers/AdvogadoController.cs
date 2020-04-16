using Domains;
using Prova_CGV.Models;
using Repositories;
using Repositories.Interfaces;
using Services;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Prova_CGV.Controllers
{
    public class AdvogadoController : Controller
    {
        private IAdvogadoService _advogadoService;
        public IAdvogadoService ServicoDeAdvogado
        {
            get => _advogadoService ?? (_advogadoService = new AdvogadoService(new AdvogadoRepository()));
        }

        public ActionResult Lista()
        {
            List<AdvogadoModel> lista = new List<AdvogadoModel>();
            foreach(var item in ServicoDeAdvogado.Listar())
            {
                lista.Add(Converter(item));           
            }

            return View(lista.AsEnumerable());
        }

        public ActionResult Cadastro()
        {
            return View();
        }

        public ActionResult Ver(int id)
        {
            var advogado = ServicoDeAdvogado.Listar().Where(x => x.Id == id).FirstOrDefault();
            var model = Converter(advogado);
            return View(model);
        }

        public ActionResult Edita(int id)
        {
            var advogado = ServicoDeAdvogado.Listar().Where(x => x.Id == id).FirstOrDefault();
            var model = Converter(advogado);
            return View(model);
        }

        [HttpPost]
        public ActionResult Editar(AdvogadoModel model)
        {
            var advogado = Converter(model);
            bool sucesso = ServicoDeAdvogado.Editar(advogado);

            if (sucesso)
            {
                TempData["MensagemSucesso"]= "Cadastro editado com sucesso! =)";
                TempData["MensagemErro"] = null;
            }
            else
            {
                TempData["MensagemSucesso"] = null;
                TempData["MensagemErro"] = "Erro ao editado o cadastro. =/";
            }

            return RedirectToAction("Lista");
        }

        public ActionResult Deletar(int id)
        {
            bool sucesso = ServicoDeAdvogado.Deletar(id);

            if (sucesso)
            {
                TempData["MensagemSucesso"] = "Cadastro deletado com sucesso! =)";
                TempData["MensagemErro"] = null;
            }
            else
            {
                TempData["MensagemSucesso"] = null;
                TempData["MensagemErro"] = "Erro ao deletar o cadastro. =/";
            }

            return RedirectToAction("Lista");

        }

        [HttpPost]
        public ActionResult Cadastrar(AdvogadoModel model)
        {
            var advogado = Converter(model);
            bool sucesso = ServicoDeAdvogado.Adicionar(advogado);
            if (sucesso)
            {
                TempData["MensagemSucesso"]= "Cadastro efetuado com sucesso! =)";
                TempData["MensagemErro"] = null;                
            }
            else
            {
                TempData["MensagemSucesso"] = null;
                TempData["MensagemErro"] = "Erro ao efetuar o cadastro. =/";
            }

            return RedirectToAction("Lista");
        }

        public Advogado Converter(AdvogadoModel model)
        {
            var advogado = new Advogado();

            if (model.Id == null) 
                advogado.Id = (ServicoDeAdvogado.Listar().Count >  0 ? ServicoDeAdvogado.Listar().Select(x => x.Id).Max() + 1 : 1);
            else
                advogado.Id = (int)model.Id;

            advogado.Nome = model.Nome;
            advogado.Senioridade = model.Senioridade;
            advogado.Endereco = new Endereco
            {
                Logradouro = model.Endereco.Logradouro,
                Numero = model.Endereco.Numero,
                Complemento = model.Endereco.Complemento
            };

            return advogado;
        }

        public static AdvogadoModel Converter(Advogado advogado)
        {
            return new AdvogadoModel
            { 
                Id = advogado.Id,
                Nome = advogado.Nome,
                Senioridade = advogado.Senioridade,
                Endereco = new EnderecoModel
                {
                    Logradouro = advogado.Endereco.Logradouro,
                    Numero = advogado.Endereco.Numero,
                    Complemento = advogado.Endereco.Complemento
                }
            };
        }

    }
}