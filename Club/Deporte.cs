
﻿using System;
using System.Collections;
public class Deporte
{
	private string nombreDeporte;
	private DateTime categoria;
	private Entrenador entrenador;
	private int cupo;
	private int cantidadInscriptos;
	private double costo;
	private string horario;
	private double descuento;
	

	public Deporte(string nombreDeporte, DateTime categoria, Entrenador entrenador, int cupo, int cantidadInscriptos, double costo, string horario, double descuento)
	{
		this.nombreDeporte = nombreDeporte;
		this.categoria = categoria;
		this.entrenador = entrenador;
		this.cupo = cupo;
		this.cantidadInscriptos = cantidadInscriptos;
		this.costo = costo;
		this.horario = horario;
		this.descuento= descuento;
	}

	public string NombreDeporte
	{
		get { return nombreDeporte; }
		set { nombreDeporte = value; }
	}
	public DateTime Categoria
	{
		get { return categoria; }
		set { categoria = value; }

	}
	public Entrenador Entrenador
	{
		get { return entrenador; }
		set { entrenador = value; }
	}
	public int Cupo
	{
		get { return cupo; }
		set { cupo = value; }
	}
	public int CantidadInscriptos
	{
		get { return cantidadInscriptos; }
		set { cantidadInscriptos = value; }
	}
	public string Horario
	{
		get { return horario; }
		set { horario = value; }
	}
	
	public double Costo
	{
		get { return costo; }
		set { costo = value; }
	}
	
	public double Descuento{
		get{ return descuento;}
		set{ descuento = value;}
	}
	
}
