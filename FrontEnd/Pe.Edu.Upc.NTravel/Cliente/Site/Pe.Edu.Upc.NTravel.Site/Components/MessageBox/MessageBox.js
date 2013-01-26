// Copyright (c) 2012.
// All rights reserved.
/// <summary>
/// Control MessageBox.
/// </summary>
/// <remarks>
/// Creacion: 	LOG(ABL) 20120525
/// </remarks>

ns('Belcorp.Planit');
ns('Belcorp.Planit.UI');
ns('Belcorp.Planit.Path');
Belcorp.Planit.UI.MessageBoxType = function() {
	this.Error = 1;
	this.Alerta = 2;
	this.Informacion = 3;
	this.Confirmacion = 4;
};

// Class and Constructor
// Instance Methods
Belcorp.Planit.UI.MessageBox = function() {
	var base = this;
	base.type = 1;
	base.posicionX = 'center';
	base.posicionY = 'center';
	base.Init = function() {

		if ($('#divMensajeAlerta').length == 0) {
			var htmlControl = '<div id="divMensajeAlerta" class="mensajeConfirmacion" >';
			htmlControl = htmlControl
					+ '<div class="messageBoxCabecera messageBoxCabeceraCommon">';
			htmlControl = htmlControl + '<span id="mensajeAlertaTipo"></span>';
			htmlControl = htmlControl
					+ '<span id="mensajeAlertaTitulo" style="float: left;font-weight:bold"></span>';
			htmlControl = htmlControl
					+ '<span id="lnkMensajeAlertaCerrarX" style="float:right;cursor: pointer;">X</span>';
			htmlControl = htmlControl + '</div>';
			htmlControl = htmlControl
					+ '<div class=\'mensajeAlertaContenido\'>';
			htmlControl = htmlControl
					+ '<div id="mensajeAlertaTexto" class="mensajeAlertaText"></div>';
			htmlControl = htmlControl
					+ '<div id="divMsbButtons" class="botones" style="float:bottom; text-align:right;">';
			htmlControl = htmlControl
					+ '<span id="lnkMensajeAlertaAceptar" class="buttonPlanit">Si</span> &nbsp;&nbsp;';
			htmlControl = htmlControl
					+ '<span id="lnkMensajeAlertaCancelar" class="buttonPlanit">No</span>&nbsp;&nbsp;</div>';
			htmlControl = htmlControl + '</div>';
			htmlControl = htmlControl + '</div>';
			$('body').append(htmlControl);
		}

		base.divMensajeAlerta = $('#divMensajeAlerta');
		base.divMensajeAlertaOverlay = $('#mensajeAlertaOverlay');
		base.divMensajeAlertaTitulo = $('#mensajeAlertaTitulo');
		base.divMensajeAlertaTexto = $('#mensajeAlertaTexto');
		base.lnkMensajeAlertaAceptar = $('#lnkMensajeAlertaAceptar');
		base.lnkMensajeAlertaCancelar = $('#lnkMensajeAlertaCancelar');
		base.lnkMensajeAlertaCerrarX = $('#lnkMensajeAlertaCerrarX');

		base.AplicarEstilo();
		base.AplicarPosicion();
		base.lnkMensajeAlertaCerrarX.click(function() {
			base.Hide();
			if (base.handlerNo != null) {
				base.handlerNo();
			}
		});

		base.lnkMensajeAlertaAceptar.on('click', function() {
			base.Hide();
			if (base.handlerYes != null) {
				base.handlerYes();
			}
		});
		base.lnkMensajeAlertaCancelar.on('click', function() {
			base.Hide();
			if (base.handlerNo != null) {
				base.handlerNo();
			}
		});
	};

	base.AplicarEstilo = function() {
		base.divMensajeAlerta.removeClass('mensajeInformacion');
		base.divMensajeAlerta.removeClass('mensajeAlerta');
		base.divMensajeAlerta.removeClass('mensajeError');
		base.divMensajeAlerta.removeClass('mensajeConfirmacion');
		$('#divMsbButtons').hide();
		switch (base.type) {
		case 1:
			base.divMensajeAlerta.addClass('mensajeAlerta');
			break;
		case 2:
			base.divMensajeAlerta.addClass('mensajeError');
			break;
		case 3:
			base.divMensajeAlerta.addClass('mensajeInformacion');
			break;
		case 4:
			base.divMensajeAlerta.addClass('mensajeConfirmacion');
			$('#divMsbButtons').show();
			break;
		}
		;
	};

	base.AplicarPosicion = function(posicionX, posicionY) {
		switch (base.posicionX) {
		case 'center':
			base.divMensajeAlerta
					.css('left', (($(window).width() - this.divMensajeAlerta
							.outerWidth()) / 2)
							+ $(window).scrollLeft() + 'px');
			break;
		case 'left':
			base.divMensajeAlerta.css('left', '0px');
			break;
		case 'right':
			base.divMensajeAlerta.css('left',
					(($(window).width() - this.divMensajeAlerta.outerWidth()))
							+ $(window).scrollLeft() + 'px');
			break;
		default:
			base.divMensajeAlerta.css('left', posicionX);
			break;
		}

		switch (base.posicionY) {
		case 'center':
			base.divMensajeAlerta
					.css('top', (($(window).height() - this.divMensajeAlerta
							.outerHeight()) / 2)
							+ $(window).scrollTop() + 'px');
			break;
		case 'top':
			base.divMensajeAlerta.css('top', '0px');
			break;
		case 'bottom':
			base.divMensajeAlerta
					.css('top', (($(window).height() - this.divMensajeAlerta
							.outerHeight()))
							+ $(window).scrollTop() + 'px');
			break;
		default:
			base.divMensajeAlerta.css('top', posicionY);
			break;
		}

	};

	base.showAlert = function(opts) {
		opts.type = 1;
		base.Show(opts);
	};
	base.showError = function(opts) {
		opts.type = 2;
		base.Show(opts);
	};
	base.showInfo = function(opts) {
		opts.type = 3;
		base.Show(opts);
	};
	base.showConfirm = function(opts) {
		opts.type = 4;
		base.Show(opts);
	};

	base.Show = function(opts) {

		if (opts) {
			base.modal = opts.modal == false ? false : true;
			base.autohide = opts.autohide == true ? true : false;
			base.type = opts.type ? opts.type : 1;
			base.posicionX = opts.posicionX ? opts.posicionX : 'center';
			base.posicionY = opts.posicionY ? opts.posicionY : 'center';
			base.handlerYes = opts.handlerYes ? opts.handlerYes : null;
			base.handlerNo = opts.handlerNo ? opts.handlerNo : null;

			base.Init();

			base.divMensajeAlertaTitulo.html(opts.title);
			base.divMensajeAlertaTexto.html(opts.text);
			base.divMensajeAlerta.fadeIn(300);
			base.divMensajeAlerta.css('zIndex', 9999);
			if (base.modal) {
				if ($('.mensajeAlertaOverlay').length == 0) {
					$('body').append(
							'<div class=\'mensajeAlertaOverlay\'></div>');
				}
				base.divMensajeAlertaOverlay = $('.mensajeAlertaOverlay');
				base.divMensajeAlertaOverlay.fadeTo(300, 0.3);
				base.divMensajeAlertaOverlay.css('zIndex', 9998);
			} else {
				if ($('.mensajeAlertaOverlay').length == 0) {
					base.divMensajeAlertaOverlay.hide();
				}
			}
			if (base.autohide) {
				base.AutoHide();
			}
		}
	};

	base.Hide = function() {
		base.divMensajeAlerta.fadeOut(300);
		base.divMensajeAlertaOverlay.fadeOut(300);
	};

	base.AutoHide = function() {
		base.divMensajeAlerta.fadeOut(7000);
		base.divMensajeAlertaOverlay.fadeOut(7000);
		base.divMensajeAlertaOverlay.hide();
	};
};
