import { BoletoService } from './boleto.service';
import { Injectable } from "@angular/core";
import { ActivatedRouteSnapshot } from "@angular/router";
import { Emprestimo } from "../models/emprestimo";
import { EmprestimoService } from "./emprestimo.service";

@Injectable()
export class EmprestimoResolve {

    constructor(private emprestimoService: EmprestimoService) { }

    resolve(route: ActivatedRouteSnapshot) {
        return this.emprestimoService.obterPorId(route.params['id']);
    }
}
