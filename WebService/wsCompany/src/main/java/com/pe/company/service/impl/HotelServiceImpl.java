package com.pe.company.service.impl;
import java.util.ArrayList;
import java.util.List;

import com.pe.company.bean.Hotel;
import com.pe.company.service.HotelService;

import javax.jws.WebParam;
import javax.jws.WebService;

@SuppressWarnings("restriction")
@WebService(endpointInterface="com.pe.company.service.HotelService")
public class HotelServiceImpl implements HotelService {

	public List<Hotel> ConsultarDisponibilidad(
			@WebParam(name = "cantidadPersona") int cantidadPersona) {
		// TODO Auto-generated method stub
		
		List<Hotel> lista = new ArrayList<Hotel>();
		
		Hotel registro01 = new Hotel();
		registro01.setCodigo(1);
		registro01.setNombre("HOTEL SHERATON");
		registro01.setDescripcion("dfd djhkjad jDHKd kFKLjf lKFJ");
		registro01.setCosto(200.00);
		registro01.setCamas(2);
		registro01.setLogo("http://upload.wikimedia.org/wikipedia/commons/thumb/5/56/Hotel-room-renaissance-columbus-ohio.jpg/250px-Hotel-room-renaissance-columbus-ohio.jpg");
		lista.add(registro01);
		
		Hotel registro02 = new Hotel();
		registro02.setCodigo(1);
		registro02.setNombre("HOTEL EL LIBERTADOR");
		registro02.setDescripcion("dfd djhkjad jDHKd kFKLjf lKFJ");
		registro02.setCosto(180.00);
		registro02.setCamas(2);
		registro02.setLogo("http://upload.wikimedia.org/wikipedia/commons/thumb/5/56/Hotel-room-renaissance-columbus-ohio.jpg/250px-Hotel-room-renaissance-columbus-ohio.jpg");
		lista.add(registro02);
		
		Hotel registro03 = new Hotel();
		registro03.setCodigo(1);
		registro03.setNombre("HOTEL DOUBLE TREE HILTON");
		registro03.setDescripcion("dfd djhkjad jDHKd kFKLjf lKFJ");
		registro03.setCosto(220.00);
		registro03.setCamas(2);
		registro03.setLogo("http://upload.wikimedia.org/wikipedia/commons/thumb/5/56/Hotel-room-renaissance-columbus-ohio.jpg/250px-Hotel-room-renaissance-columbus-ohio.jpg");
		lista.add(registro03);
		
		Hotel registro04 = new Hotel();
		registro04.setCodigo(1);
		registro04.setNombre("HOTEL MARRIOT");
		registro04.setDescripcion("dfd djhkjad jDHKd kFKLjf lKFJ");
		registro04.setCosto(250.00);
		registro04.setCamas(2);
		//lista.add(registro04);
		
		return lista;
	}

	
	

}
