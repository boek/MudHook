
var Confirm = (function() {

	var popup = new Popup({
		'width': 480
	});
	
	return {
		'open': function(callback) {
		    var html = '<p>Are you sure you would like to delete this post?</p>';
			html +='<p class="buttons"><button name="cancel" type="button">No, keep this post</button> ';
			html +='<a href="#confim">Yes, I understand this will be permanently deleted</a></p>';

			var content = new Element('div', {
				'class': 'popup_wrapper'			
			});
			content.html(html);

			popup.open({
				'content': content
			});

			// bind functions
			$('button[name=cancel]').bind('click', function() {
				popup.close();
			});

			$('a[href$=confim]').bind('click', function(event) {
				callback();
				event.end();
			});
		}

	};

}());
