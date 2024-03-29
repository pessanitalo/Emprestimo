import { BoletoService } from './boleto.service';
import { Injectable } from "@angular/core";
import { ActivatedRouteSnapshot } from "@angular/router";
import { Emprestimo } from "../models/emprestimo";

@Injectable()
export class BoletoResolve {

    constructor(private boletoService: BoletoService) { }

    resolve(route: ActivatedRouteSnapshot) {
        return this.boletoService.obterPorId(route.params['id']);
    }
}

