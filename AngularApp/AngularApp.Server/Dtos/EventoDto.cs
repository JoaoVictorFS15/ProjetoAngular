using AngularApp.Server.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AngularApp.Server.Dtos
{
    public class EventoDto
    {
        public int Id { get; set; }
        public string Local { get; set; }
        public string DataEvento { get; set; }

        //[StringLength(50, MinimumLength = 3, ErrorMessage ="intervalo é entre 3 e 50 caracteres.")]
        [Required(ErrorMessage = "O campo {0} é obrigatório"),
            MinLength(3, ErrorMessage = "{0} deve ter no mínimo 4 caracteres."),
            MaxLength(50, ErrorMessage = "{0} deve ter no máximo 50 caracteres.")]
        public string Tema { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [Range(1, 100000, ErrorMessage ="A {0} não pode ser menor que 1 e não pode ser maior que 100.000.")]
        public int QTDPesssoas { get; set; }
        
        [RegularExpression(@".*\.(gif|jpe?g|bmp|png)$", ErrorMessage = "Não é uma imagem válida. (gif, jpeg, jpg, bmp ou png).")]
        public string ImagemURL { get; set; }
        
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [Phone(ErrorMessage ="O campo {0} está com um número inválido.")]
        public string Telefone { get; set; }

        [Required(ErrorMessage ="o campo{0} é obrigatório.")]
        [EmailAddress(ErrorMessage = "o campo {0} precisa ser uma e-mail válido.")]
        public string Email { get; set; }
        public IEnumerable<LoteDto> Lote { get; set; }
        public IEnumerable<RedeSocialDto> RedeSocials { get; set; }
        public IEnumerable<PalestranteEventoDto> PalestranteEvento { get; set; }
    }
}
