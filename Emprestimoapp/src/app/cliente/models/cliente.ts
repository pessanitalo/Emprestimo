import { Emprestimo } from './../../emprestimo/models/emprestimo';
export interface Cliente{
    id: number;
    nome:string;
    idade:number;
    score:number;
    cpf: string;
    saldoAtual:number;
    emprestimo:Emprestimo
}