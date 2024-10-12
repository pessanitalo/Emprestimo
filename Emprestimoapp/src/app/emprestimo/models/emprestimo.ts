import { Cliente } from "src/app/cliente/models/cliente";

export interface Emprestimo{
    emprestimoId:number,
    clienteId:number,
    valorEmprestimo:number,
    quantidadeParcelas:number,
    valorDaParcela:number,
    valorTotal:number,
    cliente:Cliente
}