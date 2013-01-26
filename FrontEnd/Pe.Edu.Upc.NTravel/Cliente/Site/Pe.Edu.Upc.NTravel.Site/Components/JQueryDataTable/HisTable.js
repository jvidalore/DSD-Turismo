// Copyright (c) 2012.
// All rights reserved.
/// <summary>
/// Libreria de intregracion de Jquery ajax con el proyecto planit.
/// </summary>
/// <remarks>
/// Creacion: 	LOG(EMP) 20120523 <br />
/// </remarks>
ns('His.Util');
// All rights reserved.
His.Util.Table = function(id, opts) {
	this.init(id, opts);
};

His.Util.Table.prototype = {
	id : null,
	config : null,
	init : function(id, config) {
		this.id = id ? id : null;
		this.config = config ? config : null;
		this.refresh();
	},
	refresh : function() {
		var table = $(this.id);
		var rows = $(this.id + ' .rowData');
		var me = this;
		for ( var i = 0; i < rows.length; i++) {
			$(rows[i]).click(function() {
				if (me.config.rowHandler) {
					me.config.rowHandler($(this).attr('id'), $(this));
				}
			});
		}
		table.dataTable({
			"aaSorting" : this.config.aaSorting
		});
	}
};
