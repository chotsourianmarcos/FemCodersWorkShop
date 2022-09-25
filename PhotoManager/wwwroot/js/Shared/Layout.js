var IsNullOrEmpty = function (str) {
    return str === null || str.match(/^ *$/) !== null;
}
var ReadFileCallback = function (file, error) {
	//not implemented.
}

var LoadLayoutDocumentReady = function () {

	document.querySelector(".awaitFile").addEventListener('click', async function (e) {

		var btnIdSelector = "#" + e.target.value;
		if (document.querySelector(btnIdSelector).value == '') {
			return ReadFileCallback(null, "No se seleccionó ningún archivo.");
		}

		var file = await document.querySelector(btnIdSelector).files[0];

		ReadFileCallback(file, null, file.name);

	});

}