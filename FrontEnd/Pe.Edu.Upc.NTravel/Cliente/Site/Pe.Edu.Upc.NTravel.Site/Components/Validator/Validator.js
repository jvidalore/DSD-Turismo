ns('His.UI');
// / <summary>
// / Framework de validacion de formularios.
// / </summary>
// / <remarks>
// / Creacion: LOG(EMP) 20121015 <br />
// / </remarks>
His.UI.Validator = function(opts) {
	this.init(opts);
};

His.UI.Validator.prototype = {
	form : null,
	customsValidator : null,
	validator : null,
	messageBox : null,
	init : function(opts) {
		if (opts) {

			this.form = opts.form ? document.getElementById(opts.form) : null;
			this.messageBox = new Belcorp.Planit.UI.MessageBox();
			this.customsValidator = opts.customsValidator ? opts.customsValidator
					: null;
			if (this.form != null) {
				this.validator = $(this.form).validate();
				this.validator.settings.success = 'valid';
				this.validator.settings.highlight = function(element,
						errorClass) {
					$(element).fadeOut(function() {
						$(element).fadeIn();
					});
				};
				this.validator.settings.showErrors = function() {
				};
				this.validator.settings.ignore = '';
			}
		}

		this.config();

		if (this.form != null) {
			this.validator.init();
		}
	},

	isValid : function() {

		var message = '<ul>';
		var valid = true;
		if (this.form != null) {
			this.validator.form();
			valid = this.validator.valid();
			if (this.validator.errorList.length > 0) {
				$(this.validator.errorList).each(function() {
					message = message + '<li>' + $(this)[0].message + '</li>';
				});
			}
		}
		if (this.customsValidator != null) {
			$.each(this.customsValidator, function(index, value) {
				if (value.event && value.event != null
						&& !value.event.apply(value, value.Args)) {
					message = message + '<li>' + value.errorMessage + '</li>';
					valid = false;
				}
			});
		}

		message = message + '</ul>';

		if (!valid) {
			var dataMensaje = {
				title : 'Error de validación',
				text : 'Se detectaron algunos datos invalidos, de favor verifique lo indicado :<br/>'
						+ message
			};
			this.messageBox.showError(dataMensaje);
		}

		return valid;
	},
	config : function() {
		if (this.form != null) {

			var rules = {};
			var messages = {};

			$(this.form).find($('.validable')).each(function() {

				var validationTag = $(this).attr('validation');
				var controlName = $(this).attr('name');
				var errorMessage = $(this).attr('errorMessage');

				var settingControl = {};
				var settingMessages = {};

				$.each($.trim(validationTag).split(','), function(index, value) {
					var items = $.trim(value).split(' ');
					var rule = $.trim(items[0]);
					var value = $.trim(items[1]);
					var newValue = null;
					if (value == 'true') {
						newValue = true;
					}
					if (value == 'false') {
						newValue = false;
					}
					if ($.isNumeric(value)) {
						newValue = parseInt(valor);
					}

					settingControl[rule] = newValue;
					settingMessages[rule] = errorMessage;
				});

				rules[controlName] = settingControl;
				messages[controlName] = settingMessages;
			});
			this.validator.settings.rules = rules;
			this.validator.settings.messages = messages;
		}

	}
};