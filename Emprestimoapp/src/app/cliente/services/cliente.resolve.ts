import { ClienteServicesService } from './cliente-services.service';
import { Injectable } from "@angular/core";
import { Cliente } from '../models/cliente';
import { ActivatedRouteSnapshot, Resolve } from '@angular/router';


@Injectable()
export class ClienteResolve implements Resolve<Cliente>{

    constructor(private clienteService: ClienteServicesService) { }

    resolve(route: ActivatedRouteSnapshot) {
        return this.clienteService.obterPorId(route.params['id']);
    }

}
