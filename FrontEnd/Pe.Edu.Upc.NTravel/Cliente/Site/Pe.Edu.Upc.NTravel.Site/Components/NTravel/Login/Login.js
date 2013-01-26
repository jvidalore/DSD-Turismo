ns('Pe.Edu.Upc.NTravel.Site');
// / <summary>
// / Script de control de la vista Login
// / </summary>
// / <remarks>
// / Creacion: LOG(EMP) 201209 <br />
// / </remarks>
Pe.Edu.Upc.NTravel.Site.Login = function () {

	var base = this;

	base.inicializar = function() {
		'use strict';
		base.controles.btnEntrar().click(base.eventos.btnEntrarClick);
		base.controles.lnkRegistro().click(base.eventos.lnkRegistroClick);
	};

	base.controles = {
		btnEntrar : function() {
			return $('#btnEntrar');
		},
		lnkRegistro : function() {
			return $('#lnkRegistro');
		},
		validadorLogin : new His.UI.Validator({
			form : 'frmLogin'
		}),
		messageBox : new Belcorp.Planit.UI.MessageBox()
	};

	base.eventos = {
		AjaxIniciarSesionRespuesta : function(data) {
		    if (data != null && data.DefaultAction != '') {
		        window.location.href = data.DefaultAction;
			} else {
				base.controles.messageBox.showError({
					title : 'Error al inciar sesion',
					text : 'Usuario o clave incorrecto'
				});
			}
		},
		btnEntrarClick : function() {
			if (base.controles.validadorLogin.isValid()) {
				base.invocaciones.AjaxIniciarSesion.submit();
			}
		},
		lnkRegistroClick : function() {
			indexUsuario.controles.VentanaRegistro().dialog('open');
		}
	};

	base.invocaciones = {
		AjaxIniciarSesion : new His.Util.Ajax({
			form : 'frmLogin',
			onSuccess : base.eventos.AjaxIniciarSesionRespuesta,
			autoSubmit : false
		})
	};
};