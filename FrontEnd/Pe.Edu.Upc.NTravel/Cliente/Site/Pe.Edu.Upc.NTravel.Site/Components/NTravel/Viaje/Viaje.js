ns('Pe.Edu.Upc.NTravel.Site');
// / <summary>
// / Script de control de la vista Login
// / </summary>
// / <remarks>
// / Creacion: LOG(EMP) 201209 <br />
// / </remarks>
Pe.Edu.Upc.NTravel.Site.Viaje = function () {

    var base = this;

    base.inicializar = function () {
        'use strict';
        base.controles.btnBuscar().click(base.eventos.btnBuscarClick);
        base.controles.ddlLugarOrigen().change(base.eventos.ddlLugarOrigenChange);
        base.controles.txtPartida().datepicker({
            showOn: 'button',
            buttonImage: AppPath + 'Theme/images/calendar.png',
            buttonImageOnly: true,
            dateFormat: 'dd/mm/yy',
            onClose: function (selectedDate) {
                if (selectedDate != null && selectedDate != '') {
                    var day = parseInt(selectedDate.substring(0, 2));
                    selectedDate = (day + 1) + selectedDate.substring(2);
                    base.controles.txtRegreso().datepicker("option", "minDate", selectedDate);
                }
            }
        });
        base.controles.txtRegreso().datepicker({
            showOn: 'button',
            buttonImage: AppPath + 'Theme/images/calendar.png',
            buttonImageOnly: true,
            dateFormat: 'dd/mm/yy',
            onClose: function (selectedDate) {
                if (selectedDate != null && selectedDate != '') {
                    var day = parseInt(selectedDate.substring(0, 2));
                    selectedDate = (day - 1) + selectedDate.substring(2);
                    base.controles.txtPartida().datepicker("option", "maxDate", selectedDate);
                }
            }
        });
        var date = new Date();
        var fechaInicio = date.getDate() + 1 + "/";
        fechaInicio += (date.getMonth() + 1) + "/";
        fechaInicio += date.getFullYear();
        base.controles.txtPartida().datepicker("option", "minDate", fechaInicio);
        base.controles.txtRegreso().datepicker("option", "minDate", fechaInicio);
    };

    base.controles = {
        btnBuscar: function () {
            return $('#btnBuscar');
        },
        divResultado: function () {
            return $('#divResultado');
        },
        ddlLugarOrigen: function () {
            return $('#ddlLugarOrigen');
        },
        ddlLugarDestino: function () {
            return $('#ddlLugarDestino');
        },
        txtPartida: function () {
            return $('#txtPartida');
        },
        txtRegreso: function () {
            return $('#txtRegreso');
        },
        validadorViaje: new His.UI.Validator({
            form: 'frmViaje'
        }),
        messageBox: new Belcorp.Planit.UI.MessageBox()
    };

    base.eventos = {
        AjaxBuscarDisponibilidadRespuesta: function (data) {
            base.controles.divResultado().html(data);
        },
        btnBuscarClick: function () {
            if (base.controles.validadorViaje.isValid()) {
                base.invocaciones.AjaxBuscarDisponibilidad.submit();
            }
        },
        ddlLugarOrigenChange: function () {
            base.controles.ddlLugarDestino().find('option').remove();
            base.controles.ddlLugarOrigen().find('option').each(function () {
                var seleccionado = false;
                if ($(this).attr('selected')) {
                    seleccionado = true;
                }
                if (!seleccionado) {
                    base.controles.ddlLugarDestino().append($(this).clone());
                }
            });
        }
    };

    base.invocaciones = {
        AjaxBuscarDisponibilidad: new His.Util.Ajax({
            form: 'frmViaje',
            dataType: 'html',
            onSuccess: base.eventos.AjaxBuscarDisponibilidadRespuesta,
            autoSubmit: false
        })
    };
};