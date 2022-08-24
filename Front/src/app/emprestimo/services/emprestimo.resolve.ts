import { Injectable } from "@angular/core";
import { ActivatedRouteSnapshot, Resolve } from "@angular/router";
import { Emprestimo } from "../models/emprestimo";
import { EmprestimoService } from "./emprestimo.service";

@Injectable()
export class EmprestimoResolve implements Resolve<Emprestimo>{

    constructor(private emprestimoService: EmprestimoService) { }

    resolve(route: ActivatedRouteSnapshot) {
        return this.emprestimoService.obterPorId(route.params['id']);
    }

}
