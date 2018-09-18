$(document).ready(function () {
    $('#btnUpload').on('click', function () {
        var url = "/api/upload/upload"
        var files = $('#fileupload').prop("files");
        var fdata = new FormData();
        var nameCollection = GetNameCollection();
        
        for (var i = 0; i < files.length; i++) {
            var found = Object.keys(AttachmentArray).filter(function (key) {
                var exist = AttachmentArray[key].FileName === files[i].name;
                if (exist) {
                    fdata.append("files", files[i]);
                }
            });
        }

        if (AttachmentArray.length > 5 && files.length > 5) {
            toastr.warning("You have added more than 5 files. According to requirnment, you can upload maximum 5 files", "Image Count");
            return false;
        }
        //return;
        if (files.length > 0) {
            $.ajax({
                type: "POST",
                url: url,
                beforeSend: function (xhr) {
                    xhr.setRequestHeader("XSRF-TOKEN",
                        $('input:hidden[name="__RequestVerificationToken"]').val());
                    xhr.setRequestHeader("__ACNO",
                        $('#AccountId').val());
                    xhr.setRequestHeader("__NWNM",
                        JSON.stringify(nameCollection));
                },
                data: fdata,
                contentType: false,
                processData: false,
                success: function (response) {
                    toastr.success('Images Uploaded Successfully.', 'Hurry!!!');
                }
            });
        }
        else {
            alert('Please select a file.')
        }
    })
});

function GetNameCollection() {
    var names = {}
    $('select.image-select').each(function (index) {
        var o = {};
        var id = this.id;
        var fileName = $(this).attr('name');
        var newName = $('#' + id).val();

        if (!newName) {
            toastr.warning("Image must be assign to member,form etc", "Image name missing");
            return;
        }

        o = {
            'Old': fileName,
            'New': newName
        };
        names["o" + index] = o;
    });
    return names;
}

document.addEventListener("DOMContentLoaded", init, false);

function init() {
    document.querySelector('#fileupload').addEventListener('change', handleFileSelect, false);
}

function handleFileSelect(e) {

    if (!e.target.files) return;

    var files = e.target.files;

    for (var i = 0, f; f = files[i]; i++) {
        var fileReader = new FileReader();

        fileReader.onload = (function (readerEvt) {
            return function (e) {
                ValidationRules(readerEvt)
                RenderThumbnail(e, readerEvt);
                FillAttachmentArray(e, readerEvt)
            };
        })(f);

        fileReader.readAsDataURL(f);
    }
    document.getElementById('fileupload').addEventListener('change', handleFileSelect, false);
}

function RenderThumbnail(e, readerEvt) {
    var accountId = $('#AccountId').val();
    var sb = new StringBuilder();
    var div = document.getElementById('img-preview');
    var column_div = document.createElement('div');
    column_div.className = "col-lg-3";
    div.appendChild(column_div);

    sb.append('<div class="panel panel-default small">');
    sb.append('<div class="panel-heading img-wrap"><h4 class="panel-title">' + readerEvt.name + '<span delete = "' + readerEvt.name + '" class="close">');
    sb.append('<i class="glyphicon glyphicon-trash denger"></i></span></h4></div>');
    sb.append('<div class="panel-body"><img class="img-thumbnail" width="200px" src = "' + e.target.result + '" title = "' + escape(readerEvt.name) + '" id = "' + readerEvt.name + '" />');
    sb.append('<select class="input-sm image-select" id="img-' + readerEvt.name.replace('.','') + '" name="' + readerEvt.name + '">');
    sb.append('<option value="">--- Image for ---</option>');
    sb.append('<option value="' + accountId + '-member.' + readerEvt.name.split('.')[1] + '">Member</option>');
    sb.append('<option value="' + accountId + '-spouse.' + readerEvt.name.split('.')[1] + '">Spouse</option>');
    sb.append('<option value="' + accountId + '-first-dependent.' + readerEvt.name.split('.')[1] + '">First Dependent</option>');
    sb.append('<option value="' + accountId + '-second-dependent.' + readerEvt.name.split('.')[1] + '">Second Dependent</option>');
    sb.append('<option value="' + accountId + '-form.' + readerEvt.name.split('.')[1] + '">Form Image</option></select>');
    column_div.innerHTML = sb.toString();
}

jQuery(function ($) {
    $('div').on('click', '.img-wrap .close', function () {
        var id = $(this).attr('delete');
        var elementPos = AttachmentArray.map(function (x) { return x.FileName; }).indexOf(id);
        if (elementPos !== -1) {
            AttachmentArray.splice(elementPos, 1);
        }
        $(this).closest('.col-lg-3').remove();
    });
})

function CheckFileType(fileType) {
    if (fileType == "image/jpeg") {
        return true;
    }
    else if (fileType == "image/png") {
        return true;
    }
    else if (fileType == "image/gif") {
        return true;
    }
    else {
        return false;
    }
    return true;
}

function CheckFileSize(fileSize) {
    if (fileSize < 900000) {
        return true;
    }
    else {
        return false;
    }
    return true;
}

function CheckFilesCount(AttachmentArray) {
    var len = 0;
    for (var i = 0; i < AttachmentArray.length; i++) {
        if (AttachmentArray[i] !== undefined) {
            len++;
        }
    }
    if (len > 5) {
        return false;
    }
    else {
        return true;
    }
}

function ValidationRules(readerEvt) {
    if (CheckFileType(readerEvt.type) == false) {
        alert("The file (" + readerEvt.name + ") does not match the upload conditions, You can only upload jpg / png / gif files");
        e.preventDefault();
        return;
    }

    if (CheckFileSize(readerEvt.size) == false) {
        alert("The file (" + readerEvt.name + ") does not match the upload conditions, The maximum file size for uploads should not exceed 300 KB");
        e.preventDefault();
        return;
    }
}


var AttachmentArray = [];
var arrCounter = 0;

function FillAttachmentArray(e, readerEvt) {
    AttachmentArray[arrCounter] =
        {
            AttachmentType: 1,
            ObjectType: 1,
            FileName: readerEvt.name,
            FileDescription: "Attachment",
            NoteText: "",
            MimeType: readerEvt.type,
            Content: e.target.result.split("base64,")[1],
            FileSizeInBytes: readerEvt.size,
        };
    arrCounter = arrCounter + 1;
}


