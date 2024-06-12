
﻿using System;
using System.Collections;

public class Socio : Persona
{
	private ArrayList deportes;
	private int categoria;
	private int mesPago;
	
	public Socio(int edad, string nombre, int dni, ArrayList deportes, int categoria, int mesPago) : base(edad, nombre, dni)
	{
	
		this.deportes = deportes;
		this.categoria = categoria;
		this.mesPago = mesPago;
		this.deportes = deportes != null ? deportes : new ArrayList();
		
	}
	
	public bool existeDeporte(string deporte)
	{ 
		foreach (Deporte deporte2 in deportes){
			if ( deporte2.NombreDeporte == deporte){
			return true; 
			}
			
		}
		return false;
	}

	public ArrayList Deportes
	{
		get { return deportes; }
	}

	public int Categoria
	{
		get { return categoria; }
		set { categoria = value; }
	}
	public int MesPago
	{
		get { return mesPago; }
		set { mesPago = value; }

	}

	
}
