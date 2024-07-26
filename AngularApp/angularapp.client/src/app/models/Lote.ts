import { Evento } from "./Evento";

export interface Lote {
  id: number;
  nome: string;
  preco: Float32List;
  dataInicio?: Date;
  dataFim?: Date;
  quantidade: number;
  eventoId: number; 
  evento: Evento; 
}
