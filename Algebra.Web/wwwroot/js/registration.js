

class Registration {

    constructor() {
        this.mType;
        this.tabCtrl = $(".nav-tabs");
        this.ctrl = new Array();
        this.member = {};
        this.spouse = {};
        this.register = {};
        this.ctrl = [];
        this.FormControlExtraction();
        this.url = "/api/member/AddMember";
    }

    TabsSelection(m) {
        let t = this;
        t.mType = m;
        switch (t.mType) {
            case '1':
                t.DisableTabs();
                t.EnableTabs([0, 4, 5]);
                break;
            case '2':
                t.DisableTabs();
                t.EnableTabs([0, 1, 4, 5]);
                break;
            case '3':
                t.DisableTabs();
                t.EnableTabs([0, 2, 3, 4, 5]);
                break;
            case '4':
                t.DisableTabs();
                t.EnableTabs([0, 1, 2, 3, 4, 5]);
                break;
            default:
                t.DisableTabs();
                break;
        }
    }

    EnableTabs(index) {
        for (var i = 0; i < index.length; i++) {
            let li = this.tabCtrl[0].children[index[i]];
            if (index[i] == 0) { $(li).addClass("active"); }
            $(li).removeClass('disabled');
            $(li).find('a:first').attr("data-toggle", "tab");
        }

    }

    DisableTabs() {
        let idx = [0, 1, 2, 3, 4, 5];
        for (var i = 0; i < idx.length; i++) {
            let li = this.tabCtrl[0].children[idx[i]];
            if (idx[i] == 0) { $(li).removeClass("active"); }
            $(li).addClass('disabled');
            $(li).find('a:first').removeAttr("data-toggle");
        }
    }

    FormControlExtraction() {
        let c = new Array();
        //this.ctrl = $(".form-control").each(function (index) {
        $(".form-control").each(function (index) {
            var o = {};
            var id = this.id;
            var value = $(this).val();
            var required = $(this).attr('data-val-required') ? true : false;
            var errorMessage = $(this).attr('data-val-required');
            var model = $(this).parents(':eq(3)').attr('id');;
            o = { 'id': id, 'value': value, 'isRequired': required, 'errorMessage': errorMessage, 'model': model };
            //console.log(o);
            c[index] = o;
            o = {};
        });
        this.ctrl = c;
    }

    ModelBuilder() {
        for (var i = 0; i <= this.ctrl.length - 1; i++) {
            let c = this.ctrl[i];
            let model = c["model"];
            let key = c["id"];
            let val = c["value"];

            switch (model) {
                case 'registration':
                    this.register[key.substr(2)] = val;
                    break;
                case 'member':
                        this.member[key.substr(2)] = val;
                    console.log("Model: " + model + ", Key : " + key + " Value : " + val);
                    break;
                case 'spouse':
                    this.spouse[key.substr(2)] = val;
                    break;
                default:
            }
        }
        //console.log(register);
    }

    ValidateForm() {
        var sb_msg = new StringBuilder();
        for (var i = 0; i <= this.ctrl.length - 1; i++) {
            let c = this.ctrl[i];
            let model = c["model"];
            let val = c["value"];
            let required = c["isRequired"];
            let message = c["errorMessage"];
            let tab = c["model"];
            if (required && !val) {
                sb_msg.append("<li> Tab " + tab + " - " + message + "</li>");
            }
        }

        if (sb_msg.strings.length > 0) {
            $('.modal-title').html("Error List");
            $('.modal-body>ul').html(sb_msg.toString());
            $("#error-model").modal({ show: true });

            return false;
        }
        else {
            return true;
        }
    }

    SubmitForm() {
        if (!this.ValidateForm()) {
            return false;
        }
        else {
            this.ModelBuilder();
            
            var models = {};
            models["o1"] = this.member;
            models["o2"] = this.spouse;

            $.ajax({
                url: "/api/member/post",
                type: "POST",
                contentType: "application/json",
                dataType: "json",
                data: JSON.stringify(models),
               // data: data,
                success: function (result) {
                    console.log(result);
                },

                error: function (xhr, resp, text) {
                    console.log(xhr, resp, text);
                }
            });
        }
    }
}