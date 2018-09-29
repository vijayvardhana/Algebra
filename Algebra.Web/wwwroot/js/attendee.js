
class Attendee {
    constructor() {
        this.toggleGuestSection();
        this.attendee = {};
        this.guest1 = {};
        this.guest2 = {};
        this.ctrl = [];
        this.url = "/api/attendee/add";
    }    

    values() {

        let c = new Array();

        $(".form-control").each(function (index) {
            var o = {};
            var id = this.id;
            var value = $(this).val();
            var required = $(this).attr('data-val-required')
                ? true
                : false;

            var errorMessage = $(this).attr('data-val-required');
            var model = $(this).parents(':eq(3)').attr('id');

            o = { 'id': id, 'value': value, 'isRequired': required, 'errorMessage': errorMessage, 'model': model };

            console.log(o);
            c[index] = o;
            o = {};
        });
        this.ctrl = c;
    }
    modelBuilder() {

        for (var i = 0; i <= this.ctrl.length - 1; i++) {
            let c = this.ctrl[i];
            let model = c["model"];
            let key = c["id"];
            let val = c["value"];

            switch (model) {
                case 'attendee':
                    this.attendee[key] = val;
                    break;
                case 'guest_1':
                    this.guest1[key.substr(4)] = val;
                    break;
                case 'guest_2':
                    this.guest2[key.substr(4)] = val;
                    break;
                default:
                    break;
            }
        }

    }

    validate() {
        var sb_msg = new StringBuilder();
        for (var i = 0; i <= this.ctrl.length - 1; i++) {
            let c = this.ctrl[i];
            let model = c["model"];
            let val = c["value"];
            let required = c["isRequired"];
            let message = c["errorMessage"];
            if (required && !val) {
                sb_msg.append("<li> Tab " + model + " - " + message + "</li>");
                //console.log('Model : ' + model + ', Control: ' + c.id + ', Value : ' + val);
            }
        }

        if (sb_msg.strings.length > 0) {
            toastr.warning(sb_msg.strings, "form validation warning");
            return false;
        }
        else {
            return true;
        }
    }

    submit() {

        this.values();

        if (!this.validate()) {
            return false;
        }
        else {

            this.modelBuilder();

            var models = {};
            models["o0"] = this.attendee;
            models["o1"] = this.guest1;
            models["o2"] = this.guest2;

            $.ajax({
                url: this.url,
                beforeSend: function (xhr) {
                    xhr.setRequestHeader("XSRF-TOKEN",
                        $('input:hidden[name="__RequestVerificationToken"]').val());
                },
                type: "POST",
                contentType: "application/json",
                data: JSON.stringify(models),
                success: function (result) {
                    toastr.success(result);
                    console.log(result);
                },
                error: function (xhr, resp, text) {
                    toastr.error(xhr.responseText, resp);
                    console.log(xhr, resp, text);
                }
            });

        }

    }

    toggleGuestSection() {
        if ($("#HasGuest").is(":checked")) {
            $("#guest-section").show();
        } else {
            $("#guest-section").hide();
        }
    }

    remove() {
        $(this).parents(".remove").remove();
        toastr.info("hang on, for a sec its deleting ;)", "Deleting..!");
    }
}