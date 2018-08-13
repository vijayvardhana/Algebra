class Registration {

    constructor() {
        this.mType;
        this.tabCtrl = $(".nav-tabs");
        this.ctrl = new Array();
        this.member = {};
        this.spouse = {};
        this.register = {};
        this.dependent = {};
        this.payment = {};
        this.ctrl = [];
        
        this.url = "/api/member/AddMember";
    }

    TabsSelection(m) {
        let t = this;
        t.mType = m;
        console.log(m);
        switch (t.mType) {
            case '1':
                t.DisableTabs();
                t.EnableTabs([0, 3, 4]);
                break;
            case '2':
                t.DisableTabs();
                t.EnableTabs([0, 1, 3, 4]);
                break;
            case '3':
                t.DisableTabs();
                t.EnableTabs([0, 2, 3, 4]);
                break;
            case '4':
                t.DisableTabs();
                t.EnableTabs([0, 1, 2, 3, 4]);
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

        let d1 = {};
        let d2 = {};

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
                case 'dependent_1':
                case 'dependent_2':
                    if (model == "dependent_1") {
                        d1[key.substr(6)] = val;
                    } else {
                        d2[key.substr(6)] = val;
                    }
                    break;
                case 'payment':
                    this.payment[key.substr(2)] = val;
                    console.log("Model: " + model + ", Key : " + key + " Value : " + val);
                    break;
                default:
            }
        }
        this.dependent["d1"] = d1;
        this.dependent["d2"] = d2;
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
                console.log('Model : ' + model + ', Control: ' + c.id + ', Value : ' + val);
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

        this.FormControlExtraction();

        if (!this.ValidateForm()) {
            return false;
        }
        else {
            this.ModelBuilder();
            
            var models = {};
            models["o1"] = this.member;
            models["o2"] = this.spouse;
            models["o3"] = this.dependent;
            models["o4"] = this.payment;
          //  return false;
            $.ajax({
                url: "/api/member/post",
                type: "POST",
                contentType: "application/json",
                dataType: "json",
                data: JSON.stringify(models),
                success: function (result) {
                    console.log(result);
                },
                error: function (xhr, resp, text) {
                    console.log(xhr, resp, text);
                }
            });
        }
    }

    SetCardNumber(char) {
        var cardNoControls = $(".form-group input[type=hidden]").each(function () {
            let e = $(this);
            let c = e.attr('acid');
            let v = 'AL' + char + '' + c;
            e.val(v);
            //console.log("current value : " + c + ", New Value : " + v);
        });
    }
}