﻿using System.Collections;
using System;
namespace clases{
	public class ClubDeportivo
	{
		private ArrayList listSocio;
		private ArrayList listDeportes ;

		public ClubDeportivo(ArrayList listSocio, ArrayList listDeportes)
		{
			this.listSocio = listSocio != null ? listSocio : new ArrayList();
        	this.listDeportes = listDeportes != null ? listDeportes : new ArrayList();/*
 El constructor asigna las listas proporcionadas o crea nuevas listas vacías si las entradas son nulas,
 evitando así errores de "lista null"
*/
		}

		public ArrayList ListSocio
		{
			get { return listSocio; }
		}

		public ArrayList ListDeportes
		{
			get { return listDeportes; }
		}
		
		public void agregarDeporte(Deporte deporte)
		{
			foreach (Deporte d6 in ListDeportes) {
				if(d6.NombreDeporte == deporte.NombreDeporte)
				{
				   return;
				}
			}
			ListDeportes.Add(deporte);
		}
		
		public bool agregarEntrenador (Entrenador entrador, string deporte, DateTime categoria)
		{
			foreach (Deporte a in this.listDeportes) {
				if(a.NombreDeporte == deporte && a.Categoria.Year == categoria.Year && a.Entrenador == null)
				{
					a.Entrenador = entrador;
					return true;
				}
			}
			return false;
		}
		
		public bool eliminarEntrenador(int dni){
			
			foreach (Deporte b in this.listDeportes) {
				if(b.Entrenador.Dni == dni)
				{
					Console.WriteLine("DENTRO DE LA CLASE CLUB " + b.Entrenador.Nombre +  b.Entrenador.Dni);
					b.Entrenador = null;
					return true;
				}
			}
			return false;
			
			
		}
		
		public bool eliminarDeporte(string nombreDeporte, int categoria){
	
		   foreach (Deporte d5 in ListDeportes) {
				
					
				if(d5.NombreDeporte == nombreDeporte && d5.CantidadInscriptos <= 0 && d5.Categoria.Year == categoria ){
					ListDeportes.Remove(d5);
					return true;
					
					
				}
			}
			return false;
		}
		
		public bool buscarDeporte(string nombreDelDeporte){
		   foreach (Deporte d7 in this.ListDeportes) {
				if(d7.NombreDeporte == nombreDelDeporte)
				{
				return true;
				}
		   }
			return false;
		}
		
		
		public bool agregarSocio (Socio socio, string deporte)
		{
			DateTime fechaActual = DateTime.Now;
			DateTime categoria = new DateTime(fechaActual.Year - socio.Edad, 3, 3);
			try{
				foreach (Deporte c in listDeportes) {
					if (c.Cupo < 0)
					{
						throw new ExceptionCupoSocio("No hay cupos");
					}
					if(c.Cupo > 0 && c.NombreDeporte == deporte && categoria.Year == c.Categoria.Year){
						ListSocio.Add(socio);
						c.Cupo--;
						c.CantidadInscriptos++;
						return true;
					}
				}
			}
			catch(ExceptionCupoSocio ex3)
			{
				Console.WriteLine(ex3.Message);
			}
			return false;
		}
		
		public bool eliminarSocio (int dni, string deporte)
		{
			foreach (Deporte e in listDeportes) {
				if (e.NombreDeporte == deporte)
				{
					foreach (Socio d in listSocio) {
						if(d.Dni == dni){
							ListSocio.Remove(d);  // lista que tiene la clase club
							d.Deportes.Remove(e); // lista que tiene el objeto socio
							e.CantidadInscriptos--;
							e.Cupo++;
							return true;
						}
					}
				}
			}
			return false;
			
		}
		
		public bool buscarSocio(int dni)
		{
			foreach (Socio s2 in listSocio) {
				if(s2.Dni == dni)
				{
					return true;
				}
			}
			return false;
		}
		
		public double? PagarCuota(double montoCuota, int dni, string nombreDeporte, ClubDeportivo club) // el signo ? significa que puede llegar a retornar un null 
		{ 
			foreach (Socio s8 in club.listSocio){
				if ( s8.Dni==dni ){
					foreach(Deporte d8 in s8.Deportes){
						if(d8.NombreDeporte==nombreDeporte){
							double descuento= d8.Descuento;
							double cuentaAux= (d8.Costo/100)*d8.Descuento;
							double precioFinal= d8.Costo - cuentaAux;
							double vuelto= precioFinal- montoCuota;
							if(vuelto <=0 )
							{ 
							
								s8.MesPago ++;
								return vuelto;
								
							}
							
							else{
								return null;
							}
						}
						
					}
				}
			}
		
			return null;
		}

		
	}
}