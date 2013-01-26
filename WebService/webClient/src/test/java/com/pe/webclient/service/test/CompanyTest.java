package com.pe.webclient.service.test;

import java.util.List;

import junit.framework.Assert;

import org.junit.Test;
import org.springframework.context.ApplicationContext;
import org.springframework.context.support.ClassPathXmlApplicationContext;

import com.pe.company.bean.Hotel;
import com.pe.company.service.HotelService;


@SuppressWarnings("unused")
public class CompanyTest {
private HotelService hotelService = null;
	
	public CompanyTest()
	{
		ApplicationContext context = 
				 new ClassPathXmlApplicationContext("/applicationContext.xml");
		this.hotelService = (HotelService) context.getBean("hotelServiceClient");
	}
	
	
	@Test
	public void testLista()
    {
		
		List<Hotel> respuesta = this.hotelService.ConsultarDisponibilidad(1);
			
		for (Hotel hotel : respuesta) {
			System.out.println(hotel.getNombre());
		}

		
		Assert.assertEquals(true,true);
    }
}
