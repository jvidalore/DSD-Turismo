package com.pe.company.service;

import java.util.List;

import javax.jws.WebParam;
import javax.jws.WebService;
import com.pe.company.bean.Hotel;

@SuppressWarnings("restriction")
@WebService
public interface HotelService {
	
	public List<Hotel> ConsultarDisponibilidad(
			@WebParam(name = "cantidadPersona") int cantidadPersona
			);
	
}
