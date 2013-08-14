Zoom();
CreateFolder();
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

$("#AddFolder").click(function(event) {

	$("#CreateFolder").css('display', 'inline-block');
	$("#FolderName").css('display', 'inline-block');

});

function CreateFolder() {
	$("#CreateFolder").click(function(event) {
		var z = $("#FolderName").val();
		$("#content").append("<div class='folder'><img src='folder.png'>" + z + "</div>")
	});
}