Zoom();

function Zoom() {


	$("img").click(function(event) {
		var x = $(this).attr('src');
			$("#zoom").html("<img src ='" + x + "'>")
	});



	
	$("#zoom").click(function(event) {
		var x = $(this).attr('src');
			$("#zoom").html("");

			});

/*
	$("img").mouseleave(function(event) {
		 $("#zoom").html("");
	});

*/
	/*$(document).on("contextmenu", "img", function(e){
   $("#zoom").html("");
   return false;
});*/
}