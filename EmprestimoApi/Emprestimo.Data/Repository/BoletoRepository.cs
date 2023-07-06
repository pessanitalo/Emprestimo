﻿using CredEmprestimo.Business.Interface;
using CredEmprestimo.Business.Models;
using CredEmprestimo.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace CredEmprestimo.Data.Repository
{
    public class BoletoRepository : IBoletoRepository
    {
        private readonly DataContext _context;
        private readonly IEmprestimoRepository _emprestimoRepository;

        public BoletoRepository(DataContext context, IEmprestimoRepository emprestimoRepository)
        {
            _context = context;
            _emprestimoRepository = emprestimoRepository;
        }

        public BoletoEmprestimo GerarBoleto(int id)
        {
            var emprestimo = _emprestimoRepository.PesquisarEmprestimo(id);

            var boleto = new BoletoEmprestimo();

            var dataVencimentoParcela = emprestimo.DataAquisicaoEmprestimo;
            var dataParcela = DateTime.Now;
            var numeroParcela = 1;

            for (int i = 0; i < emprestimo.QuantidadeParcelas; i++)
            {
                dataVencimentoParcela = dataParcela;

                boleto = new BoletoEmprestimo
                {
                    Id = 0,
                    NumeroParcela = numeroParcela + i,
                    EmprestimoId = emprestimo.Id,
                    ValorDaParcela = emprestimo.ValorDaParcela,
                    DataDePagamento = dataVencimentoParcela.AddDays(30)
                };

                dataParcela = boleto.DataDePagamento;
                _context.BoletoEmprestimo.Add(boleto);
            }

            _context.SaveChanges();
            return boleto;
        }

        //public bool geralBoletoVencido(int id)
        //{
        //    var parcela = _context.BoletoEmprestimo.Include(d => d.Emprestimo).FirstOrDefault(x => x.Id == id);
        //    if (parcela == null) return false;

        //    var vencimentoBoleto = parcela.DataDePagamento.Day;
        //    var dataAtual = DateTime.Now.Day;

        //    var diasCorridos = dataAtual - vencimentoBoleto;
        //    var valorTotal = PagarParcelaVencida(parcela.ValorDaParcela, diasCorridos);

        //    parcela.ValorDaParcela = valorTotal;
        //    _context.Update(parcela);
        //    _context.SaveChanges();
        //    return true;

        //}

        public BoletoEmprestimo PagarUmaParcela(int id, int numeroDaParcela)
        {
            var parcela = PesquisarParcela(id, numeroDaParcela);

            var emprestimo = _emprestimoRepository.DetalhesEmprestimo(parcela.EmprestimoId);

            emprestimo.Cliente.SaldoAtual -= emprestimo.ValorDaParcela;

            _context.BoletoEmprestimo.Remove(parcela);
            _context.Clientes.Update(emprestimo.Cliente);
            _context.SaveChanges();
            return parcela;
        }

        public BoletoEmprestimo PesquisarParcela(int id, int numeroParcela)
        {
            var parcela = _context.BoletoEmprestimo.FirstOrDefault(x => x.EmprestimoId == id && x.NumeroParcela == numeroParcela);
            return parcela;
        }

        //private decimal PagarParcelaVencida(decimal valorParcela, int diasEmAtraso)
        //{

        //    double jurosAposVencimento = 3.3 / 100.00;
        //    decimal valorComJuros = (decimal)(diasEmAtraso + (jurosAposVencimento * diasEmAtraso));

        //    decimal multaAposvencimento = 200 / 100.00;
        //    decimal valorAjustado = valorParcela + multaAposvencimento;

        //    decimal totalJuros = valorAjustado + valorComJuros;
        //    return totalJuros;

        //}

        public List<BoletoEmprestimo> DetalhesParcela(int id)
        {
            var parcela = _context.BoletoEmprestimo.ToList().Where(x => x.EmprestimoId == id).ToList();
            return parcela.ToList();
        }
    }
}
