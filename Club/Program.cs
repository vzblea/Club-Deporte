
using System;
using System.Collections;

namespace clases
{
	class Program
	{
		static void Main(string[] args)
		{
			
			ArrayList listDeportes = new ArrayList();
			ArrayList listSocio = new ArrayList();
			
			//public Entrenador(int edad, string nombre, int dni)
			Entrenador entrenador = new Entrenador (26, "Mariano", 12345678);
			Entrenador entrenador2 = new Entrenador (22, "Ricardo", 87654321);
			
			//public Deporte(string nombreDeporte, DateTime categoria, Entrenador entrenador,
			//int cupo, int cantidadInscriptos, double costo, string horario, double descuento)
			Deporte deporte = new Deporte( "futbol", new DateTime(2005,3,3), entrenador, 12,0, 20000, "lunes y jueves de 12 a 14",20);
			Deporte deporte2 = new Deporte( "voley", new DateTime(2001,3,3), entrenador2, 12,0, 20000, "lunes y jueves de 12 a 14",20);
			ArrayList listaEliana = new ArrayList ();
			listaEliana.Add(deporte);
			listDeportes.Add(deporte);
			listDeportes.Add(deporte2);
			
			
			//public Socio(int edad, string nombre, int dni, ArrayList deportes, int categoria, int mesPago)
			Socio socio= new Socio (19, "Eliana", 1,listaEliana , 2005, 4);
			socio.Deportes.Add(deporte);
			deporte.CantidadInscriptos ++;
			listSocio.Add(socio);
			
			ClubDeportivo club = new ClubDeportivo(listSocio, listDeportes);
			while (true) {
				Console.Clear();
				string opcion = menuInfo();
				if(opcion == "x")
				{
					break;
				}
				Menu(club, opcion);
				Console.ReadKey();
			}
			
			
		}
		
		
		static public string menuInfo ()
		{
			Console.WriteLine("Menú:");
			Console.WriteLine("a- Agregar a un entrenador");
			Console.WriteLine("b- Dar de baja a un entrenador");
			Console.WriteLine("c- Agregar a un niño/socio en un deporte");
			Console.WriteLine("d- Dar de baja a un niño/socio en un deporte");
			Console.WriteLine("e- Simular el pago de una cuota");
			Console.WriteLine("f- Submenú de inscripción:");
			Console.WriteLine("g- Listado de deudores");
			Console.WriteLine("h- Agregar un deporte");
			Console.WriteLine("i- Eliminar un deporte");
			Console.WriteLine("x- Salir");

			Console.Write("Seleccione una opción: ");
			string opcion = Console.ReadLine();
			return opcion;
		}
		
		static public void Menu(ClubDeportivo club, string opcion){
			try{
				switch (opcion) {
					case "a":
						Entrenador entrador = pedirDatos();
						Console.WriteLine("Ingrese el nombre del deporte");
						string nombreDeporte2 = Console.ReadLine();
						if(club.buscarDeporte(nombreDeporte2)){
							Console.WriteLine("Ingrese la categoria aaaa (año)");
							int categoriaAño = int.Parse(Console.ReadLine());
							DateTime categoria2 = new DateTime(categoriaAño,3,3);
							if(club.agregarEntrenador(entrador, nombreDeporte2, categoria2)){
								Console.WriteLine("El entrenador se agrego correctamente");
							}
							else{
								Console.WriteLine("Este deporte ya tiene entrenador");
							}
							
						}
						else{
							Console.WriteLine("El deporte ingresado no se encontro en la lista");
						}
						break;
					case "b":
						Console.WriteLine("Ingrese el Dni del Entrenador");
						int dni = int.Parse(Console.ReadLine());
						if(club.eliminarEntrenador(dni)){
							Console.WriteLine("Se dio de baja correctamente");
						}
						else{
							Console.WriteLine("El entrenador ya estaba dado de baja");
						}
						break;
					case "c":
						Console.WriteLine("1- Agregar nuevo socio");
						Console.WriteLine("2- Agregar un socio existente");
						int opcion3= int.Parse(Console.ReadLine());
						switch(opcion3){
							case 1:
								Socio socio = pedirDatosSocio();
								if(club.buscarSocio(socio.Dni)){
									Console.WriteLine("Este socio ya existe en la base de datos");
									return;
								}
								
								Console.WriteLine("Ingrese el nombre del deporte: ");
								string nombreDeporte3 = Console.ReadLine();
								foreach(Deporte d11 in club.ListDeportes){
									if (d11.NombreDeporte == nombreDeporte3 && d11.Categoria.Year == socio.Categoria ) {
										int cupoAux0 = d11.Cupo;
										
										if (cupoAux0 -- <0){
											throw new ExceptionCupoSocio("No hay cupos.");
											
											
										}
										else {
											
											club.agregarSocio(socio, nombreDeporte3);
											socio.Deportes.Add(d11);
											Console.WriteLine("Se agrego correctamente. ");
											return;
										}
									}
								}
								Console.WriteLine("No se encontro el nombre o la categoria del deporte para el socio.");
								
								break;
							case 2:
								Console.WriteLine("ingrese su Dni: ");
								int dni8 = int.Parse(Console.ReadLine());
								Console.WriteLine("Ingrese el nombre del deporte");
								string nombreDeporte9 = Console.ReadLine();
								foreach(Socio s9 in club.ListSocio) {
									
									if (s9.Dni == dni8){
										
										foreach (Deporte d10 in club.ListDeportes){
											
											if (d10.NombreDeporte == nombreDeporte9 && d10.Categoria.Year==s9.Categoria){
												
												int cupoAux = d10.Cupo; // para no modificar la variable real
												
												if (cupoAux -- < 0){
													throw new ExceptionCupoSocio("No hay cupos");
													
													
												}
												else {
													foreach (Deporte d11 in s9.Deportes){
														if (nombreDeporte9==d11.NombreDeporte) {
															Console.WriteLine("Ya esta inscripto a este deporte");
															return;
														}
													}
													s9.Deportes.Add(d10);
													Console.WriteLine("Se agrego correctamente" );
												}
											}
											
											
										}
									}
									
								}
								break;
						}
						break;
						
					case "d":
						Console.WriteLine("Ingrese su dni");
						int dni2 = int.Parse(Console.ReadLine());
						Console.WriteLine("Ingrese su nombre del deporte");
						string nombreDeporte4 = Console.ReadLine();
						if(club.eliminarSocio(dni2, nombreDeporte4)) {
							Console.WriteLine("Se elimino el socio correctamente.");
						}
						else{
							Console.WriteLine("No existe tal socio");
						}
						break;
					case "e":
						
						// PagarCuota(double montoCuota, int dni, string nombreDeporte, ClubDeportivo club)
						Console.WriteLine("Ingrese el monto a depositar");
						double montoCuota = double.Parse(Console.ReadLine());
						Console.WriteLine("Ingrese su dni");
						int dni3 = int.Parse(Console.ReadLine());
						Console.WriteLine("Ingrese nombre del deporte");
						string nombreDeporte5 = Console.ReadLine();
						double? vuelto= club.PagarCuota(montoCuota, dni3, nombreDeporte5, club);// puede contener un tipo de dato double o null
						if (vuelto == null){
							Console.WriteLine("El pago no se ha podido realizar");
						}
						else if (vuelto.GetType() == typeof(double))
						{
							vuelto= vuelto * -1;
							Console.WriteLine("El vuelto de la cuota es" + vuelto);
							break;
						}
						break;
					case "f":
						Console.WriteLine("Ingrese una opcion");
						Console.WriteLine("1 - Por deporte");
						Console.WriteLine("2 - Por deporte y categoría");
						Console.WriteLine("3 - Total");
						int opcion2 = int.Parse(Console.ReadLine());
						switch (opcion2) {
							case 1:
								ListarInscriptosPorDeporte(club);
								break;
							case 2:
								ListarInscriptosPorDeporteYCategoría(club);
								break;
							case 3:
								imprimirTotalIncriptos(club);
								break;
								
						}
						break;
					case "g":
						Console.WriteLine(club.ListSocio.Count);
						if(club.ListSocio == null || club.ListSocio.Count == 0 )
						{
							Console.WriteLine("La lista esta vacia");
						}
						else{
							imprimirDeudores(club);
						}
						break;
					case "h":
						agregarDeporte(club);
						break;
					case "i":
						Console.WriteLine("Ingrese el nombre del deporte");
						string nombreDeporte6 = Console.ReadLine();
						Console.WriteLine("Ingrese la categoria del deporte");
						int categoria= int.Parse(Console.ReadLine());
						if(club.eliminarDeporte(nombreDeporte6, categoria)){
							Console.WriteLine("Se elimino correctamente");
						}
						else {
							Console.WriteLine("No se pudo eliminar");
						}
						
						
						break;
				}
			}
			catch (FormatException ex)
			{
				Console.WriteLine(ex.Message);
			}
			catch (ExceptionCupoSocio ex2){
				Console.WriteLine(ex2.Message);
				
			}
			
			
		}
		
		
		static public void ListarInscriptosPorDeporte(ClubDeportivo club)
		{
			foreach (Deporte d3 in club.ListDeportes) { //recorro la lista de deportes
				Console.WriteLine("Inscriptos en el deporte " + d3.NombreDeporte + ":");
				foreach (Socio s in club.ListSocio) { // recorro la lista de socios
					foreach (Deporte d in s.Deportes) { //por cada socio recorro su lista de deportes
						if(d.NombreDeporte == d3.NombreDeporte){
							Console.WriteLine("Nombre: {0}, Dni: {1}, Edad{2}",s.Nombre,s.Dni,s.Edad);
							break;
						}
						
					}
				}
			}
			
		}
		
		static public void ListarInscriptosPorDeporteYCategoría(ClubDeportivo club)
		{
			
			foreach (Deporte d3 in club.ListDeportes) { //recorro la lista de deportes
				Console.WriteLine("Inscriptos en el deporte " + d3.NombreDeporte + ":");
				foreach (Socio s in club.ListSocio) { // recorro la lista de socios
					foreach (Deporte d in s.Deportes) { //por cada socio recorro su lista de deportes
						if(d.NombreDeporte == d3.NombreDeporte && d.Categoria == d3.Categoria){
							Console.WriteLine("Nombre: {0}, Dni: {1}, Edad{2}",s.Nombre,s.Dni,s.Edad);
							break;
						}
						
					}
				}
			}
			
		}
		// int edad, string nombre, int dni, ArrayList deportes, int categoria, int mesPago
		static public Socio pedirDatosSocio(){
			Console.WriteLine("ingrese su edad");
			int edad2 = int.Parse(Console.ReadLine());
			Console.WriteLine("Ingrese su nombre");
			string nombre2 = Console.ReadLine();
			Console.WriteLine("Ingrese su Dni");
			int dni2 = int.Parse(Console.ReadLine());
			ArrayList listaDeportes = new ArrayList();
			Console.WriteLine("Ingrese su año de nacimiento");
			int categoriaAño2 = int.Parse(Console.ReadLine());
			DateTime categoria3 = new DateTime(categoriaAño2,3,3);
			DateTime fechaActual = DateTime.Now;
			
			Socio socio = new Socio(edad2, nombre2, dni2, listaDeportes, categoriaAño2, fechaActual.Month);
			return socio;
		}
		
		
		static public void imprimirTotalIncriptos(ClubDeportivo club)
		{
			foreach (Socio s3 in club.ListSocio) {
				Console.WriteLine("Nombre: {0}, Dni: {1}, Edad{2}",s3.Nombre,s3.Dni,s3.Edad);
			}
		}
		
		
		static public void imprimirDeudores(ClubDeportivo club){
			DateTime fechaActual = DateTime.Now;
			foreach (Socio s4 in club.ListSocio) {
				if(fechaActual.Month > s4.MesPago){
					Console.WriteLine("Deudores: ");
					Console.WriteLine("Nombre: {0}, Dni: {1}, Edad{2}",s4.Nombre,s4.Dni,s4.Edad);
				}
			}
		}
		
		static public void agregarDeporte(ClubDeportivo club){
			Console.WriteLine("ingrese el nombre del deporte");
			string nombreDeporte = Console.ReadLine();
			try{
				Console.WriteLine("Ingrese la categoria aaaa (año)");
				int año = int.Parse(Console.ReadLine());
				DateTime categoria = new DateTime(año,3,3);
				Console.WriteLine("Ingrese los datos del entreador para el deporte");
				Entrenador entrenador = pedirDatos();
				Console.WriteLine("Ingrese la cantidad de cupos del deporte");
				int cupo = int.Parse(Console.ReadLine());
				int cantidadIncriptos = 0;
				Console.WriteLine("Ingrese el costo del deporte");
				double costo = double.Parse(Console.ReadLine());
				Console.WriteLine("Ingrese el horario del deporte");
				string horario = Console.ReadLine();
				Console.WriteLine("Ingrese el descuento del deporte");
				double descuento = double.Parse( Console.ReadLine());
				
				Deporte deporte = new Deporte(nombreDeporte, categoria, entrenador, cupo, cantidadIncriptos, costo, horario, descuento);
				
				club.agregarDeporte(deporte);
				Console.WriteLine("El deporte se agrego correctamente");
			}
			catch(FormatException ex){
				Console.WriteLine(ex.Message);
			}
			
		}
		
		static public Entrenador pedirDatos()
		{
			int edad2, dni2;
			Console.WriteLine("Ingrese su nombre");
			string nombre = Console.ReadLine();
			try{
				Console.WriteLine("ingrese su edad");
				string edadTexto = Console.ReadLine();
				bool valor = int.TryParse(edadTexto, out edad2);
				if (valor)
				{
					Console.WriteLine("ingrese su dni");
					string dniTexto = Console.ReadLine();
					bool valor2 = int.TryParse(dniTexto, out dni2);
					if(valor2)
					{
						Entrenador entrenador = new Entrenador(edad2, nombre, dni2);
						return entrenador;
					}
					else{
						throw new ExceptionDniInvalido ("El dni ingresado en invalido");
					}
				}
				else{
					throw new ExceptionEdadInvalida("La edad ingresada es invalida");
				}
				
			}
			
			catch (ExceptionEdadInvalida ex){
				Console.WriteLine(ex.Message);
			}
			catch (ExceptionDniInvalido ex2){
				Console.WriteLine(ex2.Message);
			}
			return null;
		}
		
	}
	
}
