using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using VirtualDeckGenNHibernate.Enumerated.VirtualDeck;

namespace VirtualDeckWeb.Models
{
    public class CardsViewModels
    {
       [ScaffoldColumn(false)]
        public int IdCard { get; set; }

        [Display(Prompt = "Imagen de la carta", Description = "Imagen de la carta", Name = "Imagen")]
        [Required(ErrorMessage = "Debe de estar indicado")]
        [StringLength(maximumLength: 400,ErrorMessage = "Imagen de la carta")]
        public string ImgCard { get; set; }


        [Display(Prompt = "Precio de la carta", Description = "Precio de la carta", Name = "Precio")]
        [Required(ErrorMessage = "el precio Debe de estar indicado")]
        [DataType(DataType.Currency, ErrorMessage = "Precio de la carta")]
        [Range(minimum: 0, maximum: 400, ErrorMessage = "Precio de la carta")]
        public string NameCard { get; set; }



        [Display(Prompt = "Descripción de la carta", Description = "Descripción de la carta", Name = "Descripción")]
        [Required(ErrorMessage = "El Descripción debe de estar indicado")]
        [StringLength(maximumLength: 400, ErrorMessage = "Descripción de la carta")]
        public string CardDescription { get; set; }




        [Display(Prompt = "Precio de la carta", Description = "Precio de la carta", Name = "Precio")]
        [Required(ErrorMessage = "el precio Debe de estar indicado")]
        [DataType(DataType.Currency, ErrorMessage = "Precio de la carta")]
        [Range(minimum:0, maximum: 400, ErrorMessage = "Precio de la carta")]
        public double PriceCard { get; set; }



        [Display(Prompt = "Type de la carta", Description = "Type de la carta", Name = "Type")]
        [Required(ErrorMessage = "el Type Debe de estar indicado")]
        [Range(minimum: 0, maximum: 400, ErrorMessage = "Type de la carta")]
        [StringLength(maximumLength: 400, ErrorMessage = "Type de la carta")]

        public string TypeCard { get; set; }


        [Display(Prompt = "Health de la carta", Description = "Health de la carta", Name = "Health")]
        [Required(ErrorMessage = "el Health Debe de estar indicado")]
        [Range(minimum: 0, maximum: 400, ErrorMessage = "Health de la carta")]
        public int HealthCard { get; set; }


        [Display(Prompt = "Attack de la carta", Description = "Attack de la carta", Name = "Attack")]
        [Required(ErrorMessage = "el Attack Debe de estar indicado")]
        [Range(minimum: 0, maximum: 400, ErrorMessage = "Attack de la carta")]
        public int AttackCard { get; set; }



        [Display(Prompt = "Defense de la carta", Description = "Defense de la carta", Name = "Defense")]
        [Required(ErrorMessage = "el Defense Debe de estar indicado")]
        [Range(minimum: 0, maximum: 400, ErrorMessage = "Defense de la carta")]
        public int DefenseCard { get; set; }



        [Display(Prompt = "Speed de la carta", Description = "Speed de la carta", Name = "Speed")]
        [Required(ErrorMessage = "el Speed Debe de estar indicado")]
        [Range(minimum: 0, maximum: 400, ErrorMessage = "Speed de la carta")]
        public int SpeedCard { get; set; }


        [Display(Prompt = "Rarity de la carta", Description = "Rarity de la carta", Name = "Rarity")]
        [Required(ErrorMessage = "el Rarity Debe de estar indicado")]
        [StringLength(maximumLength: 400, ErrorMessage = "Longitud de la carta")]

        public string RarityCard { get; set; }
    }
}