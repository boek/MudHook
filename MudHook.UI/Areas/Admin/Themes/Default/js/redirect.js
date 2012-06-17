
(function() {

	var checkbox = $('#RedirectBox'), 
		redirect = $('#Redirect').parent(),
		content = $('#Content').parent();

	var set = function() {
		var display = checkbox.get('checked') ? 'block' : 'none';
		redirect.css('display', display);

		display = checkbox.get('checked') ? 'none' : 'block';
		content.css('display', display);

		if(!checkbox.get('checked')) {
			$('#Redirect').val('');
		}
	};

	// bind to input
	checkbox.bind('change', set);

	set();

}());
