import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MenuComponent } from './navegacao/menu/menu.component';

const routes: Routes = [
  { path: '', redirectTo: '/menu', pathMatch: 'full' },
  { path: 'menu', component: MenuComponent },

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
