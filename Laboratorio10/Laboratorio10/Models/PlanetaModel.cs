using System;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Laboratorio10.Models
{
	public class PlanetaModel
	{
		public int id { get; set; }

		[Required(ErrorMessage ="Es necesario que indique el nombre del planeta")]
		[Display(Name = "Ingrese el nombre del planeta")]
		public string nombre { get; set; }

		[Required(ErrorMessage = "Es necesario que indique el tipo de planeta")]
		[Display(Name = "Ingrese el tipo de planeta")]
		public string tipo { get; set; }

		[Required(ErrorMessage = "Es necesario que indique el número de anillos")]
		[Display(Name = "Ingrese el número de anillos")]
		public int numeroAnillos { get; set; }

		[Required(ErrorMessage = "Debe agregar un archivo(imagen, pdf, etc...)")]
		[Display(Name = "Ingrese el archivo con los detalles del planeta")]
		public  HttpPostedFileBase archivo { get; set; }

		public string tipoArchivo { get; set; }
	}
}