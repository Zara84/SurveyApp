
$(document).ready(function() {
		$.ajaxSetup({
			cache: false,
			error: function (x, e) {
				if (x.status == 0) {
					alert('You are offline!!\n Please Check Your Network.');
				} else if (x.status == 404) {
					alert('Requested URL not found.');
				} else if (x.status == 500) {
					alert('Internal Server Error.');
				} else if (e == 'parsererror') {
					alert('Error.\nParsing JSON Request failed.');
				} else if (e == 'timeout') {
					alert('Request Time out.');
				} else {
					alert('Unknown Error.\n' + x.responseText);
				}
			}
		})
});
			
$(document).ready(function(){
	$('.collapse').collapse()
})

$(function () {
	$('[data-toggle="popover"]').popover()
});
			
$(function(){
		$("#sortable").sortable({
			opacity: 0.5,
			placeholder: "sortable-placeholder",
			start: function (event, ui) {
				$(ui.item).children().removeClass("active");
				console.log("dropped something");
			},
			stop: function (event, ui) {
				$(ui.item).children().addClass("active");
				console.log("dropped something");
			}
		})
});
				
$(function(){
		$("#sortable").disableSelection();
	})

$(function () {
	$('.catNav').click(function (event) {

		console.log('wtf');
		event.preventDefault();
		event.stopPropagation();

		var idd = $(this).attr('aria-controls');
		var col = $("[id=" + idd + "]")

		var disp = col.css("display");

		console.log(disp + " " + col.length);

		if (disp === "none")
			col.css("display", "block");
		else
			col.css("display", "none");


		//console.log(id);
	})
})
			
/*$(function(){
		$('.qParent').click(function (event) {

			console.log('wtf');
			event.preventDefault();
			event.stopPropagation();

			var idd = $(this).attr('aria-controls');
			var col = $("[id=" + idd + "]")

			var disp = col.css("display");

			console.log(disp + " " + col.length);

			if (disp === "none")
				col.css("display", "block");
			else
				col.css("display", "none");


			//console.log(id);

		})
	})
	*/
$(function(){
		$('.qNav').click(function (event) {
			
			event.preventDefault();
			event.stopPropagation();

			var id = $(this).attr('id');
			console.log('wtf ' + id);

			$.get("/Question/DisplayParentQuestions", { cat_id: id }, function (data) {
				//alert(data);
				$('#qBar').empty();
				$('#qBar').html(data);
			})

		})
	})
	
$(function(){
		$('#continue').click(function () {

			var catsArray = new Array();
			var cats = $("[id=catIndex]");
			for (i = 0; i < cats.length; i++) {
				console.log(cats.length);
				catsArray[i] = $(cats[i]).html();
			}
			console.log(catsArray);

			var meh = $('#catsArray').val(catsArray);
			console.log("meh  " + meh.val());

			$.post("/Question/parseCats", { name: meh.val().toString() }, function (data) {
				

				$.get("/Question/parseQuestions", function (data) {
					//alert(data);
					document.location = "/Question/SurveyContainer";
				})
			});

		})
})



