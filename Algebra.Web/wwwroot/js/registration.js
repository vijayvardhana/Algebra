

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
            console.log(o);
            c[index] = o;
            o = {};
        });
        this.ctrl = c;
    }

    ModelBuilder() {
        for (var i = 0; i <= ctrl.length - 1; i++) {
            let c = ctrl[i];
            let model = c["model"];
            let key = c["id"];
            let val = c["value"];

            switch (model) {
                case 'registration':
                    register['"' + key + '"'] = val;
                    break;
                case 'member':
                    member['"' + key + '"'] = val;
                    break;
                case 'spouse':
                    spouse['"' + key + '"'] = val;
                    break;
                default:
            }
        }
        console.log(register);
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

        if (!this.ValidateForm())
        {
            return false;
        }
        else {
            $("#registration-form").submit();
        }
    }
}