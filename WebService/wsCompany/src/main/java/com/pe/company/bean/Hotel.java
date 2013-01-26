package com.pe.company.bean;

import java.io.Serializable;

public class Hotel implements Serializable{
	/**
	 * 
	 */
	private static final long serialVersionUID = 1698070558818374425L;
	
	int codigo;
	String nombre;
	String descripcion;
	String logo;
	int camas;
	int categoria;
	double costo;
	
	public int getCodigo() {
		return codigo;
	}
	public void setCodigo(int codigo) {
		this.codigo = codigo;
	}
	public String getNombre() {
		return nombre;
	}
	public void setNombre(String nombre) {
		this.nombre = nombre;
	}
	public String getDescripcion() {
		return descripcion;
	}
	public void setDescripcion(String descripcion) {
		this.descripcion = descripcion;
	}
	public String getLogo() {
		return logo;
	}
	public void setLogo(String logo) {
		this.logo = logo;
	}
	public int getCamas() {
		return camas;
	}
	public void setCamas(int camas) {
		this.camas = camas;
	}
	public int getCategoria() {
		return categoria;
	}
	public void setCategoria(int categoria) {
		this.categoria = categoria;
	}
	public double getCosto() {
		return costo;
	}
	public void setCosto(double costo) {
		this.costo = costo;
	}
	
	
		
	
}
