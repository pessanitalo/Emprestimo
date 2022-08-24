import { Emprestimo } from './../../emprestimo/models/emprestimo';
export interface Cliente{
    id: number;
    nome:string;
    idade:number;
    score:number;
    saldoAtual:number;
    emprestimo:Emprestimo
}