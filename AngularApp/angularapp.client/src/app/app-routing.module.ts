import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EventoComponent } from './componentes/evento/evento.component';
import { DashboardComponent } from './componentes/dashboard/dashboard.component';
import { PalestranteComponent } from './componentes/palestrante/palestrante.component';
import { ContatosComponent } from './componentes/contatos/contatos.component';
import { PerfilComponent } from './componentes/perfil/perfil.component';

const routes: Routes = [

  { path: 'eventos', component: EventoComponent },
  { path: 'dashboard', component: DashboardComponent },
  { path: 'palestrantes', component: PalestranteComponent },
  { path: 'contatos', component: ContatosComponent },
  { path: 'perfil', component: PerfilComponent },
  { path: '', redirectTo: 'dashboard', pathMatch: 'full' },
  { path: '**', redirectTo: 'dashboard', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
