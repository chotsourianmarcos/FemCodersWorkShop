////var CloseAlertPopUp = function () {
////    $('#AlertPopUp').modal('hide');
////}
var IsNullOrEmpty = function (str) {
    return str === null || str.match(/^ *$/) !== null;
}
var ReadFileCallback = function (file, error) {
	var checkpoint = 0;
	//not implemented.
}

//var ShowAlertPopUp = function (text) {
//    $("#AlertPopUpText").text(text);
//    $('#AlertPopUp').modal('show');
//}

var LoadLayoutDocumentReady = function () {

    //$("#CloseAlertPopUpBtn").click(function () {
    //    CloseAlertPopUp();
    //});

	document.querySelector(".awaitFile").addEventListener('click', async function (e) {

		var btnIdSelector = "#" + e.target.value;
		if (document.querySelector(btnIdSelector).value == '') {
			return ReadFileCallback(null, "No se seleccionó ningún archivo.");
		}

		var file = await document.querySelector(btnIdSelector).files[0];

		ReadFileCallback(file, null);

	});

}