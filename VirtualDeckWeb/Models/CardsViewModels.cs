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



        [Display(Prompt = "Precio de la carta", Description = "Precio de la carta", Name = "Precio")]
        [Required(ErrorMessage = "el precio Debe de estar indicado")]
        [DataType(DataType.Currency, ErrorMessage = "Precio de la carta")]
        [Range(minimum: 0, maximum: 400, ErrorMessage = "Precio de la carta")]
        public CardTypeEnum TypeCard { get; set; }


        [Display(Prompt = "Precio de la carta", Description = "Precio de la carta", Name = "Precio")]
        [Required(ErrorMessage = "el precio Debe de estar indicado")]
        [DataType(DataType.Currency, ErrorMessage = "Precio de la carta")]
        [Range(minimum: 0, maximum: 400, ErrorMessage = "Precio de la carta")]
        public int HealthCard { get; set; }


        [Display(Prompt = "Precio de la carta", Description = "Precio de la carta", Name = "Precio")]
        [Required(ErrorMessage = "el precio Debe de estar indicado")]
        [DataType(DataType.Currency, ErrorMessage = "Precio de la carta")]
        [Range(minimum: 0, maximum: 400, ErrorMessage = "Precio de la carta")]
        public int AttackCard { get; set; }



        [Display(Prompt = "Precio de la carta", Description = "Precio de la carta", Name = "Precio")]
        [Required(ErrorMessage = "el precio Debe de estar indicado")]
        [DataType(DataType.Currency, ErrorMessage = "Precio de la carta")]
        [Range(minimum: 0, maximum: 400, ErrorMessage = "Precio de la carta")]
        public int DefenseCard { get; set; }



        [Display(Prompt = "Precio de la carta", Description = "Precio de la carta", Name = "Precio")]
        [Required(ErrorMessage = "el precio Debe de estar indicado")]
        [DataType(DataType.Currency, ErrorMessage = "Precio de la carta")]
        [Range(minimum: 0, maximum: 400, ErrorMessage = "Precio de la carta")]
        public int SpeedCard { get; set; }


        [Display(Prompt = "Precio de la carta", Description = "Precio de la carta", Name = "Precio")]
        [Required(ErrorMessage = "el precio Debe de estar indicado")]
        [DataType(DataType.Currency, ErrorMessage = "Precio de la carta")]
        [Range(minimum: 0, maximum: 400, ErrorMessage = "Precio de la carta")]
        public CardRarityEnum RarityCard { get; set; }
    }
}