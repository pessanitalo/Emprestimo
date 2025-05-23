﻿using CredEmprestimo.Business.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CredEmprestimo.Business.Models
{
    [Table("Emprestimo")]
    public class Emprestimo
    {
        [Key]
        public int EmprestimoId { get; set; }

        public decimal ValorEmprestimo { get; set; }

        public int QuantidadeParcelas { get; set; }

        public decimal ValorDaParcela { get; set; }

        public decimal valorTotal { get; set; }

        public DateTime DataAquisicaoEmprestimo { get; set; }
        [JsonIgnore]
        public IList<BoletoEmprestimo> BoletoEmprestimo { get; set; }
        [ForeignKey(nameof(EmprestimoId))]
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        public Emprestimo(decimal valorEmprestimo, int quantidadeParcelas)
        {
            ValorEmprestimo = valorEmprestimo;
            QuantidadeParcelas = quantidadeParcelas;
            ValidateDomain(valorEmprestimo, quantidadeParcelas);
        }
        private void ValidateDomain(decimal valorEmprestimo, int quantidadeParcelas)
        {
            DomainExceptionValidation.When(valorEmprestimo < 100, "O valor do emprestimo deve ser maior que cem reais");
            DomainExceptionValidation.When(quantidadeParcelas < 2, "A quantidade de parcelas deve ser maior que duas vezes.");


            ValorEmprestimo = valorEmprestimo;
            QuantidadeParcelas = QuantidadeParcelas;
        }
        public decimal valorTotalComJuros(decimal valorEmprestimo)
        {
            decimal juros = 0.39m;
            return valorEmprestimo += valorEmprestimo * juros;
        }

        public int ValorParcela(decimal valorTotal, int qtdParcelas)
        {
            return (int)(valorTotal / qtdParcelas);
        }

        public void SimularEmprestimo(decimal valorEmprestimo, int quantidadeParcelas)
        {
            ValorEmprestimo = valorEmprestimo;
            QuantidadeParcelas = quantidadeParcelas;
            valorTotal = valorTotalComJuros(valorEmprestimo);
            ValorDaParcela = ValorParcela(valorTotal, quantidadeParcelas);
        }
        public void emprestimo(decimal valorEmprestimo, int quantidadeParcelas, Cliente cliente)
        {
            ValorEmprestimo = valorEmprestimo;
            QuantidadeParcelas = quantidadeParcelas;
            valorTotal = valorTotalComJuros(valorEmprestimo);
            ValorDaParcela = ValorParcela(valorTotal, quantidadeParcelas);

            DataAquisicaoEmprestimo = DateTime.Now;

            Cliente = cliente;
            Cliente.SaldoAtual += valorEmprestimo;
        }

    }
}
