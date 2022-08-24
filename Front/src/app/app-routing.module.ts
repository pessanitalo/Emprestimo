import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: 'cliente',
    loadChildren: () => import('./cliente/cliente.module')
      .then(m => m.ClienteModule)
  },

  {
    path: 'emprestimo',
    loadChildren: () => import('./emprestimo/emprestimo.module')
      .then(m => m.EmprestimoModule)
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
