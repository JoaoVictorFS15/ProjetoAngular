import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EventoComponent } from './componentes/evento/evento.component';
import { DashboardComponent } from './componentes/dashboard/dashboard.component';
import { PalestranteComponent } from './componentes/palestrante/palestrante.component';
import { ContatosComponent } from './componentes/contatos/contatos.component';
import { PerfilComponent } from './componentes/user/perfil/perfil.component';
import { EventoDetalheComponent } from './componentes/evento-detalhe/evento-detalhe.component';
import { EventoListaComponent } from './componentes/evento-lista/evento-lista.component';
import { UserComponent } from './componentes/user/user.component';
import { LoginComponent } from './componentes/user/login/login.component';
import { CadastroComponent } from './componentes/user/cadastro/cadastro.component';

const routes: Routes = [
  {
    path: 'user', component: UserComponent,
    children: [
      { path: 'login', component: LoginComponent },
      { path: 'cadastrar', component: CadastroComponent }
    ]
  },

  { path: 'eventos', redirectTo:'eventos/lista' },

  {
    path: 'eventos', component: EventoComponent,
    children: [
      { path: 'detalhe', component: EventoDetalheComponent },
      { path: 'detalhe/:id', component: EventoDetalheComponent },
      { path: 'lista', component: EventoListaComponent }
    ]
  },
  { path: 'dashboard', component: DashboardComponent },
  { path: 'palestrantes', component: PalestranteComponent },
  { path: 'contatos', component: ContatosComponent },
  { path: 'user/perfil', component: PerfilComponent },
  { path: '', redirectTo: 'dashboard', pathMatch: 'full' },
  { path: '**', redirectTo: 'dashboard', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
