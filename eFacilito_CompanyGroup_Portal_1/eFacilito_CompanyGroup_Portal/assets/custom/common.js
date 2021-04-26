
/* Start: common validation functions */

function validateName(name){
	var nameReg = /^[a-zA-Z\'\-\s]+$/;
	return nameReg.test(name);
}

function validateDecimalNumber(num){
	var decimalNumReg = /^[1-9]\d*(\.\d+)?$/;
	return decimalNumReg.test(num);
}

function validateNumber(num){
	var numReg = /^[0-9]+$/;
	return numReg.test(num);
}

function validateMobile(num){
	var mobReg = /^\d{10}$/;
	return mobReg.test(num);
}

function validateContactNumber(num){
	var contactNoReg = /^\d{8,12}$/;
	return contactNoReg.test(num);
}

function validateAlphaNumeric(string){
	var alphaNumericReg = /^\w+$/;
	return alphaNumericReg.test(string);
}

function validateEmail(email) {
	var emailReg = /^([\w-\.]+@([\w-]+\.)+[\w-]{2,4})?$/;
	return emailReg.test(email);
}
/* End: common validation functions */

/* Start:: Notify function custom  */

/* Notify functions defaults */
var notify_icon_font_awesome = {
	'danger'	: 'fa-exclamation-circle',
	'success'	: 'fa-check-square-o',
	'warning'	: 'fa-exclamation-triangle',
	'info'		: 'fa-info-circle'
};

var notify_title = {
	'danger'	: 'Error!',
	'success'	: 'Success !!',
	'warning'	: 'Warning!',
	'info'		: 'Info..'
};

/*  quick notify (bootstrap notify)
	type: 	string		'success','danger','warning','info'
	message: string		Message to display
 */
function quick_notify(type,message, delay = 0, icon_type = null)
{
	if(icon_type == null)
	{
		var icon_type = notify_icon_font_awesome[type];
	}
	
	setTimeout(function()
	{
		$.notify(
		{
			//options
			icon: 'fa ' + icon_type + ' fa-fw',
			title: '<strong>' + notify_title[type] + '</strong>',
			message: message
		},{
			//settings
			allow_dismiss: true,
			type: type,
			delay: delay
		});
	},1000);
};

/* End:: Notify functions custom  */

/* Start:: Special validation classes */

$(function()
{
	/* validation to allow numbers only */
	$('body').on('keydown keyup','.numbers_only',function (e)
	{
		var _this = $(this);
		if ($.inArray(e.keyCode, [46, 8, 9, 27, 13]) !== -1 || (e.keyCode == 65 && ( e.ctrlKey === true || e.metaKey === true ) ) || (e.keyCode >= 35 && e.keyCode <= 40))
		{
			return;
		}
		if ((e.shiftKey || (e.keyCode < 48 || e.keyCode > 57)) && (e.keyCode < 96 || e.keyCode > 105))
		{
			if(_this.hasClass('form-control'))
			{
				_this.parents('.form-group').find('[id^="error_"]').html('Invalid input. Only numbers are allowed.');
			}
			e.preventDefault();
		}
	});
	
	$('body').on('keydown keyup','.decimals_only',function (e)
	{
		var _this = $(this);
		var entered_val = $(this).val().trim();
		if((e.keyCode == 110 || e.keyCode == 190) && entered_val.includes("."))
		{
			e.preventDefault();
		}
		if ($.inArray(e.keyCode, [46, 8, 9, 27, 13]) !== -1 || (e.keyCode == 65 && ( e.ctrlKey === true || e.metaKey === true ) ) || (e.keyCode >= 35 && e.keyCode <= 40) || e.keyCode == 110 || e.keyCode == 190)
		{
			return;
		}
		if ((e.shiftKey || (e.keyCode < 48 || e.keyCode > 57)) && (e.keyCode < 96 || e.keyCode > 105))
		{
			if(_this.hasClass('form-control'))
			{
				_this.parents('.form-group').find('[id^="error_"]').html('Invalid input. Only decimal numbers are allowed.');
			}
			e.preventDefault();
		}
	});
});
/* End:: Special validation classes */

/* Start:: Init bootstrap confirmation function */

var init_confirmation = function()
{
	$('[data-toggle=confirmation], .has-confirmation').confirmation({
		rootSelector: '.has-confirmation',
		placement: 'bottom',
		singleton: true,
		popout: true,
	});
}

/* End:: Bootstrap confirmation function */

/* Start:: Init plugins */
var init_plugins = function()
{
	init_confirmation();
}

/* End:: init plugins */

/* Start:: enable Plugins */
$(function()
{
	init_plugins();
});
/* End:: enable Plugins */
