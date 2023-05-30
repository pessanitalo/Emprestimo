import { Emprestimo } from "./emprestimo";

export interface parcelas {
    id: number,
    numeroParcela: number,
    valorDaParcela: number,
    dataDePagamento: Date,
    EmprestimoId: number,
    emprestimo: Emprestimo
}