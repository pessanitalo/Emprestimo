import { Cliente } from "src/app/cliente/models/cliente";

export interface Emprestimo{
    id:number,
    ClienteId:number,
    valorEmprestimo:number,
    quantidadeParcelas:number,
    valorDaParcela:number,
    valorTotal:number,
    cliente:Cliente
}