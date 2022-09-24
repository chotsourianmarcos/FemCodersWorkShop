﻿var CreatePhotoModel = function (title, description, photoFile) {
    var PhotoModel = {
        Title: title,
        Description: description,
        PhotoFile: photoFile
    }
    return PhotoModel;
}

var ShowAddPhotoPopUp = function () {
    $('#AddPhotoPopUp').modal('show');
}
var CloseAddPhotoPopUp = function () {
    $('#AddPhotoPopUp').modal('hide');
    /*DEFINIR ClearNewPhotoForm();*/
}

var TitleValidationErrorControl = function (show) {
    if (show) {
        $('#TitleValidationText').show()
        $('#TitleSeparator').hide();
    } else {
        $('#TitleValidationText').hide()
        $('#TitleSeparator').show();
    }
}
var DescriptionValidationErrorControl = function (show) {
    if (show) {
        $('#DescriptionValidationText').show()
        $('#DescriptionSeparator').hide();
    } else {
        $('#DescriptionValidationText').hide()
        $('#DescriptionSeparator').show();
    }
}
var FileValidationErrorControl = function (error, show) {
    if (show) {
        $('#FileValidationText').text(error);
        $('#FileValidationText').show();
    } else {
        $('#FileValidationText').text('');
        $('#FileValidationText').hide();
    }
}

var ReadFileCallback = function (file, error) {
    ValidateAddPhotoForm(file, error);
}

var ValidateAddPhotoForm = function (photoFile, error) {
    var titleValue = document.getElementById("TitleInput").value;
    var descriptionValue = document.getElementById("DescriptionInput").value;

    var formIsValid = true;
    if (IsNullOrEmpty(titleValue)) {
        TitleValidationErrorControl(true);
        formIsValid = false;
    }
    if (IsNullOrEmpty(descriptionValue)) {
        DescriptionValidationErrorControl(true);
        formIsValid = false;
    }
    if (error) {
        FileValidationErrorControl(error, true);
        formIsValid = false;
    }

    if (formIsValid) {
        AcceptNewPhoto(CreatePhotoModel(titleValue, descriptionValue, photoFile));
    }
    //A VECES MEDIO QUE SE CIERRA SIN ERROR Y SE CHOTEA. EN INCÓGNITO CREO QUE NO PASA. VERLO.
}

var AcceptNewPhoto = function (photoModel) {
    //var content = {
    //    title: photoModel.Title,
    //    description: photoModel.Description,
    //    photoFile: photoModel.PhotoFile
    //}
    var fd = new FormData();
    fd.append('title', photoModel.Title);
    fd.append('description', photoModel.Description);
    fd.append('file', photoModel.PhotoFile);
    $.ajax({
        url: 'Home/AddPhoto',
        type: "POST",
        processData: false,
        contentType: false,
        /*url: HomeVM.Url + '/AddPhoto',*/
        /*data: JSON.stringify(content),*/
        data: fd,
        success: function (data) {
            alert("success");
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert("error");
            /*alert(xhr.responseText);*/
        }
    });
    CloseAddPhotoPopUp();
}


$(document).ready(function () {
    $("#ShowAddPhotoPopUpBtn").click(function () {
        ShowAddPhotoPopUp();
    });
    $("#CloseBtn").click(function () {
        CloseAddPhotoPopUp();
    });

    //$("#CloseBtn").click(function () {
    //    ClearNewPhotoForm();
    //});
    
    $('#TitleValidationText').hide();
    $('#DescriptionValidationText').hide();
    $('#FileValidationText').hide();

    LoadLayoutDocumentReady();
});

//REPASAR BIEN TODO. BUENAS PRÁCTICAS. BREVE. SÓLIDO. CREATIVO. BUENOS NOMBRES DE COSAS. ETCS.