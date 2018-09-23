$(document).ready(function () {
    $('#btnUpload').on('click', function () {
        var url = "/api/upload/upload"
        var files = $('#fileupload').prop("files");
        var fdata = new FormData();
        var nameCollection = GetNameCollection();

        if (!nameCollection) {
            toastr.warning("Image for dropdown, image must assign to member,form etc", "Image for missing");
            return false;
        }

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
            ToggleProgress(true);
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
                    ToggleProgress(false);
                },
                progress: function (e) {
                    Progressing(e);
                },
                error: function (request) {
                    toastr.error('Somthing went wrong during upload :(', 'Error!!!');
                    ToggleProgress(false);
                }
            });
        }
        else {
            toastr.warning('Please select a image first.', 'Image ???')
        }
    })
});

function GetNameCollection() {
    var names = {};
    var isvalid = true;
    $('select.image-select').each(function (index) {
        var o = {};
        var id = this.id;
        var fileName = $(this).attr('name');
        var newName = $('#' + id).val();
        if (!newName) {
            isvalid = false;
        }
        o = {
            'Old': fileName,
            'New': newName
        };
        names["o" + index] = o;
    });
    return (isvalid)
        ? names
        : isvalid;
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
    
    var sb = new StringBuilder();
    var div = document.getElementById('img-preview');
    var column_div = document.createElement('div');
    column_div.className = "col-lg-3";
    div.appendChild(column_div);

    sb.append('<div class="panel panel-default small">');
    sb.append('<div class="panel-heading img-wrap"><h5 class="panel-title">' + readerEvt.name + '<span delete = "' + readerEvt.name + '" class="close denger">');
    sb.append('<i class="glyphicon glyphicon-trash denger"></i></span></h5></div>');
    sb.append('<div class="panel-body"><img class="img-thumbnail" width="200px" src = "' + e.target.result + '" title = "' + escape(readerEvt.name) + '" id = "' + readerEvt.name + '" />');
    sb.append('<select class="input-sm image-select" style="width:90%;" id="img-' + readerEvt.name.replace('.', '') + '" name="' + readerEvt.name + '">');
    sb.append('<option value="">--- Image for ---</option>');
    sb.append(RenderDropDown(readerEvt.name.split('.')[1]));
    sb.append('</select>');
    column_div.innerHTML = sb.toString();
}

function RenderDropDown(ext) {
    var accountId = $('#AccountId').val();
    var mType = $('#MembershipType').val();
    var _sb = new StringBuilder();
    switch (mType) {
        case '1':
        case '5':
            {
                _sb.append('<option value="' + accountId + '-member.' + ext + '">Member</option>');
                _sb.append('<option value="' + accountId + '-form.' + ext + '">Form Image</option>');
                break;
            }
        case '2':
            {
                _sb.append('<option value="' + accountId + '-member.' + ext + '">Member</option>');
                _sb.append('<option value="' + accountId + '-spouse.' + ext + '">Spouse</option>');
                _sb.append('<option value="' + accountId + '-form.' + ext + '">Form Image</option>');
                break;
            }
        case '3':
            {
                _sb.append('<option value="' + accountId + '-member.' + ext + '">Member</option>');
                _sb.append('<option value="' + accountId + '-spouse.' + ext + '">Spouse</option>');
                _sb.append('<option value="' + accountId + '-first-dependent.' + ext + '">First Dependent</option>');
                _sb.append('<option value="' + accountId + '-second-dependent.' + ext + '">Second Dependent</option>');
                _sb.append('<option value="' + accountId + '-form.' + ext + '">Form Image</option>');
                break;
            }
        case '4':
            {
                _sb.append('<option value="' + accountId + '-member.' + ext + '">Member</option>');
                _sb.append('<option value="' + accountId + '-first-dependent.' + ext + '">First Dependent</option>');
                _sb.append('<option value="' + accountId + '-second-dependent.' + ext + '">Second Dependent</option>');
                _sb.append('<option value="' + accountId + '-form.' + ext + '">Form Image</option>');
                break;
            }
    }
    return _sb.toString();
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

function ToggleProgress(flag) {
    if (flag) {
        $('.progress').removeClass('hidden');
        $('.progress-bar').css({
            "width": "0%"
        });
        $('.progress-bar span').html('0% complete');
    }
    else {
        $('.progress').addClass('hidden');
    }
}

function Progressing(e) {
    if (e.lengthComputable) {
        var pct = (e.loaded / e.total) * 100;
        $('.progress-bar').css({
            "width": pct + "%"
        });
        $('.progress-bar span').html(pct + '% complete');
    } else {
        console.warn('Content Length not reported!');
    }
}