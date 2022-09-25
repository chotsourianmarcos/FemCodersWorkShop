//variables
var IdToModify = 0;

//modal pop ups
var ShowAddPhotoPopUp = function () {
    $('#AddPhotoPopUp').modal('show');
}
var CloseAddPhotoPopUp = function () {
    $('#AddPhotoPopUp').modal('hide');
    document.getElementById("AddTitleInput").value = "";
    document.getElementByClass("addDescriptionInput").value ="";
    document.querySelector(btnIdSelector).value = null;
    AddTitleValidationErrorControl(false);
    AddDescriptionValidationErrorControl(false);
}
var ShowModifyPhotoPopUp = function (id) {
    $('#ModifyPhotoPopUp').modal('show');
    IdToModify = id;
}
var CloseModifyPhotoPopUp = function (id) {
    $('#ModifyPhotoPopUp').modal('hide');
    document.getElementById("ModifyTitleInput").value = "";
    document.getElementById("ModifyDescriptionInput").value = "";
    ModifyTitleValidationErrorControl(false);
    ModifyDescriptionValidationErrorControl(false);
    IdToModify = 0;
}

//Validación campos
var AddTitleValidationErrorControl = function (show) {
    if (show) {
        $('#AddTitleValidationText').show()
        $('#AddTitleSeparator').hide();
    } else {
        $('#AddTitleValidationText').hide()
        $('#AddTitleSeparator').show();
    }
}
var AddDescriptionValidationErrorControl = function (show) {
    if (show) {
        $('#AddDescriptionValidationText').show()
        $('#AddDescriptionSeparator').hide();
    } else {
        $('#AddDescriptionValidationText').hide()
        $('#AddDescriptionSeparator').show();
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
var ModifyTitleValidationErrorControl = function (show) {
    if (show) {
        $('#ModifyTitleValidationText').show()
        $('#ModifyTitleSeparator').hide();
    } else {
        $('#ModifyTitleValidationText').hide()
        $('#ModifyTitleSeparator').show();
    }
}
var ModifyDescriptionValidationErrorControl = function (show) {
    if (show) {
        $('#ModifyDescriptionValidationText').show()
        $('#ModifyDescriptionSeparator').hide();
    } else {
        $('#ModifyDescriptionValidationText').hide()
        $('#ModifyDescriptionSeparator').show();
    }
}

//Cargar fotos
var RefreshGallery = function () {
    $.ajax({
        url: "/Home/Gallery",
        type: "post",
        data: null
    }).done(function (result) {
        $("#Gallery").html(result);
    });
}

//ABM
var CreatePhotoModel = function (title, description, photoFile) {
    var PhotoModel = {
        Title: title,
        Description: description,
        PhotoFile: photoFile
    }
    return PhotoModel;
}

var ReadFileCallback = function (file, error, fileName) {
    ValidateAddPhotoForm(file, error, fileName);
}

var ValidateAddPhotoForm = function (photoFile, error, fileName) {
    var titleValue = document.getElementById("AddTitleInput").value;
    var descriptionValue = document.getElementById("AddDescriptionInput").value;

    var formIsValid = true;
    if (IsNullOrEmpty(titleValue)) {
        AddTitleValidationErrorControl(true);
        formIsValid = false;
    }
    if (IsNullOrEmpty(descriptionValue)) {
        AddDescriptionValidationErrorControl(true);
        formIsValid = false;
    }
    if (error) {
        FileValidationErrorControl(error, true);
        formIsValid = false;
    }

    if (!fileName.match(/\.(jpg|jpeg|png|gif)$/i)) {
        alert('El archivo no es una imagen.');
        formIsValid = false;
    }
        
    if (formIsValid) {
        AcceptNewPhoto(CreatePhotoModel(titleValue, descriptionValue, photoFile));
    }
}

var AcceptNewPhoto = function (photoModel) {
    var fd = new FormData();
    fd.append('title', photoModel.Title);
    fd.append('description', photoModel.Description);
    fd.append('file', photoModel.PhotoFile);
    $.ajax({
        url: 'Home/AddPhoto',
        type: "POST",
        processData: false,
        contentType: false,
        timeout: 10000,
        data: fd,
        success: function (data) {
            if (data == 404) {
                alert("Hubo un error inesperado, reintente por favor.");
            } else {
                RefreshGallery();
                CloseAddPhotoPopUp();
                alert("La foto ha sido agregada exitosamente.");
            }
        },
        error: function (xhr, ajaxOptions, thrownError) {
            CloseAddPhotoPopUp();
            alert("Hubo un error inesperado, reintente por favor.");
        }
    });
}

var DeletePhoto = function (id) {
    var fd = new FormData();
    fd.append('Id', id);
    $.ajax({
        url: 'Home/DeletePhoto',
        type: "DELETE",
        processData: false,
        contentType: false,
        timeout: 10000,
        data: fd,
        success: function (data) {
            alert("La foto ha sido eliminada exitosamente.");
            RefreshGallery();
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert("Hubo un error inesperado. Reintente por favor.");
        }
    });
}

var ValidateModifyPhotoForm = function () {
    var titleValue = document.getElementById("ModifyTitleInput").value;
    var descriptionValue = document.getElementById("ModifyDescriptionInput").value;

    var formIsValid = true;
    if (IsNullOrEmpty(titleValue)) {
        ModifyTitleValidationErrorControl(true);
        formIsValid = false;
    }
    if (IsNullOrEmpty(descriptionValue)) {
        ModifyDescriptionValidationErrorControl(true);
        formIsValid = false;
    }

    if (formIsValid) {
        AcceptModifyPhoto(titleValue, descriptionValue);
    }
}

var AcceptModifyPhoto = function (title, description) {
    var fd = new FormData();
    fd.append('id', IdToModify);
    fd.append('title', title);
    fd.append('description', description);
    $.ajax({
        url: 'Home/UpdatePhoto',
        type: "PATCH",
        processData: false,
        contentType: false,
        timeout: 10000,
        data: fd,
        success: function (data) {
            if (data == 404) {
                alert("Hubo un error inesperado, reintente por favor.");
            } else {
                RefreshGallery();
                CloseModifyPhotoPopUp();
                alert("La foto ha sido modificada exitosamente.");
            }
        },
        error: function (xhr, ajaxOptions, thrownError) {
            CloseAddPhotoPopUp();
            alert("Hubo un error inesperado, reintente por favor.");
        }
    });
}

$(document).ready(function () {
    $("#ShowAddPhotoPopUpBtn").click(function () {
        ShowAddPhotoPopUp();
    });
    $("#CloseBtn").click(function () {
        CloseAddPhotoPopUp();
    });
    $("#ModifyCloseBtn").click(function () {
        CloseModifyPhotoPopUp();
    });
    $("#AcceptModifyPhoto").click(function () {
        ValidateModifyPhotoForm();
    });
    
    $('#TitleValidationText').hide();
    $('#DescriptionValidationText').hide();
    $('#FileValidationText').hide();

    RefreshGallery();

    LoadLayoutDocumentReady();

});